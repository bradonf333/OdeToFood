using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Entities
{
    /// <summary>
    /// Enum used to hold the types of Cuisine for the restaurant
    /// </summary>
    public enum CuisineType
    {
         None,
         Italian,
         French,
         Japanese,
         American
    }

    /// <summary>
    /// Simple model of a Restaurant
    /// </summary>
    public class Restaurant
    {
        public int Id { get; set; }

        [Display(Name="Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
