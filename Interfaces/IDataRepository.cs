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
        
        void AddDisciplina(Disciplina disciplina);
        void AddEquipo(Equipo equipo);
        void AddEvento(Evento evento);
        void AddJuez(Juez juez);
        void AddParticipante(Participante participante);
    }
}
