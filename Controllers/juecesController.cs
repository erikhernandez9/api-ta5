using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuecesController : ControllerBase
    {
        private readonly IJuezService _juezService;

        public JuecesController(IJuezService juezService)
        {
            _juezService = juezService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Juez>> GetJueces()
        {
            return Ok(_juezService.GetJueces());
        }

        [HttpGet("{id}")]
        public ActionResult<Juez> GetJuez(int id)
        {
            try
            {
                return Ok(_juezService.GetJuez(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Juez> AddJuez(Juez juez)
        {
            try
            {
                return Ok(_juezService.AddJuez(juez));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Juez> UpdateJuez(int id, Juez updatedJuez)
        {
            try
            {
                return Ok(_juezService.UpdateJuez(id, updatedJuez));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJuez(int id)
        {
            try
            {
                _juezService.DeleteJuez(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
