// Interfaces/IDataRepository.cs
using System.Collections.Generic;
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
        
        Disciplina AddDisciplina(Disciplina disciplina);
        Equipo AddEquipo(Equipo equipo);
        Evento AddEvento(Evento evento);
        Juez AddJuez(Juez juez);
        Participante AddParticipante(Participante participante);
    }
}
