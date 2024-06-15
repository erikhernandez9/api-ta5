using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Evento>> GetEventos()
        {
            return Ok(_eventoService.GetEventos());
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> GetEvento(int id)
        {
            try
            {
                return Ok(_eventoService.GetEvento(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Evento> AddEvento(Evento evento)
        {
            try
            {
                return Ok(_eventoService.AddEvento(evento));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Evento> UpdateEvento(int id, Evento updatedEvento)
        {
            try
            {
                return Ok(_eventoService.UpdateEvento(id, updatedEvento));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEvento(int id)
        {
            try
            {
                _eventoService.DeleteEvento(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
