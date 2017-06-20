using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Entities
{
    public class OdeToFoodDbContext : IdentityDbContext
    {
        // Constructor that passes the DbContext options to the base class
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {

        }

        // DbSet for Restaurants. Will relate to a table named Restaurants
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
