using Proyecto_Grupo2.Modelos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Proyecto_Grupo2.Clases
{
    internal static class AuthService
    {
        private const string FingerprintUserSql = @"
            SELECT TOP 1 u.UsuarioID, u.PlantillaHuella, r.NombreRol
            FROM Usuarios u
            JOIN Roles r ON r.RolID = u.RolID
            WHERE u.NombreUsuario = @Usuario AND u.Activo = 1;";

        private const string LoginSql = @"
            SELECT u.UsuarioID, u.Contrasena, r.NombreRol
            FROM Usuarios u
            JOIN Roles r ON r.RolID = u.RolID
            WHERE u.NombreUsuario = @Usuario AND u.Activo = 1;";

        private const string RegisterSql = @"
            INSERT INTO Usuarios
                (NombreUsuario, Contrasena, NombreCompleto, Correo, RolID, PlantillaHuella)
            OUTPUT INSERTED.UsuarioID
            VALUES
                (@Usuario, @Contrasena, @NombreCompleto, @Correo, @RolID, @PlantillaHuella);";

        private const string FingerprintUsersSql = @"
            SELECT u.UsuarioID, u.PlantillaHuella, r.NombreRol
            FROM Usuarios u
            JOIN Roles r ON r.RolID = u.RolID
            WHERE u.Activo = 1 AND u.PlantillaHuella IS NOT NULL;";

        public static List<AuthUser> FingerprintUsers()
        {
            var users = new List<AuthUser>();

            using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
            using (var command = new SqlCommand(FingerprintUsersSql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new AuthUser
                        {
                            Id = (int)reader["UsuarioID"],
                            Role = (string)reader["NombreRol"],
                            Template = (byte[])reader["PlantillaHuella"]
                        });
                    }
                }
            }

            return users;
        }

        public static AuthUser FingerprintUser(string username)
        {
            AuthUser user = null;
            bool hasTemplate = false;

            using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
            using (var command = new SqlCommand(FingerprintUserSql, connection))
            {
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = username ?? string.Empty;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new AuthUser
                        {
                            Id = (int)reader["UsuarioID"],
                            Role = (string)reader["NombreRol"],
                            Template = reader["PlantillaHuella"] == DBNull.Value
                                ? null : (byte[])reader["PlantillaHuella"]
                        };
                        hasTemplate = user.Template != null;
                    }
                }
            }

            if (user == null)
            {
                RegistrarAcceso(null, "Huella", false, "Usuario inexistente o inactivo.");
                return null;
            }

            if (!hasTemplate)
            {
                RegistrarAcceso(user.Id, "Huella", false, "El usuario no tiene una huella registrada.");
                return null;
            }

            return user;
        }

        public static DataTable Roles()
        {
            using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
            using (var adapter = new SqlDataAdapter(
                "SELECT RolID, NombreRol FROM Roles ORDER BY NombreRol;", connection))
            {
                var roles = new DataTable();
                adapter.Fill(roles);
                return roles;
            }
        }

        public static bool UserExists(string username)
        {
            using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
            using (var command = new SqlCommand(
                "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Usuario;", connection))
            {
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = username ?? string.Empty;
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public static int Register(string username, string password, string fullName, string email, int roleId,
            byte[] fingerprintTemplate)
        {
            using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
            using (var command = new SqlCommand(RegisterSql, connection))
            {
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = username;
                command.Parameters.Add("@Contrasena", SqlDbType.VarChar, 300).Value = Hash(password);
                command.Parameters.Add("@NombreCompleto", SqlDbType.VarChar, 150).Value = fullName;
                command.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = DbValue(email);
                command.Parameters.Add("@RolID", SqlDbType.Int).Value = roleId;
                command.Parameters.Add("@PlantillaHuella", SqlDbType.VarBinary, -1).Value =
                    (object)fingerprintTemplate ?? DBNull.Value;

                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static AuthUser Login(string username, string password)
        {
            AuthUser user = null;
            string storedPassword = null;

            using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
            using (var command = new SqlCommand(LoginSql, connection))
            {
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = username ?? string.Empty;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new AuthUser
                        {
                            Id = (int)reader["UsuarioID"],
                            Role = (string)reader["NombreRol"]
                        };
                        storedPassword = (string)reader["Contrasena"];
                    }
                }
            }

            if (user == null)
            {
                RegistrarAcceso(null, "Contrasena", false, "Usuario inexistente o inactivo.");
                return null;
            }

            if (!Verify(password, storedPassword))
            {
                RegistrarAcceso(user.Id, "Contrasena", false, "Contraseña incorrecta.");
                return null;
            }

            RegistrarAcceso(user.Id, "Contrasena", true, "Inicio de sesión correcto.");
            return user;
        }

        public static void RegistrarResultadoHuella(AuthUser user, bool successful)
        {
            RegistrarAcceso(user == null ? (int?)null : user.Id, "Huella", successful,
                successful ? "Inicio de sesión correcto." : "Huella no reconocida.");
        }

        private static void RegistrarAcceso(int? userId, string accessType, bool successful, string observation)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
                using (var command = new SqlCommand(
                    "INSERT INTO BitacoraAccesos (UsuarioID, TipoAcceso, Resultado, Observacion) " +
                    "VALUES (@UsuarioID, @TipoAcceso, @Resultado, @Observacion);", connection))
                {
                    command.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = userId.HasValue
                        ? (object)userId.Value : DBNull.Value;
                    command.Parameters.Add("@TipoAcceso", SqlDbType.VarChar, 20).Value = accessType;
                    command.Parameters.Add("@Resultado", SqlDbType.VarChar, 20).Value =
                        successful ? "Exitoso" : "Fallido";
                    command.Parameters.Add("@Observacion", SqlDbType.VarChar, 200).Value = observation;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Audit logging must not prevent a valid authentication.
            }
        }

        private static object DbValue(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value;
        }

        private static string Hash(string value)
        {
            var salt = new byte[16];
            using (var random = RandomNumberGenerator.Create())
                random.GetBytes(salt);

            using (var derivedKey = new Rfc2898DeriveBytes(value, salt, 100000))
                return "PBKDF2$" + Convert.ToBase64String(salt) + "$" +
                    Convert.ToBase64String(derivedKey.GetBytes(32));
        }

        private static bool Verify(string value, string storedHash)
        {
            var parts = storedHash.Split('$');
            if (parts.Length != 3)
                return storedHash == value;

            using (var derivedKey = new Rfc2898DeriveBytes(value, Convert.FromBase64String(parts[1]), 100000))
            {
                var expected = derivedKey.GetBytes(32);
                var actual = Convert.FromBase64String(parts[2]);
                if (expected.Length != actual.Length) return false;

                var valid = true;
                for (var i = 0; i < expected.Length; i++)
                    valid &= expected[i] == actual[i];
                return valid;
            }
        }
    }
}
