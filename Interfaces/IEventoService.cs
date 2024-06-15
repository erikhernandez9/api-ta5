using MyApi.Models;

namespace MyApi.Interfaces
{
    public interface IEventoService
    {
        IEnumerable<Evento> GetEventos();
        Evento GetEvento(int id);
        Evento AddEvento(Evento evento);
        Evento UpdateEvento(int id, Evento updatedEvento);
        void DeleteEvento(int id);
    }
}