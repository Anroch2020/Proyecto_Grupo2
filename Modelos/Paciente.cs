using System;

namespace Proyecto_Grupo2.Modelos
{
    internal sealed class Paciente
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DPI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string TipoSangre { get; set; }
    }
}
