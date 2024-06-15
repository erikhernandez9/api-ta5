namespace MyApi.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Participante> Integrantes { get; set; }
    }
}