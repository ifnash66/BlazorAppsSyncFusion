using BlazorApps.Shared;
using BlazorApps.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostsController : ControllerBase
    {
        private readonly DataService _dataService;

        public HostsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("GetHosts")]
        public async Task<ActionResult<List<HostRecord>>> GetHosts()
        {
            return await _dataService.GetHosts();
        }

        [HttpGet("GetHost/{id:int}")]
        public async Task<ActionResult<HostRecord?>> GetHost(int id)
        {
            return await _dataService.GetHost(id);
        }

        [HttpPost("AddHost")]
        public async Task<ActionResult> AddHost(HostRecord hostRecord)
        {
            await _dataService.AddHost(hostRecord);
            return CreatedAtAction("GetHost", new { id = hostRecord.Id }, hostRecord);
        }
        
        [HttpPut("UpdateHost/{id:int}")]
        public async Task<ActionResult> UpdateHost(int id, HostRecord hostRecord)
        {
            if (id != hostRecord.Id)
            {
                return BadRequest();
            }
            if (!await HostRecordExists(id))
            {
                return NotFound();
            }
            await _dataService.UpdateHost(hostRecord);
            return NoContent();
        }

        [HttpDelete("DeleteHost/{id:int}")]
        public async Task<ActionResult> DeleteHost(int id)
        {
            var host = await _dataService.GetHost(id);
            if (host is null)
            {
                return NotFound();
            }

            await _dataService.RemoveHost(host);
            return NoContent();
        }

        private async Task<bool> HostRecordExists(int id)
        {
            var host = await _dataService.GetHost(id);
            return host is not null;
        }
    }
}
