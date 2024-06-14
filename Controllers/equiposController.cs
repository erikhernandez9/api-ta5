using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public EquiposController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Equipo>> GetEquipos()
        {
            return Ok(_dataRepository.GetEquipos());
        }

        [HttpGet("{id}")]
        public ActionResult<Equipo> GetEquipo(int id)
        {
            var equipo = _dataRepository.GetEquipos().FirstOrDefault(e => e.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }
            return equipo;
        }
    }
}
