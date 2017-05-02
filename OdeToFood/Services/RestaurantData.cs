using OdeToFood.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

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

        // Method that will return only 1 restaurant
        Restaurant Get(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        /// <summary>
        /// Constructor to create 3 Restaurants.
        /// Simulate a database
        /// </summary>
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "The House of Kobe"},
                new Restaurant {Id = 2, Name = "LJ's and the Kat"},
                new Restaurant {Id = 3, Name = "King's Contrivance"}
            };
        }

        /// <summary>
        /// Returns our private list of restaurants
        /// </summary>
        /// <returns>/returns>
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        /// <summary>
        /// Return a restaurant object by using a Linq query.
        /// Find the restaurant by the id that was passed in as a param
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        // List to hold restaurants
        List<Restaurant> _restaurants;
    }
}
