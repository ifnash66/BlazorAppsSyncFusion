using BlazorApps.Shared.Repositories;
using BlazorServer.Data.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostsController : ControllerBase
    {
        private readonly DataRepository _dataRepository;

        public HostsController(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet("GetHosts")]
        public async Task<ActionResult<List<HostRecord>>> GetHosts()
        {
            return await _dataRepository.GetHosts();
        }

        [HttpGet("GetHost/{id:int}")]
        public async Task<ActionResult<HostRecord?>> GetHost(int id)
        {
            return await _dataRepository.GetHost(id);
        }

        [HttpPost("AddHost")]
        public async Task<ActionResult> AddHost(HostRecord hostRecord)
        {
            await _dataRepository.AddHost(hostRecord);
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
            await _dataRepository.UpdateHost(hostRecord);
            return NoContent();
        }

        [HttpDelete("DeleteHost/{id:int}")]
        public async Task<ActionResult> DeleteHost(int id)
        {
            var host = await _dataRepository.GetHost(id);
            if (host is null)
            {
                return NotFound();
            }

            await _dataRepository.RemoveHost(host);
            return NoContent();
        }

        private async Task<bool> HostRecordExists(int id)
        {
            var host = await _dataRepository.GetHost(id);
            return host is not null;
        }
    }
}
