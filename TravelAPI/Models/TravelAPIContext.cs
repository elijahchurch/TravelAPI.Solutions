using Microsoft.EntityFrameworkCore;

namespace TravelAPI.Models
{
    public class TravelAPIContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<User> Users { get; set;}
        public TravelAPIContext(DbContextOptions<TravelAPIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>()
                .HasData(
                    new Destination { DestinationId = 1, CityName = "Bend", Country = "United States", Review = "Nice sunny vaction spot", Rating = 9},
                    new Destination { DestinationId = 2, CityName = "Sayulita", Country = "Mexico", Review = "Surf vacation spot", Rating = 8}, 
                    new Destination { DestinationId = 3, CityName = "Osaka", Country="Japan", Review = "Great place to see Japanese food spots and culture", Rating = 10}, 
                    new Destination { DestinationId = 4, CityName = "Alicante", Country="Spain", Review = "Good food and great flamenco", Rating = 8} 
                );
        }



    }
}