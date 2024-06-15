using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Interfaces;
using System;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        // Simulación de datos hardcodeados

        public DisciplinasController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        private static readonly List<Disciplina> disciplinas = new List<Disciplina>
        {
        };

        // GET: api/Disciplinas
        [HttpGet]
        public ActionResult<IEnumerable<Disciplina>> GetDisciplinas()
        {
            var disciplinas =_dataRepository.GetDisciplinas();
            return Ok(disciplinas);
        }

        // GET: api/Disciplinas/5
        [HttpGet("{id}")]
        public ActionResult<Disciplina> GetDisciplina(int id)
        {
            var disciplina = disciplinas.Find(d => d.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }
            return Ok(disciplina);
        }

        // POST: api/Disciplinas
        [HttpPost]
        public ActionResult<Disciplina> CreateDisciplina(Disciplina disciplina)
        {
            var response = _dataRepository.AddDisciplina(disciplina);
            return response;
        }

        // PUT: api/Disciplinas/5
        [HttpPut("{id}")]
        public IActionResult UpdateDisciplina(int id, Disciplina updatedDisciplina)
        {
            var disciplina = disciplinas.Find(d => d.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            disciplina.Nombre = updatedDisciplina.Nombre;
            disciplina.Descripcion = updatedDisciplina.Descripcion;
            disciplina.CantidadParticipantes = updatedDisciplina.CantidadParticipantes;

            return NoContent();
        }

        // DELETE: api/Disciplinas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDisciplina(int id)
        {
            var disciplina = disciplinas.Find(d => d.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            disciplinas.Remove(disciplina);
            return NoContent();
        }
    }
}