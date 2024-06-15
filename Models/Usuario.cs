namespace MyApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Usuario()
        {
            Nombre = string.Empty;
        }
    }
}