// Controllers/EquiposController.cs
using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;

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
            var equipo = _equipoService.GetEquipo(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return equipo;
        }

        [HttpPost]
        public ActionResult<Equipo> AddEquipo(Equipo equipo)
        {
            try
            {
                var newEquipo = _equipoService.AddEquipo(equipo);
                return CreatedAtAction(nameof(GetEquipo), new { id = newEquipo.Id }, newEquipo);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
