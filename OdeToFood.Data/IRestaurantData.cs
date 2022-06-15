using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Fratelli Pizza", Location = "Miami", Cuisine = CuisineType.Italian },
                new Restaurant{ Id = 2, Name = "Tacos", Location = "Tampa", Cuisine = CuisineType.Mexican },
                new Restaurant{ Id = 3, Name = "Lions Den", Location = "Weston", Cuisine = CuisineType.Indian },

            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, true, null)
                   orderby r.Id
                   select r;
        }
    }
}
