using Proyecto_Grupo2.Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Grupo2.Clases
{
    internal sealed class PacienteRegistrationException : Exception
    {
        public bool IsDuplicateDpi { get; private set; }

        public PacienteRegistrationException(string message, bool isDuplicateDpi = false, Exception innerException = null)
            : base(message, innerException)
        {
            IsDuplicateDpi = isDuplicateDpi;
        }
    }

    internal sealed class PacienteQueryException : Exception
    {
        public PacienteQueryException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }

    internal static class PacienteService
    {
        private const string SelectAllSql = @"
            SELECT PacienteID, Nombres, Apellidos, DPI, FechaNacimiento, Genero,
                   Direccion, Telefono, Correo, TipoSangre, FechaRegistro
            FROM Pacientes
            ORDER BY Apellidos, Nombres;";

        private const string SearchSql = @"
            SELECT PacienteID, Nombres, Apellidos, DPI, FechaNacimiento, Genero,
                   Direccion, Telefono, Correo, TipoSangre, FechaRegistro
            FROM Pacientes
            WHERE (@Nombre = '' OR Nombres LIKE @NombreFiltro OR Apellidos LIKE @NombreFiltro
                   OR (Nombres + ' ' + Apellidos) LIKE @NombreFiltro)
              AND (@DPI = '' OR DPI LIKE @DPIFiltro)
            ORDER BY Apellidos, Nombres;";

        private const string InsertSql = @"
            INSERT INTO Pacientes
                (Nombres, Apellidos, DPI, FechaNacimiento, Genero, Direccion, Telefono, Correo, TipoSangre)
            VALUES
                (@Nombres, @Apellidos, @DPI, @FechaNacimiento, @Genero, @Direccion, @Telefono, @Correo, @TipoSangre);";

        public static void Registrar(Paciente paciente)
        {
            Validar(paciente);

            try
            {
                using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
                using (var command = new SqlCommand(InsertSql, connection))
                {
                    command.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = paciente.Nombres;
                    command.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = paciente.Apellidos;
                    command.Parameters.Add("@DPI", SqlDbType.VarChar, 20).Value = DbValue(paciente.DPI);
                    command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = paciente.FechaNacimiento.Date;
                    command.Parameters.Add("@Genero", SqlDbType.Char, 1).Value = paciente.Genero;
                    command.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = DbValue(paciente.Direccion);
                    command.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = DbValue(paciente.Telefono);
                    command.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = DbValue(paciente.Correo);
                    command.Parameters.Add("@TipoSangre", SqlDbType.VarChar, 5).Value = paciente.TipoSangre;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                var duplicateDpi = exception.Number == 2627 || exception.Number == 2601;
                throw new PacienteRegistrationException(
                    duplicateDpi ? "Ya existe un paciente registrado con ese número de identidad." :
                        "No se pudo registrar el paciente. Verifique la conexión con la base de datos.",
                    duplicateDpi, exception);
            }
        }

        private static void Validar(Paciente paciente)
        {
            if (paciente == null) throw new ArgumentNullException("paciente");
            if (string.IsNullOrWhiteSpace(paciente.Nombres) || string.IsNullOrWhiteSpace(paciente.Apellidos))
                throw new ArgumentException("Ingrese el nombre y los apellidos del paciente.");
            if (paciente.Genero != "M" && paciente.Genero != "F")
                throw new ArgumentException("Seleccione el género del paciente.");
            if (string.IsNullOrWhiteSpace(paciente.TipoSangre))
                throw new ArgumentException("Seleccione el tipo de sangre del paciente.");
            if (paciente.FechaNacimiento.Date > DateTime.Today)
                throw new ArgumentException("La fecha de nacimiento no puede ser posterior a hoy.");
        }

        public static DataTable ObtenerTodos()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
                using (var adapter = new SqlDataAdapter(SelectAllSql, connection))
                {
                    var pacientes = new DataTable();
                    adapter.Fill(pacientes);
                    return pacientes;
                }
            }
            catch (Exception exception) when (exception is SqlException || exception is InvalidOperationException)
            {
                throw new PacienteQueryException(
                    "No se pudieron cargar los pacientes. Verifique la conexión con la base de datos.", exception);
            }
        }

        public static DataTable Buscar(string nombre, string dpi)
        {
            nombre = (nombre ?? string.Empty).Trim();
            dpi = (dpi ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(nombre) && string.IsNullOrWhiteSpace(dpi))
                return new DataTable();

            try
            {
                using (var connection = new SqlConnection(ConnectionStringLoader.Get("DefaultConnection")))
                using (var command = new SqlCommand(SearchSql, connection))
                {
                    command.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nombre;
                    command.Parameters.Add("@NombreFiltro", SqlDbType.VarChar, 202).Value = "%" + nombre + "%";
                    command.Parameters.Add("@DPI", SqlDbType.VarChar, 20).Value = dpi;
                    command.Parameters.Add("@DPIFiltro", SqlDbType.VarChar, 22).Value = "%" + dpi + "%";

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var pacientes = new DataTable();
                        adapter.Fill(pacientes);
                        return pacientes;
                    }
                }
            }
            catch (Exception exception) when (exception is SqlException || exception is InvalidOperationException)
            {
                throw new PacienteQueryException(
                    "No se pudo realizar la búsqueda. Verifique la conexión con la base de datos.", exception);
            }
        }

        private static object DbValue(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value;
        }
    }
}
