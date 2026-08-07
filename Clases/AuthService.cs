using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Proyecto_Grupo2.Clases
{
    internal sealed class AuthUser
    {
        public int Id;
        public string Role;
        public byte[] Template;
    }

    internal static class AuthService
    {
        private static string Cs => ConnectionStringLoader.Get("DefaultConnection");

        public static AuthUser FingerprintUser(string u)
        {
            using (var c = new SqlConnection(Cs))
            using (var q = new SqlCommand(
                       "SELECT TOP 1 u.UsuarioID,u.PlantillaHuella,r.NombreRol FROM Usuarios u JOIN Roles r ON r.RolID=u.RolID WHERE u.NombreUsuario=@u AND u.Activo=1",
                       c))
            {
                q.Parameters.AddWithValue("@u", u);
                c.Open();
                using (var x = q.ExecuteReader())
                {
                    if (!x.Read())
                    {
                        RegistrarAcceso(null, "Huella", false, "Usuario inexistente o inactivo.");
                        return null;
                    }

                    if (x["PlantillaHuella"] == DBNull.Value)
                    {
                        RegistrarAcceso((int)x["UsuarioID"], "Huella", false, "El usuario no tiene una huella registrada.");
                        return null;
                    }

                    return new AuthUser
                    {
                        Id = (int)x["UsuarioID"], Role = (string)x["NombreRol"], Template = (byte[])x["PlantillaHuella"]
                    };
                }
            }
        }

        public static DataTable Roles()
        {
            using (var c = new SqlConnection(Cs))
            using (var a = new SqlDataAdapter("SELECT RolID,NombreRol FROM Roles ORDER BY NombreRol", c))
            {
                var t = new DataTable();
                a.Fill(t);
                return t;
            }
        }

        public static bool UserExists(string u)
        {
            using (var c = new SqlConnection(Cs))
            using (var q = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario=@u", c))
            {
                q.Parameters.AddWithValue("@u", u);
                c.Open();
                return (int)q.ExecuteScalar() > 0;
            }
        }

        public static int Register(string u, string p, string n, string e, int r, byte[] f)
        {
            using (var c = new SqlConnection(Cs))
            using (var q = new SqlCommand(
                       "INSERT INTO Usuarios(NombreUsuario,Contrasena,NombreCompleto,Correo,RolID,PlantillaHuella) OUTPUT INSERTED.UsuarioID VALUES(@u,@p,@n,@e,@r,@f)",
                       c))
            {
                q.Parameters.AddWithValue("@u", u);
                q.Parameters.AddWithValue("@p", Hash(p));
                q.Parameters.AddWithValue("@n", n);
                q.Parameters.AddWithValue("@e", string.IsNullOrWhiteSpace(e) ? (object)DBNull.Value : e);
                q.Parameters.AddWithValue("@r", r);
                q.Parameters.Add("@f", SqlDbType.VarBinary, -1).Value = (object)f ?? DBNull.Value;
                c.Open();
                return (int)q.ExecuteScalar();
            }
        }

        public static AuthUser Login(string u, string p)
        {
            using (var c = new SqlConnection(Cs))
            using (var q = new SqlCommand(
                       "SELECT u.UsuarioID,u.Contrasena,r.NombreRol FROM Usuarios u JOIN Roles r ON r.RolID=u.RolID WHERE u.NombreUsuario=@u AND u.Activo=1",
                       c))
            {
                q.Parameters.AddWithValue("@u", u);
                c.Open();
                using (var x = q.ExecuteReader())
                {
                    if (!x.Read())
                    {
                        RegistrarAcceso(null, "Contrasena", false, "Usuario inexistente o inactivo.");
                        return null;
                    }

                    var usuarioId = (int)x["UsuarioID"];
                    if (!Verify(p, (string)x["Contrasena"]))
                    {
                        RegistrarAcceso(usuarioId, "Contrasena", false, "Contraseña incorrecta.");
                        return null;
                    }

                    var usuario = new AuthUser { Id = usuarioId, Role = (string)x["NombreRol"] };
                    RegistrarAcceso(usuario.Id, "Contrasena", true, "Inicio de sesión correcto.");
                    return usuario;
                }
            }
        }

        public static void RegistrarResultadoHuella(AuthUser usuario, bool exitoso)
        {
            RegistrarAcceso(usuario == null ? (int?)null : usuario.Id, "Huella", exitoso,
                exitoso ? "Inicio de sesión correcto." : "Huella no reconocida.");
        }

        private static void RegistrarAcceso(int? usuarioId, string tipoAcceso, bool exitoso, string observacion)
        {
            try
            {
                using (var c = new SqlConnection(Cs))
                using (var q = new SqlCommand(
                    "INSERT INTO BitacoraAccesos(UsuarioID,TipoAcceso,Resultado,Observacion) VALUES(@id,@tipo,@resultado,@observacion)", c))
                {
                    q.Parameters.Add("@id", SqlDbType.Int).Value = usuarioId.HasValue
                        ? (object)usuarioId.Value : DBNull.Value;
                    q.Parameters.Add("@tipo", SqlDbType.VarChar, 20).Value = tipoAcceso;
                    q.Parameters.Add("@resultado", SqlDbType.VarChar, 20).Value = exitoso ? "Exitoso" : "Fallido";
                    q.Parameters.Add("@observacion", SqlDbType.VarChar, 200).Value = observacion;
                    c.Open();
                    q.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // An audit failure must not prevent a valid user from signing in.
            }
        }

        private static string Hash(string s)
        {
            var salt = new byte[16];
            using (var r = RandomNumberGenerator.Create())
            {
                r.GetBytes(salt);
            }

            using (var k = new Rfc2898DeriveBytes(s, salt, 100000))
            {
                return "PBKDF2$" + Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(k.GetBytes(32));
            }
        }

        private static bool Verify(string s, string h)
        {
            var p = h.Split('$');
            if (p.Length != 3) return h == s;
            using (var k = new Rfc2898DeriveBytes(s, Convert.FromBase64String(p[1]), 100000))
            {
                var a = k.GetBytes(32);
                var b = Convert.FromBase64String(p[2]);
                if (a.Length != b.Length) return false;
                var ok = true;
                for (var i = 0; i < a.Length; i++) ok &= a[i] == b[i];
                return ok;
            }
        }
    }
}
