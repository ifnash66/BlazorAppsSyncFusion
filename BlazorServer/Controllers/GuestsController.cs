using BlazorApps.Shared;
using BlazorApps.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly DataService _dataService;

        public GuestsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("GetGuests")]
        public async Task<ActionResult<List<GuestRecord>>> GetGuests()
        {
            return await _dataService.GetGuests();
        }
        
        [HttpGet("GetGenderList")]
        public async Task<ActionResult<List<Gender>>> GetGenderList()
        {
            return await _dataService.GetGenderList();
        }

        [HttpGet("GetGuest/{id:int}")]
        public async Task<ActionResult<GuestRecord?>> GetGuest(int id)
        {
            return await _dataService.GetGuest(id);
        }

        [HttpPost("AddGuest")]
        public async Task<ActionResult> AddGuest(GuestRecord guestRecord)
        {
            await _dataService.AddGuest(guestRecord);
            return CreatedAtAction("GetGuest", new { id = guestRecord.Id }, guestRecord);
        }
        
        [HttpPut("UpdateGuest/{id:int}")]
        public async Task<ActionResult> UpdateGuest(int id, GuestRecord guestRecord)
        {
            if (id != guestRecord.Id)
            {
                return BadRequest();
            }
            if (!await GuestRecordExists(id))
            {
                return NotFound();
            }
            await _dataService.UpdateGuest(guestRecord);
            return NoContent();
        }
        
        [HttpDelete("DeleteGuest/{id:int}")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            var guest = await _dataService.GetGuest(id);
            if (guest is null)
            {
                return NotFound();
            }

            await _dataService.RemoveGuest(guest);
            return NoContent();
        }

        private async Task<bool> GuestRecordExists(int id)
        {
            var guest = await _dataService.GetGuest(id);
            return guest is not null;
        }
    }
}