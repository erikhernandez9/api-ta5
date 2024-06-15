using MyApi.Interfaces;
using MyApi.Models;

namespace MyApi.Services
{
    public class JuezService : IJuezService
    {
        private readonly IDataRepository _dataRepository;

        public JuezService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<Juez> GetJueces()
        {
            return _dataRepository.GetJueces();
        }

        public Juez GetJuez(int id)
        {
            var response = _dataRepository.GetJueces().FirstOrDefault(j => j.Id == id);
            if (response == null)
            {
                throw new ArgumentException($"El juez con ID {id} no existe.");
            }
            return response;
        }

        public Juez AddJuez(Juez juez)
        {
            if (string.IsNullOrEmpty(juez.Nombre))
            {
                throw new ArgumentException("El nombre del juez es obligatorio.");
            }

            return _dataRepository.AddJuez(juez);
        }

        public Juez UpdateJuez(int id, Juez updatedJuez)
        {
            var existingJuez = GetJuez(id);
            if (string.IsNullOrEmpty(updatedJuez.Nombre))
            {
                throw new ArgumentException("El nombre del juez es obligatorio.");
            }

            existingJuez.Nombre = updatedJuez.Nombre;
            return existingJuez;
        }

        public void DeleteJuez(int id)
        {
            var juez = GetJuez(id);
            _dataRepository.GetJueces().ToList().Remove(juez);
        }
    }
}
