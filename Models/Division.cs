namespace MyApi.Models
{
    public class Division
    {
        public string Nomnbre { get; set; }
        public string Sexo { get; set; }
        public string Tipo { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}