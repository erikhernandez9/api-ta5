using MyApi.Models;

namespace MyApi.Interfaces
{
    public interface IDisciplinaService
    {
        IEnumerable<Disciplina> GetDisciplinas();
        Disciplina GetDisciplina(int id);
        Disciplina AddDisciplina(Disciplina disciplina);
        Disciplina UpdateDisciplina(int id, Disciplina updatedDisciplina);
        void DeleteDisciplina(int id);
    }
}