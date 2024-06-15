using MyApi.Models;

namespace MyApi.Interfaces
{
    public interface IParticipanteService
    {
        IEnumerable<Participante> GetParticipantes();
        Participante GetParticipante(int id);
        Participante AddParticipante(Participante participante);
        Participante UpdateParticipante(int id, Participante updatedParticipante);
        void DeleteParticipante(int id);
    }
}