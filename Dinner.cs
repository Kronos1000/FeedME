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

        private string recipeBase;

        public string RecipeBase
        {
            get { return recipeBase; }
            set { recipeBase = value; }
        }

        private string  meat;

        public string  Meat
        {
            get { return meat; }
            set { meat = value; }
        }


        private string  ingredients;

        public string  Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public Dinner(string recipe, string recipeBase, string meat, string ingredients)
        {
            Recipe = recipe;
            RecipeBase = recipeBase;
            Meat = meat;
            Ingredients = ingredients;
        }   


    }
}
