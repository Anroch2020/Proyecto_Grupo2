namespace Proyecto_Grupo2.Modelos
{
    public sealed class AuthUser
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public byte[] Template { get; set; }
    }
}
