using ApiForTest.Models;
using ApiForTest.Services.ResourceServices;
using ApiForTest.Services.UnitServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ApiForTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitServices _unitServices;

        public UnitController(IUnitServices unitServices)
        {
            _unitServices = unitServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetAllUnit()
        {
            var result = await _unitServices.GetAllUnit();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Unit?>> GetUnitById(int id)
        {
            return Ok(await _unitServices.GetUnitById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostUnit(Unit unit)
        {
            await _unitServices.PostUnit(unit);
            return Ok();
        }

        [HttpPut("updateUnit/{id}")]
        public async Task<IActionResult> PutUnit(int id, Unit unit)
        {
            await _unitServices.PutUnit(id, unit);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            await _unitServices.DeleteUnit(id);
            return NoContent();
        }

        [HttpGet("archive")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetArchiveUnit()
        {
            var result = await _unitServices.GetArchiveUnit();
            return Ok(result);
        }

        [HttpPut("archiveUnit/{id}")]
        public async Task<IActionResult> DoArchiveUnit(int id)
        {
            await _unitServices.DoArchiveUnit(id);
            return NoContent();
        }
    }
}
