// Services/EquipoService.cs
using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly IDataRepository _dataRepository;

        public EquipoService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<Equipo> GetEquipos()
        {
            return _dataRepository.GetEquipos();
        }

        public Equipo GetEquipo(int id)
        {
            var response = _dataRepository.GetEquipos().FirstOrDefault(e => e.Id == id);
            if (response == null)
            {
                throw new ArgumentException($"El equipo con ID {id} no existe.");
            }
            return response;
        }

        public Equipo AddEquipo(Equipo equipo)
        {
            foreach (var participante in equipo.Integrantes)
            {
                var existingParticipante = _dataRepository.GetParticipantes().FirstOrDefault(p => p.Id == participante.Id);
                if (existingParticipante == null)
                {
                    throw new ArgumentException($"El participante con ID {participante.Id} no está registrado como un participante.");
                }
            }

            // Agregar equipo
            return _dataRepository.AddEquipo(equipo);
        }

        public Equipo UpdateEquipo(int id, Equipo updatedEquipo)
        {
            var existingEquipo = GetEquipo(id);
            if (updatedEquipo.Nombre == null && (updatedEquipo.Integrantes == null || !updatedEquipo.Integrantes.Any()))
            {
                throw new ArgumentException("Se debe proporcionar al menos un campo para actualizar.");
            }

            if (updatedEquipo.Nombre != null)
            {
                existingEquipo.Nombre = updatedEquipo.Nombre;
            }

            if (updatedEquipo.Integrantes != null && updatedEquipo.Integrantes.Any())
            {
                existingEquipo.Integrantes = updatedEquipo.Integrantes;
            }

            return existingEquipo;
        }

        public void DeleteEquipo(int id)
        {
            var equipo = GetEquipo(id);
            _dataRepository.GetEquipos().ToList().Remove(equipo);
        }

        public Equipo AddIntegrante(int equipoId, Participante integrante)
        {
            var equipo = GetEquipo(equipoId);
            var existingParticipante = _dataRepository.GetParticipantes().FirstOrDefault(p => p.Id == integrante.Id);
            if (existingParticipante == null)
            {
                throw new ArgumentException($"El participante con ID {integrante.Id} no está registrado como un participante.");
            }
            if (equipo.Integrantes.Any(i => i.Id == integrante.Id))
            {
                throw new ArgumentException($"El participante con ID {integrante.Id} ya es un integrante del equipo.");
            }

            equipo.Integrantes.Add(existingParticipante);
            return equipo;
        }

        public Equipo RemoveIntegrante(int equipoId, int participanteId)
        {
            var equipo = GetEquipo(equipoId);
            var integrante = equipo.Integrantes.FirstOrDefault(i => i.Id == participanteId);
            if (integrante == null)
            {
                throw new ArgumentException($"El participante con ID {participanteId} no es un integrante del equipo.");
            }

            equipo.Integrantes.Remove(integrante);
            return equipo;
        }
    }
}
