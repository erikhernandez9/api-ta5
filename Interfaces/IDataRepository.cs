using MyApi.Models;

namespace MyApi.Interfaces
{
    public interface IDataRepository
    {
        IEnumerable<Disciplina> GetDisciplinas();
        IEnumerable<Equipo> GetEquipos();
        IEnumerable<Evento> GetEventos();
        IEnumerable<Juez> GetJueces();
        IEnumerable<Participante> GetParticipantes();
        IEnumerable<Puntaje> GetPuntajes();
        IEnumerable<Division> GetDivisiones();
        
        Disciplina AddDisciplina(Disciplina disciplina);
        Equipo AddEquipo(Equipo equipo);
        Evento AddEvento(Evento evento);
        Juez AddJuez(Juez juez);
        Participante AddParticipante(Participante participante);
        Puntaje AddPuntaje(Puntaje puntaje);
        Division AddDivision(Division division);
    }
}
