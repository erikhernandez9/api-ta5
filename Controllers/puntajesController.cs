using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntajesController : ControllerBase
    {
        private readonly IPuntajeService _puntajeService;

        public PuntajesController(IPuntajeService puntajeService)
        {
            _puntajeService = puntajeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Puntaje>> GetPuntajes()
        {
            return Ok(_puntajeService.GetPuntajes());
        }

        [HttpGet("{id}")]
        public ActionResult<Puntaje> GetPuntaje(int id)
        {
            try
            {
                return Ok(_puntajeService.GetPuntaje(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Puntaje> AddPuntaje([FromBody] Puntaje puntaje)
        {
            try
            {
                return Ok(_puntajeService.AddPuntaje(puntaje));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Puntaje> UpdatePuntaje(int id, [FromBody] Puntaje puntaje)
        {
            try
            {
                return Ok(_puntajeService.UpdatePuntaje(id, puntaje));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePuntaje(int id)
        {
            try
            {
                _puntajeService.DeletePuntaje(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
