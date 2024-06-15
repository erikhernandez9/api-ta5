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
            return _dataRepository.GetEquipos().FirstOrDefault(e => e.Id == id);
        }

        public Equipo AddEquipo(Equipo equipo)
        {
            foreach (var participante in equipo.Integrantes)
            {
                var existingParticipante = _dataRepository.GetParticipantes().FirstOrDefault(p => p.Id == participante.Id);
                if (existingParticipante == null)
                {
                    throw new ArgumentException($"El participante con ID {participante.Id} no esta registrado como un participante.");
                }
            }

            // Agregar equipo
            return _dataRepository.AddEquipo(equipo);
        }
    }
}
