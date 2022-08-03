using BlazorApps.Shared;
using BlazorApps.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeVisitsController : ControllerBase
    {
        private readonly DataService _dataService;

        public HomeVisitsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("GetVisits")]
        public async Task<ActionResult<List<HomeVisitRecord>>> GetVisits()
        {
            return await _dataService.GetHomeVisits();
        }
        
        [HttpGet("GetVisitStatusList")]
        public async Task<ActionResult<List<VisitStatus>>> GetVisitStatusList()
        {
            return await _dataService.GetVisitStatusList();
        }

        [HttpGet("GetVisit/{id:int}")]
        public async Task<ActionResult<HomeVisitRecord?>> GetVisit(int id)
        {
            return await _dataService.GetHomeVisit(id);
        }

        [HttpPost("AddVisit")]
        public async Task<ActionResult> AddVisit(HomeVisitRecord visit)
        {
            await _dataService.AddHomeVisit(visit);
            return CreatedAtAction("GetVisit", new { id = visit.Id }, visit);
        }
        
        [HttpPut("UpdateVisit/{id:int}")]
        public async Task<ActionResult> UpdateVisit(int id, HomeVisitRecord visit)
        {
            if (id != visit.Id)
            {
                return BadRequest();
            }
            if (!await VisitRecordExists(id))
            {
                return NotFound();
            }
            await _dataService.UpdateHomeVisit(visit);
            return NoContent();
        }

        [HttpDelete("DeleteVisit/{id:int}")]
        public async Task<ActionResult> DeleteVisit(int id)
        {
            var visit = await _dataService.GetHomeVisit(id);
            if (visit is null)
            {
                return NotFound();
            }

            await _dataService.RemoveHomeVisit(visit);
            return NoContent();
        }

        private async Task<bool> VisitRecordExists(int id)
        {
            var visit = await _dataService.GetHomeVisit(id);
            return visit is not null;
        }
    }
}
