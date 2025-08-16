using ApiForTest.Models;
using ApiForTest.Services.ReceiptsDocServices;
using ApiForTest.Services.ReceiptsResourceServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiForTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptsResourceController : ControllerBase
    {
        private readonly IReceiptsResourceServices _receiptsResourceServices;

        public ReceiptsResourceController(IReceiptsResourceServices receiptsResourceServices)
        {
            _receiptsResourceServices = receiptsResourceServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptsResource>>> GetAll()
        {
            var result = await _receiptsResourceServices.GetAllReceiptRes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptsResource?>> GetById(int id)
        {
            var r = await _receiptsResourceServices.GetReceiptResById(id);
            return Ok(r);
        }

        [HttpGet("GetID/{id}")]
        public async Task<ActionResult<ReceiptsResource?>> GetID(int id)
        {
            return Ok(await _receiptsResourceServices.GetIDReceiptResById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReceiptsResource receiptsResource)
        {
            await _receiptsResourceServices.PostReceiptRes(receiptsResource);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReceiptsResource receiptsDoc)
        {
            await _receiptsResourceServices.PutReceiptRes(id, receiptsDoc);
            return NoContent();
        }

        [HttpGet("filterDate")]
        public async Task<ActionResult<IEnumerable<Result>>> FilterDate(DateOnly startDate, DateOnly endDate)
        {
            var result = await _receiptsResourceServices.FilterDate(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("filterNumberReceipts")]
        public async Task<ActionResult<IEnumerable<Result>>> FilterReceipts(int receiptsDocId)
        {
            var result = await _receiptsResourceServices.FilterReceipts(receiptsDocId);
            return Ok(result);
        }

        [HttpGet("filterResource")]
        public async Task<ActionResult<IEnumerable<Result>>> FilterResource(string resourceName)
        {
            var result = await _receiptsResourceServices.FilterResource(resourceName);
            return Ok(result);
        }

        [HttpGet("filterUnit")]
        public async Task<ActionResult<IEnumerable<Result>>> FilterUnit(string unitName)
        {
            var result = await _receiptsResourceServices.FilterUnit(unitName);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceiptRes(int id)
        {
            await _receiptsResourceServices.DeleteReceiptRes(id);
            return NoContent();
        }
    }
}
