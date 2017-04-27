using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    /// <summary>
    /// Restaurant Data
    /// 
    /// Version 1 
    /// ==============================================================
    /// Generate some restaurants by default and add them to a list.
    /// This will replicate a database and how you would use the data
    /// from the database. Version 2 will have the database portion.
    /// ==============================================================
    /// </summary>
    public interface IRestaurantData
    {
        // Method to enumerate all restaurants
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "The House of Kobe"},
                new Restaurant {Id = 2, Name = "LJ's and the Kat"},
                new Restaurant {Id = 3, Name = "King's Contrivance"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        // List to hold restaurants
        List<Restaurant> _restaurants;
    }
}
