using BlazorApps.Shared.Repositories;
using BlazorServer.Data.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeVisitsController : ControllerBase
    {
        private readonly DataRepository _dataRepository;

        public HomeVisitsController(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet("GetVisits")]
        public async Task<ActionResult<List<HomeVisitRecord>>> GetVisits()
        {
            return await _dataRepository.GetHomeVisits();
        }
        
        [HttpGet("GetVisitStatusList")]
        public async Task<ActionResult<List<VisitStatus>>> GetVisitStatusList()
        {
            return await _dataRepository.GetVisitStatusList();
        }

        [HttpGet("GetVisit/{id:int}")]
        public async Task<ActionResult<HomeVisitRecord?>> GetVisit(int id)
        {
            return await _dataRepository.GetHomeVisit(id);
        }

        [HttpPost("AddVisit")]
        public async Task<ActionResult> AddVisit(HomeVisitRecord visit)
        {
            await _dataRepository.AddHomeVisit(visit);
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
            await _dataRepository.UpdateHomeVisit(visit);
            return NoContent();
        }

        [HttpDelete("DeleteVisit/{id:int}")]
        public async Task<ActionResult> DeleteVisit(int id)
        {
            var visit = await _dataRepository.GetHomeVisit(id);
            if (visit is null)
            {
                return NotFound();
            }

            await _dataRepository.RemoveHomeVisit(visit);
            return NoContent();
        }

        private async Task<bool> VisitRecordExists(int id)
        {
            var visit = await _dataRepository.GetHomeVisit(id);
            return visit is not null;
        }
    }
}
