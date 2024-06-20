using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Services
{
    public class PuntajeService : IPuntajeService
    {
        private readonly IDataRepository _dataRepository;

        public PuntajeService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<Puntaje> GetPuntajes()
        {
            return _dataRepository.GetPuntajes();
        }

        public Puntaje GetPuntaje(int id)
        {
            var response = _dataRepository.GetPuntajes().FirstOrDefault(p => p.Id == id);
            if (response == null)
            {
                throw new ArgumentException($"El puntaje con ID {id} no existe.");
            }
            return response;
        }

        public Puntaje AddPuntaje(Puntaje puntaje)
        {
            var existingParticipante = _dataRepository.GetParticipantes().FirstOrDefault(p => p.Id == puntaje.ParticipanteId);
            if (existingParticipante == null)
            {
                throw new ArgumentException($"El participante con ID {puntaje.ParticipanteId} no está registrado como un participante.");
            }

            var existingJuez = _dataRepository.GetJueces().FirstOrDefault(j => j.Id == puntaje.JuezId);
            if (existingJuez == null)
            {
                throw new ArgumentException($"El juez con ID {puntaje.JuezId} no está registrado como un juez.");
            }

            var existingEvento = _dataRepository.GetEventos().FirstOrDefault(e => e.Id == puntaje.Evento);
            if (existingEvento == null)
            {
                throw new ArgumentException($"El evento con ID {puntaje.Evento} no está registrado como un evento.");
            }

            return _dataRepository.AddPuntaje(puntaje);
        }

        public Puntaje UpdatePuntaje(int id, Puntaje updatedPuntaje)
        {
            var existingPuntaje = GetPuntaje(id);
            if (updatedPuntaje.Puntos == 0 && updatedPuntaje.ParticipanteId == 0 && updatedPuntaje.JuezId == 0 && updatedPuntaje.Evento == 0)
            {
                throw new ArgumentException("Se debe proporcionar al menos un campo para actualizar.");
            }

            if (updatedPuntaje.Puntos != 0)
            {
                existingPuntaje.Puntos = updatedPuntaje.Puntos;
            }

            if (updatedPuntaje.ParticipanteId != 0)
            {
                var existingParticipante = _dataRepository.GetParticipantes().FirstOrDefault(p => p.Id == updatedPuntaje.ParticipanteId);
                if (existingParticipante == null)
                {
                    throw new ArgumentException($"El participante con ID {updatedPuntaje.ParticipanteId} no está registrado como un participante.");
                }
                existingPuntaje.ParticipanteId = updatedPuntaje.ParticipanteId;
            }

            if (updatedPuntaje.JuezId != 0)
            {
                var existingJuez = _dataRepository.GetJueces().FirstOrDefault(j => j.Id == updatedPuntaje.JuezId);
                if (existingJuez == null)
                {
                    throw new ArgumentException($"El juez con ID {updatedPuntaje.JuezId} no está registrado como un juez.");
                }
                existingPuntaje.JuezId = updatedPuntaje.JuezId;
            }

            if (updatedPuntaje.Evento != 0)
            {
                var existingEvento = _dataRepository.GetEventos().FirstOrDefault(e => e.Id == updatedPuntaje.Evento);
                if (existingEvento == null)
                {
                    throw new ArgumentException($"El evento con ID {updatedPuntaje.Evento} no está registrado como un evento.");
                }
                existingPuntaje.Evento = updatedPuntaje.Evento;
            }

            return existingPuntaje;
        }

        public void DeletePuntaje(int id)
        {
            var puntaje = GetPuntaje(id);
            _dataRepository.GetPuntajes().ToList().Remove(puntaje);
        }
    }
}