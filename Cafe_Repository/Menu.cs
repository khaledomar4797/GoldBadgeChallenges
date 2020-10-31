using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class Menu
    {
        public int MealNumber { get; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> MealIngredients { get; set; }
        public decimal Price { get; set; }

        public static int mealCounter = 0;

        public Menu()
        {
            mealCounter++;
            MealNumber = mealCounter;
        }

        public Menu(string mealName, string mealDescription, List<string> mealIngredients, decimal price)
        {
            mealCounter++;
            MealNumber = mealCounter;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            Price = price;
        }
    }
}
