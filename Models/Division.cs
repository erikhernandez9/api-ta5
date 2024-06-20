namespace MyApi.Models
{
    public class Division
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Tipo { get; set; }
        public Disciplina Disciplina { get; set; } 
    }
}