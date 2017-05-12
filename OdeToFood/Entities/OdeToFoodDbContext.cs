using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Entities
{
    public class OdeToFoodDbContext : DbContext
    {
        // DbSet for Restaurants. Will relate to a table named Restaurants
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
