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
        private readonly List<Puntaje> _puntajes;
        private readonly List<Division> _divisiones;
        private readonly Random _random;

        public MemoryDataRepository()
        {
            _random = new Random();

            _disciplinas = new List<Disciplina>
            {
                new Disciplina { Id = 1, Nombre = "Futbol", Descripcion = "Se corre mucho", CantidadParticipantes = 10 },
                new Disciplina { Id = 2, Nombre = "Natación", Descripcion = "Tienes que nadar", CantidadParticipantes = 8 }
            };

            _equipos = new List<Equipo>
            {
                new Equipo { Id = 3, Nombre = "Equipo A", Integrantes = new List<Participante>() },
                new Equipo { Id = 4, Nombre = "Equipo B", Integrantes = new List<Participante>() }
            };

            _jueces = new List<Juez>
            {
                new Juez { Id = 5, Nombre = "Juez 1", Apellido = "Lopez", Email = "juez1@gmail.com", Expertise = "Natación" },
                new Juez { Id = 6, Nombre = "Juez 2", Apellido = "Lopez", Email = "juez2@gmail.com", Expertise = "Futbol" }
            };

            _participantes = new List<Participante>
            {
                new Participante { Id = 7, Nombre = "Participante 3", Apellido = "Gonzalez", Email = "participante3@gmail.com", Pais = "Argentina" },
                new Participante { Id = 8, Nombre = "Participante 4", Apellido = "Gonzalez", Email = "participante4@gmail.com", Pais = "Brasil" }
            };

            _divisiones = new List<Division>
            {
                new Division { Id = 1, Nombre = "División 1", Sexo = "Masculino", Tipo = "Tipo 1", Disciplina = _disciplinas[0] },
                new Division { Id = 2, Nombre = "División 2", Sexo = "Femenino", Tipo = "Tipo 2", Disciplina = _disciplinas[1] }
            };

            _eventos = new List<Evento>
            {
                new Evento { Id = 5, Nombre = "100m Carrera", Division = _divisiones[0], Date = DateTime.Now, Equipos = _equipos, Jueces = new List<Juez>() }
            };

            _puntajes = new List<Puntaje>
            {
                new Puntaje { Id = 1, Puntos = 10, ParticipanteId = _participantes[0].Id, Evento = _eventos[0].Id },
                new Puntaje { Id = 2, Puntos = 8, ParticipanteId = _participantes[1].Id, Evento = _eventos[0].Id }
            };
        }

        public IEnumerable<Disciplina> GetDisciplinas() => _disciplinas;
        public IEnumerable<Equipo> GetEquipos() => _equipos;
        public IEnumerable<Evento> GetEventos() => _eventos;
        public IEnumerable<Juez> GetJueces() => _jueces;
        public IEnumerable<Participante> GetParticipantes() => _participantes;
        public IEnumerable<Puntaje> GetPuntajes() => _puntajes;
        public IEnumerable<Division> GetDivisiones() => _divisiones;

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

        public Puntaje AddPuntaje(Puntaje puntaje)
        {
            puntaje.Id = GenerateRandomId();
            _puntajes.Add(puntaje);
            return puntaje;
        }

        public Division AddDivision(Division division)
        {
            division.Id = GenerateRandomId();
            _divisiones.Add(division);
            return division;
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
                     _participantes.Any(p => p.Id == id) ||
                     _divisiones.Any(di => di.Id == id ));
            return id;
        }
    }
}
