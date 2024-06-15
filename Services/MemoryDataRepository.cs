using MyApi.Interfaces;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Services
{
    public class MemoryDataRepository : IDataRepository
    {
        private readonly List<Disciplina> _disciplinas;
        private readonly List<Equipo> _equipos;
        private readonly List<Evento> _eventos;
        private readonly List<Juez> _jueces;
        private readonly List<Participante> _participantes;
        private readonly Random _random;

        public MemoryDataRepository()
        {
            _random = new Random();

            _disciplinas = new List<Disciplina>
            {
                new Disciplina { Id = 1, Nombre = "Futbol", Descripcion = "Se corre muchoo", CantidadParticipantes = 10 },
                new Disciplina { Id = 2, Nombre = "Natación", Descripcion = "Tenes que nadar", CantidadParticipantes = 8 }
            };

            _equipos = new List<Equipo>
            {
                new Equipo { Id = 3, Nombre = "Equipo A", Integrantes = new List<Participante>() },
                new Equipo { Id = 4, Nombre = "Equipo B", Integrantes = new List<Participante>() }
            };

            _eventos = new List<Evento>
            {
                new Evento { Id = 5, Nombre = "100m Carrera", Disciplina = _disciplinas[0], Date = DateTime.Now, Equipos = _equipos, Jueces = new List<Juez>() }
            };

            _jueces = new List<Juez>
            {
                new Juez { Id = 5, Nombre = "Juez 1" },
                new Juez { Id = 6, Nombre = "Juez 2" }
            };

            _participantes = new List<Participante>
            {
                new Participante { Id = 5, Nombre = "Participante 1" },
                new Participante { Id = 6, Nombre = "Participante 2" }
            };
        }

        public IEnumerable<Disciplina> GetDisciplinas() => _disciplinas;
        public IEnumerable<Equipo> GetEquipos() => _equipos;
        public IEnumerable<Evento> GetEventos() => _eventos;
        public IEnumerable<Juez> GetJueces() => _jueces;
        public IEnumerable<Participante> GetParticipantes() => _participantes;

        public Disciplina AddDisciplina(Disciplina disciplina)
        {
            disciplina.Id = GenerateRandomId();
            _disciplinas.Add(disciplina);
            return disciplina;
        }

        public Equipo AddEquipo(Equipo equipo)
        {
            equipo.Id = GenerateRandomId();
            _equipos.Add(equipo);
            return equipo;
        }

        public Evento AddEvento(Evento evento)
        {
            evento.Id = GenerateRandomId();
            _eventos.Add(evento);
            return evento;
        }

        public Juez AddJuez(Juez juez)
        {
            juez.Id = GenerateRandomId();
            _jueces.Add(juez);
            return juez;
        }

        public Participante AddParticipante(Participante participante)
        {
            participante.Id = GenerateRandomId();
            _participantes.Add(participante);
            return participante;
        }

        private int GenerateRandomId()
        {
            int id;
            do
            {
                id = _random.Next(1, int.MaxValue);
            } while (_disciplinas.Any(d => d.Id == id) ||
                     _equipos.Any(e => e.Id == id) ||
                     _eventos.Any(ev => ev.Id == id) ||
                     _jueces.Any(j => j.Id == id) ||
                     _participantes.Any(p => p.Id == id));
            return id;
        }
    }
}
