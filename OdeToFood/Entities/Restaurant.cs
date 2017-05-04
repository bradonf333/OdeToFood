namespace OdeToFood.Entities
{
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
        public string Name { get; set; }
    }
}
