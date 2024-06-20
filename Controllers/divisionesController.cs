using Microsoft.AspNetCore.Mvc;
using MyApi.Interfaces;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionesController : ControllerBase
    {
        private readonly IDivisionService _divisionService;

        public DivisionesController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Division>> GetDivisiones()
        {
            return Ok(_divisionService.GetDivisiones());
        }

        [HttpGet("{id}")]
        public ActionResult<Division> GetDivision(int id)
        {
            try
            {
                return Ok(_divisionService.GetDivision(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Division> AddDivision([FromBody] Division division)
        {
            try
            {
                return Ok(_divisionService.AddDivision(division));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Division> UpdateDivision(int id, [FromBody] Division division)
        {
            try
            {
                return Ok(_divisionService.UpdateDivision(id, division));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDivision(int id)
        {
            try
            {
                _divisionService.DeleteDivision(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
