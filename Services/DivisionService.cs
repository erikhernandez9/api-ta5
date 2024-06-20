using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly IDataRepository _dataRepository;

        public DivisionService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<Division> GetDivisiones()
        {
            return _dataRepository.GetDivisiones();
        }

        public Division GetDivision(int id)
        {
            var response = _dataRepository.GetDivisiones().FirstOrDefault(d => d.Id == id);
            if (response == null)
            {
                throw new ArgumentException($"La división con ID {id} no existe.");
            }
            return response;
        }

        public Division AddDivision(Division division)
        {
            if (string.IsNullOrEmpty(division.Nombre))
            {
                throw new ArgumentException("El nombre es requerido.");
            }

            if (string.IsNullOrEmpty(division.Sexo))
            {
                throw new ArgumentException("El sexo es requerido.");
            }

            if (division.Disciplina == null)
            {
                throw new ArgumentException("La disciplina es requerida.");
            }

            var existingDisciplina = _dataRepository.GetDisciplinas().FirstOrDefault(d => d.Id == division.Disciplina.Id);
            if (existingDisciplina == null)
            {
                throw new ArgumentException($"La disciplina con ID {division.Disciplina.Id} no está registrada.");
            }

            division.Disciplina = existingDisciplina;

            return _dataRepository.AddDivision(division);
        }

        public Division UpdateDivision(int id, Division updatedDivision)
        {
            var existingDivision = GetDivision(id);

            if (string.IsNullOrEmpty(updatedDivision.Nombre) && string.IsNullOrEmpty(updatedDivision.Sexo) && updatedDivision.Disciplina == null && string.IsNullOrEmpty(updatedDivision.Tipo))
            {
                throw new ArgumentException("Se debe proporcionar al menos un campo para actualizar.");
            }

            if (!string.IsNullOrEmpty(updatedDivision.Nombre))
            {
                existingDivision.Nombre = updatedDivision.Nombre;
            }

            if (!string.IsNullOrEmpty(updatedDivision.Sexo))
            {
                existingDivision.Sexo = updatedDivision.Sexo;
            }

            if (updatedDivision.Disciplina != null)
            {
                var existingDisciplina = _dataRepository.GetDisciplinas().FirstOrDefault(d => d.Id == updatedDivision.Disciplina.Id);
                if (existingDisciplina == null)
                {
                    throw new ArgumentException($"La disciplina con ID {updatedDivision.Disciplina.Id} no está registrada.");
                }
                existingDivision.Disciplina = existingDisciplina;
            }

            if (!string.IsNullOrEmpty(updatedDivision.Tipo))
            {
                existingDivision.Tipo = updatedDivision.Tipo;
            }

            return existingDivision;
        }

        public void DeleteDivision(int id)
        {
            var division = GetDivision(id);
            _dataRepository.GetDivisiones().ToList().Remove(division);
        }
    }
}
