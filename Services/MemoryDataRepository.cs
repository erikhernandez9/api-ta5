// Services/MemoryDataRepository.cs
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
            _disciplinas = new List<Disciplina>
            {
                new Disciplina { Id = GenerateRandomId(), Nombre = "Atletismo", Descripcion = "Carreras y saltos", CantidadParticipantes = 10 },
                new Disciplina { Id = GenerateRandomId(), Nombre = "Natación", Descripcion = "Competencias de natación", CantidadParticipantes = 8 }
            };

            _equipos = new List<Equipo>
            {
                new Equipo { Id = GenerateRandomId(), Nombre = "Equipo A", Integrantes = new List<Participante>() },
                new Equipo { Id = GenerateRandomId(), Nombre = "Equipo B", Integrantes = new List<Participante>() }
            };

            _eventos = new List<Evento>
            {
                new Evento { Id = GenerateRandomId(), Nombre = "100m Carrera", Disciplina = _disciplinas[0], Date = DateTime.Now, Equipos = _equipos, Jueces = new List<Juez>() }
            };

            _jueces = new List<Juez>
            {
                new Juez { Id = GenerateRandomId(), Nombre = "Juez 1" },
                new Juez { Id = GenerateRandomId(), Nombre = "Juez 2" }
            };

            _participantes = new List<Participante>
            {
                new Participante { Id = GenerateRandomId(), Nombre = "Participante 1" },
                new Participante { Id = GenerateRandomId(), Nombre = "Participante 2" }
            };

            _random = new Random();
        }

        public IEnumerable<Disciplina> GetDisciplinas() => _disciplinas;
        public IEnumerable<Equipo> GetEquipos() => _equipos;
        public IEnumerable<Evento> GetEventos() => _eventos;
        public IEnumerable<Juez> GetJueces() => _jueces;
        public IEnumerable<Participante> GetParticipantes() => _participantes;

        public void AddDisciplina(Disciplina disciplina)
        {
            disciplina.Id = GenerateRandomId();
            _disciplinas.Add(disciplina);
        }

        public void AddEquipo(Equipo equipo)
        {
            equipo.Id = GenerateRandomId();
            _equipos.Add(equipo);
        }

        public void AddEvento(Evento evento)
        {
            evento.Id = GenerateRandomId();
            _eventos.Add(evento);
        }

        public void AddJuez(Juez juez)
        {
            juez.Id = GenerateRandomId();
            _jueces.Add(juez);
        }

        public void AddParticipante(Participante participante)
        {
            participante.Id = GenerateRandomId();
            _participantes.Add(participante);
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
