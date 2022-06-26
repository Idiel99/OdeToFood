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
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedrestaurant);
        int Commit();
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

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, true, null)
                   orderby r.Id
                   select r;
        }

        public Restaurant Update(Restaurant updatedrestaurant) 
        {
            var restaurant = restaurants.SingleOrDefault( r => r.Id == updatedrestaurant.Id);
            if (restaurant != null)
            {
                   /***************
                    * Manual Check
                    * *************/
                /*if (updatedrestaurant.Name == null || updatedrestaurant.Name.Length < 1 || updatedrestaurant.Name.Length > 80) 
                {
                    updatedrestaurant.Name = "Default";
                }
                if(updatedrestaurant.Location == null || updatedrestaurant.Location.Length < 1 || updatedrestaurant.Location.Length > 255 )
                {
                    updatedrestaurant.Location = "Default";
                }*/


                restaurant.Name     = updatedrestaurant.Name;
                restaurant.Location = updatedrestaurant.Location;
                restaurant.Cuisine  = updatedrestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit() 
        {
            return 0;
        }
    }
}
