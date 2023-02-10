using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedME
{
    public class Dinner
    {
        private string recipe;

        public string Recipe
        {
            get { return recipe; }
            set { recipe = value; }
        }

      

        private string  ingredients;

        public string  Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public Dinner(string recipe, string ingredients)
        {
            Recipe = recipe;
          
            Ingredients = ingredients;
        }   


    }
}
