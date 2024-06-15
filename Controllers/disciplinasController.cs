// Controllers/DisciplinasController.cs
using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinasController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Disciplina>> GetDisciplinas()
        {
            return Ok(_disciplinaService.GetDisciplinas());
        }

        [HttpGet("{id}")]
        public ActionResult<Disciplina> GetDisciplina(int id)
        {
            try
            {
                return Ok(_disciplinaService.GetDisciplina(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Disciplina> AddDisciplina(Disciplina disciplina)
        {
            try
            {
                return Ok(_disciplinaService.AddDisciplina(disciplina));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Disciplina> UpdateDisciplina(int id, Disciplina updatedDisciplina)
        {
            try
            {
                return Ok(_disciplinaService.UpdateDisciplina(id, updatedDisciplina));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDisciplina(int id)
        {
            try
            {
                _disciplinaService.DeleteDisciplina(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
