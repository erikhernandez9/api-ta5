// Controllers/EventosController.cs
using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public EventosController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Evento>> GetEventos()
        {
            return Ok(_dataRepository.GetEventos());
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> GetEvento(int id)
        {
            var evento = _dataRepository.GetEventos().FirstOrDefault(e => e.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            return evento;
        }
    }
}