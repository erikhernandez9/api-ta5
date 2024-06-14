using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public ParticipantesController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Participante>> GetParticipantes()
        {
            return Ok(_dataRepository.GetParticipantes());
        }

        [HttpGet("{id}")]
        public ActionResult<Participante> GetParticipante(int id)
        {
            var participante = _dataRepository.GetParticipantes().FirstOrDefault(p => p.Id == id);
            if (participante == null)
            {
                return NotFound();
            }
            return participante;
        }
    }
}
