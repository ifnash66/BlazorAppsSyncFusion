using BlazorApps.Shared.Repositories;
using BlazorServer.Data.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly DataRepository _dataRepository;

        public GuestsController(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet("GetGuests")]
        public async Task<ActionResult<List<GuestRecord>>> GetGuests()
        {
            return await _dataRepository.GetGuests();
        }
        
        [HttpGet("GetGenderList")]
        public async Task<ActionResult<List<Gender>>> GetGenderList()
        {
            return await _dataRepository.GetGenderList();
        }

        [HttpGet("GetGuest/{id:int}")]
        public async Task<ActionResult<GuestRecord?>> GetGuest(int id)
        {
            return await _dataRepository.GetGuest(id);
        }

        [HttpPost("AddGuest")]
        public async Task<ActionResult> AddGuest(GuestRecord guestRecord)
        {
            await _dataRepository.AddGuest(guestRecord);
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
            await _dataRepository.UpdateGuest(guestRecord);
            return NoContent();
        }
        
        [HttpDelete("DeleteGuest/{id:int}")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            var guest = await _dataRepository.GetGuest(id);
            if (guest is null)
            {
                return NotFound();
            }

            await _dataRepository.RemoveGuest(guest);
            return NoContent();
        }

        private async Task<bool> GuestRecordExists(int id)
        {
            var guest = await _dataRepository.GetGuest(id);
            return guest is not null;
        }
    }
}