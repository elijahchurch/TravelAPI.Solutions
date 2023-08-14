using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Models;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly TravelAPIContext _db;
        public DestinationsController(TravelAPIContext db)
        {
            _db = db;
        }

        //GET: api/Destinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> Get()
        {
            return await _db.Destinations.ToListAsync();
        }

        //GET: api/Destinations/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            Destination destination = await _db.Destinations.FindAsync(id);

            if (destination == null)
            {
                return NotFound();
            }
            return destination;

        }

        //Post api/Destinations
        [HttpPost]
        public async Task<ActionResult<Destination>> Post(Destination destination)
        {
            _db.Destinations.Add(destination);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDestination), new { id = destination.DestinationId }, destination);
        }

        // Put: api/Destinations/
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Destination destination)
        {
            if (id != destination.DestinationId)
            {
                return BadRequest();
            }

            _db.Destinations.Update(destination);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationExists(id))
                {
                return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }
        
        private bool DestinationExists(int id)
        {
            return _db.Destinations.Any(e => e.DestinationId == id);
        }

        // DELETE: api/Destinations/8
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            Destination destination = await _db.Destinations.FindAsync(id);
            if (destination == null)
        {
        return NotFound();
        }

        _db.Destinations.Remove(destination);
        await _db.SaveChangesAsync();

        return NoContent();
        }
    }
}

