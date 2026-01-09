using CarsAnalytics.ExperienceApi.Dto;
using CarsAnalytics.ExperienceApi.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using APIResponseWrapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsAnalytics.ExperienceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoriesController(ITerritoryService service) : ControllerBase
    {
        [HttpGet("{regionCode}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns list of territories", typeof(ApiResponse<IEnumerable<TerritoryDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Region code is required or invalid")]
        public async Task<IActionResult> Get(string regionCode, CancellationToken ct) 
        { 
            var data = await service.GetAsync(regionCode, ct);
            return StatusCode((int)data.StatusCode, data);
        }

        // POST api/<TerritoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TerritoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TerritoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
