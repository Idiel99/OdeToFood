using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        [Required, StringLength(80)] // Did not take effect
        public string Name { get; set; }

        [Required, StringLength(255)] // Did not take effect
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }

    }
}
