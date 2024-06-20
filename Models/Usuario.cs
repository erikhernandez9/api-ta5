namespace MyApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public Usuario()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Email = string.Empty;
        }
    }
}