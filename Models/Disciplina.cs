namespace MyApi.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadParticipantes { get; set; }

        public Disciplina()
        {
            Nombre = ""; // Ejemplo de valor predeterminado
            Descripcion = ""; // Ejemplo de valor predeterminado
        }
    }
}