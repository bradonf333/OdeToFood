using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Entities
{
    /// <summary>
    /// Inherit from the IdentityDbContext and specify the User class so that we can use the Identity Framework
    /// pre-built stuff to store the users information
    /// </summary>
    public class OdeToFoodDbContext : IdentityDbContext<User>
    {
        // Constructor that passes the DbContext options to the base class
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {

        }

        // DbSet for Restaurants. Will relate to a table named Restaurants
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
