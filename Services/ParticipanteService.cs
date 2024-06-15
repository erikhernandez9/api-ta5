using MyApi.Interfaces;
using MyApi.Models;

namespace MyApi.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IDataRepository _dataRepository;

        public ParticipanteService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<Participante> GetParticipantes()
        {
            return _dataRepository.GetParticipantes();
        }

        public Participante GetParticipante(int id)
        {
            var response = _dataRepository.GetParticipantes().FirstOrDefault(p => p.Id == id);
            if (response == null)
            {
                throw new ArgumentException($"El participante con ID {id} no existe.");
            }
            return response;
        }

        public Participante AddParticipante(Participante participante)
        {
            if (string.IsNullOrEmpty(participante.Nombre))
            {
                throw new ArgumentException("El nombre del participante es obligatorio.");
            }

            return _dataRepository.AddParticipante(participante);
        }

        public Participante UpdateParticipante(int id, Participante updatedParticipante)
        {
            var existingParticipante = GetParticipante(id);
            if (string.IsNullOrEmpty(updatedParticipante.Nombre))
            {
                throw new ArgumentException("El nombre del participante es obligatorio.");
            }

            existingParticipante.Nombre = updatedParticipante.Nombre;
            return existingParticipante;
        }

        public void DeleteParticipante(int id)
        {
            var participante = GetParticipante(id);
            _dataRepository.GetParticipantes().ToList().Remove(participante);
        }
    }
}
