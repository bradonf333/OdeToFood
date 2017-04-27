using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        // Method to enumerate all restaurants
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll()
        {
            public InMemoryRestaurantData ()
            {

            }
        }

        // List to hold restaurants
        List<Restaurant> _restaurants;
    }
}
