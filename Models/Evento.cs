namespace MyApi.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Division Division { get; set; }
        public DateTime Date { get; set; }
        public List<Equipo> Equipos { get; set; }
        public List<Juez> Jueces { get; set; }
    }
}