using MyApi.Interfaces;
using MyApi.Models;

namespace MyApi.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDataRepository _dataRepository;

        public DisciplinaService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<Disciplina> GetDisciplinas()
        {
            return _dataRepository.GetDisciplinas();
        }

        public Disciplina GetDisciplina(int id)
        {
            var response = _dataRepository.GetDisciplinas().FirstOrDefault(d => d.Id == id);
            if (response == null)
            {
                throw new ArgumentException($"La disciplina con ID {id} no existe.");
            }
            return response;
        }

        public Disciplina AddDisciplina(Disciplina disciplina)
        {
            if (string.IsNullOrEmpty(disciplina.Nombre) || string.IsNullOrEmpty(disciplina.Descripcion))
            {
                throw new ArgumentException("El nombre y la descripción de la disciplina son obligatorios.");
            }

            return _dataRepository.AddDisciplina(disciplina);
        }

        public Disciplina UpdateDisciplina(int id, Disciplina updatedDisciplina)
        {
            var existingDisciplina = GetDisciplina(id);
            if (updatedDisciplina.Nombre == null && updatedDisciplina.Descripcion == null && updatedDisciplina.CantidadParticipantes == 0)
            {
                throw new ArgumentException("Se debe proporcionar al menos un campo para actualizar.");
            }

            if (!string.IsNullOrEmpty(updatedDisciplina.Nombre))
            {
                existingDisciplina.Nombre = updatedDisciplina.Nombre;
            }

            if (!string.IsNullOrEmpty(updatedDisciplina.Descripcion))
            {
                existingDisciplina.Descripcion = updatedDisciplina.Descripcion;
            }

            if (updatedDisciplina.CantidadParticipantes > 0)
            {
                existingDisciplina.CantidadParticipantes = updatedDisciplina.CantidadParticipantes;
            }

            return existingDisciplina;
        }

        public void DeleteDisciplina(int id)
        {
            var disciplina = GetDisciplina(id);
            _dataRepository.GetDisciplinas().ToList().Remove(disciplina);
        }
    }
}
