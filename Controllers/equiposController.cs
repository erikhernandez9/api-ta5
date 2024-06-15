// Controllers/EquiposController.cs
using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly IEquipoService _equipoService;

        public EquiposController(IEquipoService equipoService)
        {
            _equipoService = equipoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Equipo>> GetEquipos()
        {
            return Ok(_equipoService.GetEquipos());
        }

        [HttpGet("{id}")]
        public ActionResult<Equipo> GetEquipo(int id)
        {
            try
            {
                return Ok(_equipoService.GetEquipo(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Equipo> AddEquipo(Equipo equipo)
        {
            try
            {
                return Ok(_equipoService.AddEquipo(equipo));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Equipo> UpdateEquipo(int id, Equipo updatedEquipo)
        {
            try
            {
                return Ok(_equipoService.UpdateEquipo(id, updatedEquipo));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEquipo(int id)
        {
            try
            {
                _equipoService.DeleteEquipo(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{equipoId}/integrantes")]
        public ActionResult<Equipo> AddIntegrante(int equipoId, Participante integrante)
        {
            try
            {
                return Ok(_equipoService.AddIntegrante(equipoId, integrante));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{equipoId}/integrantes/{participanteId}")]
        public ActionResult<Equipo> RemoveIntegrante(int equipoId, int participanteId)
        {
            try
            {
                return Ok(_equipoService.RemoveIntegrante(equipoId, participanteId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
