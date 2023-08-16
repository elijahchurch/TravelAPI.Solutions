using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class DestinationsController : ControllerBase
    {
        private readonly TravelAPIContext _db;
        public DestinationsController(TravelAPIContext db)
        {
            _db = db;
        }

        //GET: api/Destinations
        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> Get(string cityName, string country, int rating, int minimumRating )
        {
            IQueryable<Destination> query = _db.Destinations.AsQueryable();
            if (cityName != null)
            {
                query = query.Where(entry => entry.CityName == cityName);
            }
            if (country != null)
            {
                query = query.Where(entry => entry.Country == country);
            }
            if (rating != 0)
            {
                query = query.Where(entry => entry.Rating == rating);
            }
            if (minimumRating > 0)
            {
                query = query.Where(entry => entry.Rating >= minimumRating);
            }
            
            
            return await query.ToListAsync();
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

