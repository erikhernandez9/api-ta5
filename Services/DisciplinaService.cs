using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Services
{
    public class DisciplinaService
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

        public Disciplina AddDisciplina(Disciplina disciplina)
        {
            return _dataRepository.AddDisciplina(disciplina);
        }
    }
}