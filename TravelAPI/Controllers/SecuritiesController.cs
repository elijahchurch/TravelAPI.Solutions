using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Models;

namespace TravelAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class SecuritiesController : ControllerBase
    {
        private readonly TravelAPIContext _db;
        public SecuritiesController(TravelAPIContext db)
        {
            _db = db;
        }

        //GET: api/Destinations
        // [MapToApiVersion("2.0")]
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Destination>>> Get(string cityName, string country, int rating, int minimumRating )
        // {
        //     IQueryable<Destination> query = _db.Destinations.AsQueryable();
        //     if (cityName != null)
        //     {
        //         query = query.Where(entry => entry.CityName == cityName);
        //     }
        //     if (country != null)
        //     {
        //         query = query.Where(entry => entry.Country == country);
        //     }
        //     if (rating != 0)
        //     {
        //         query = query.Where(entry => entry.Rating == rating);
        //     }
        //     if (minimumRating > 0)
        //     {
        //         query = query.Where(entry => entry.Rating >= minimumRating);
        //     }
            
            
        //     return await query.ToListAsync();
        // }

       
    }
}

