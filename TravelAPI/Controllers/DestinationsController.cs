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
        
    }

}