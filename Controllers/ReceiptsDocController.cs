using ApiForTest.Models;
using ApiForTest.Services.ReceiptsDocServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiForTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptsDocController : ControllerBase
    {
        private readonly IReceiptsDocServices _receiptsDocServices;

        public ReceiptsDocController(IReceiptsDocServices receiptsDocServices)
        {
             _receiptsDocServices = receiptsDocServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetAll()
        {
            var result = await _receiptsDocServices.GetAllReceiptsDoc();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Unit?>> GetById(int id)
        {
            return Ok(await _receiptsDocServices.GetReceiptsDocById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReceiptsDoc receiptsDoc)
        {
            var id = await _receiptsDocServices.PostReceiptsDoc(receiptsDoc);
            return Ok(new { id });
        }

        [HttpPut("updateUnit/{id}")]
        public async Task<IActionResult> Apdate(int id, ReceiptsDoc receiptsDoc)
        {
            await _receiptsDocServices.PutReceiptsDoc(id, receiptsDoc);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _receiptsDocServices.DeleteReceiptsDoc(id);
            return NoContent();
        }
    }
}
