using ApiForTest.Models;
using ApiForTest.Services.ResourceServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ApiForTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceServices _resourceServices;

        public ResourceController(IResourceServices resourceServices)
        {
            _resourceServices = resourceServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetAllResources()
        {
            var result = await _resourceServices.GetAllResources();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource?>> GetResourcesById(int id)
        {
            return Ok(await _resourceServices.GetResourcesById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostResources(Resource resource)
        {
            await _resourceServices.PostResources(resource);
            return Ok();
        }

        [HttpPut("updateResources/{id}")]
        public async Task<IActionResult> PutResources(int id, Resource resource)
        {
            await _resourceServices.PutResources(id, resource);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResources(int id)
        {
            await _resourceServices.DeleteResources(id);
            return NoContent();
        }

        [HttpGet("archive")]
        public async Task<ActionResult<IEnumerable<Resource>>> GetArchiveResources()
        {
            var result = await _resourceServices.GetArchiveResources();
            return Ok(result);
        }

        [HttpPut("archiveResources/{id}")]
        public async Task<IActionResult> DoArchiveResources(int id)
        {
            await _resourceServices.DoArchiveResources(id);
            return NoContent();
        }
    }
}
