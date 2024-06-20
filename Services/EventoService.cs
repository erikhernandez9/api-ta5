using MyApi.Interfaces;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Evento> GetEventosByDivision(int divisionId)
        {
            var eventos = _dataRepository.GetEventos().Where(e => e.Division.Id == divisionId).ToList();
            if (!eventos.Any())
            {
                throw new ArgumentException($"No existen eventos para la división con ID {divisionId}.");
            }
            return eventos;
        }

        public Evento AddEvento(Evento evento)
        {
            if (string.IsNullOrEmpty(evento.Nombre) || evento.Division == null)
            {
                throw new ArgumentException("El nombre y la disciplina del evento son obligatorios.");
            }

            return _dataRepository.AddEvento(evento);
        }

        public Evento UpdateEvento(int id, Evento updatedEvento)
        {
            var existingEvento = GetEvento(id);
            if (updatedEvento.Nombre == null && updatedEvento.Division == null && updatedEvento.Date == DateTime.MinValue)
            {
                throw new ArgumentException("Se debe proporcionar al menos un campo para actualizar.");
            }

            if (!string.IsNullOrEmpty(updatedEvento.Nombre))
            {
                existingEvento.Nombre = updatedEvento.Nombre;
            }

            if (updatedEvento.Division != null)
            {
                existingEvento.Division = updatedEvento.Division;
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