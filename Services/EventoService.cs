using MyApi.Interfaces;
using MyApi.Models;

namespace MyApi.Services
{
    public class EventoService : IEventoService
    {
        private readonly IDataRepository _dataRepository;

        public EventoService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<Evento> GetEventos()
        {
            return _dataRepository.GetEventos();
        }

        public Evento GetEvento(int id)
        {
            var response = _dataRepository.GetEventos().FirstOrDefault(e => e.Id == id);
            if (response == null)
            {
                throw new ArgumentException($"El evento con ID {id} no existe.");
            }
            return response;
        }

        public Evento AddEvento(Evento evento)
        {
            if (string.IsNullOrEmpty(evento.Nombre) || evento.Disciplina == null)
            {
                throw new ArgumentException("El nombre y la disciplina del evento son obligatorios.");
            }

            return _dataRepository.AddEvento(evento);
        }

        public Evento UpdateEvento(int id, Evento updatedEvento)
        {
            var existingEvento = GetEvento(id);
            if (updatedEvento.Nombre == null && updatedEvento.Disciplina == null && updatedEvento.Date == DateTime.MinValue)
            {
                throw new ArgumentException("Se debe proporcionar al menos un campo para actualizar.");
            }

            if (!string.IsNullOrEmpty(updatedEvento.Nombre))
            {
                existingEvento.Nombre = updatedEvento.Nombre;
            }

            if (updatedEvento.Disciplina != null)
            {
                existingEvento.Disciplina = updatedEvento.Disciplina;
            }

            if (updatedEvento.Date != DateTime.MinValue)
            {
                existingEvento.Date = updatedEvento.Date;
            }

            return existingEvento;
        }

        public void DeleteEvento(int id)
        {
            var evento = GetEvento(id);
            _dataRepository.GetEventos().ToList().Remove(evento);
        }
    }
}
