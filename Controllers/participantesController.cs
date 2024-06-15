using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly IParticipanteService _participanteService;

        public ParticipantesController(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Participante>> GetParticipantes()
        {
            return Ok(_participanteService.GetParticipantes());
        }

        [HttpGet("{id}")]
        public ActionResult<Participante> GetParticipante(int id)
        {
            try
            {
                return Ok(_participanteService.GetParticipante(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Participante> AddParticipante(Participante participante)
        {
            try
            {
                return Ok(_participanteService.AddParticipante(participante));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Participante> UpdateParticipante(int id, Participante updatedParticipante)
        {
            try
            {
                return Ok(_participanteService.UpdateParticipante(id, updatedParticipante));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteParticipante(int id)
        {
            try
            {
                _participanteService.DeleteParticipante(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
