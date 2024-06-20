namespace MyApi.Models
{
    public class Puntaje
    {
        public int Id { get; set; }
        public int Puntos { get; set; }
        public int ParticipanteId { get; set; }
        public int JuezId { get; set; }
        public int Evento { get; set; }
    }
}