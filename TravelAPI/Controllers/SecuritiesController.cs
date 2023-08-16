using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TravelAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class SecuritiesController : ControllerBase
    {
        private readonly TravelAPIContext _db;
        IConfiguration configuration;
        public SecuritiesController(TravelAPIContext db, IConfiguration configuration)
        {
            _db = db;
            this.configuration = configuration;
        }


        [AllowAnonymous] 
        [HttpPost("/getToken")]
        public IActionResult GetToken(User user)
        { 
            IActionResult response = Unauthorized();

            User resultUser = _db.Users
                .FirstOrDefault(entity => (entity.UserName == user.UserName && entity.Password == user.Password));

            if(resultUser != null)
        //if (user.UserName == "joydip" && user.Password == "joydip123")
            // if (user.UserName == "joydip" && user.Password == "joydip123")
            {
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                (configuration["Jwt:Key"]);

                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                        // new Claim("Id", Guid.NewGuid().ToString()),
                        // new Claim(JwtRegisteredClaimNames.Jti,
                        // Guid.NewGuid().ToString())
                    }
                );

                var expires = DateTime.UtcNow.AddMinutes(60);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                // var stringToken = tokenHandler.WriteToken(token);
                return Ok(jwtToken);
            }
            return response;
        }

        //GET: api/Destinations
        // [MapToApiVersion("2.0")]

        // [HttpGet]

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

