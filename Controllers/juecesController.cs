using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuecesController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public JuecesController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Juez>> GetJueces()
        {
            return Ok(_dataRepository.GetJueces());
        }

        [HttpGet("{id}")]
        public ActionResult<Juez> GetJuez(int id)
        {
            var juez = _dataRepository.GetJueces().FirstOrDefault(j => j.Id == id);
            if (juez == null)
            {
                return NotFound();
            }
            return juez;
        }
    }
}
