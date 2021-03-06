﻿using OdeToFood.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace OdeToFood.Services
{
    /// <summary>
    /// Restaurant Data
    /// Interface that is used for adding and viewing restaurants
    /// </summary>
    public interface IRestaurantData
    {
        // Method to enumerate all restaurants
        IEnumerable<Restaurant> GetAll();

        // Method that will return only 1 restaurant
        Restaurant Get(int id);

        // Method that returns a restaurant given a "New Restaurant"
        Restaurant Add(Restaurant newRestaurant);

        // Method that will call Save Changes so that we can save any changes made to the Database
        void Commit();

    }

    /// <summary>
    /// Version 2
    /// ==============================================================
    /// Have our application interact with an SQL Database.
    /// The DbContext passed in will be our OdeToFood database.
    /// 
    /// Abilites:
    /// 1. Add a new restaurant
    /// 2. View all restaurants
    /// 3. View 1 specific restaurant
    /// ==============================================================
    /// </summary>
    public class SqlRestaurantData : IRestaurantData
    {
        // Stores the DbContext from the constructor
        private OdeToFoodDbContext _context;

        /// <summary>
        /// Constructor that gets our DbContext (SQL Database) passed in
        /// </summary>
        /// <param name="context"></param>
        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new Restaurant object to the database
        /// </summary>
        /// <param name="newRestaurant"></param>
        /// <returns></returns>
        public Restaurant Add(Restaurant newRestaurant)
        {
            // Add the newRestaurant to the database.
            // The context is smart enough to know that this is a restaurant object and it goes in the Restaurants table (DbSet<Restaurant>)
            _context.Add(newRestaurant);

            // Return the newly created restaurant.
            return newRestaurant;
        }

        /// <summary>
        /// Method that can be called to save any changes made to the database
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Return a restaurant from our database by using a Linq query.
        /// Find the restaurant by the id that was passed in as a param
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Return our DbSet of Restaurants
        /// (Return the table of Restaurants)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }
    }

    /// <summary>
    /// Version 1 
    /// ==============================================================
    /// Generate some restaurants by default and add them to a list.
    /// This will replicate a database and how you would use the data
    /// from the database. Version 2 will have the database portion.
    /// ==============================================================
    /// </summary>
    public class InMemoryRestaurantData : IRestaurantData
    {
        /// <summary>
        /// Constructor to create 3 Restaurants.
        /// Simulate a database
        /// </summary>
        static InMemoryRestaurantData()
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

        /// <summary>
        /// Adds a new restaurant. Computes a new id for the restaurant.
        /// </summary>
        /// <param name="newRestaurant"></param>
        /// <returns></returns>
        public Restaurant Add(Restaurant newRestaurant)
        {
            // Find the max id from the existing restaurants then add 1 and assign it as the new id
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;

            // Add the new restaurant to the list of restaurants
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public void Commit()
        {
            // ...no op
        }

        // List to hold restaurants
        static List<Restaurant> _restaurants;
    }
}
