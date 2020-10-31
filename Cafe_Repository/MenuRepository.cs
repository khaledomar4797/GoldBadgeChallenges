using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuRepository
    {
        private List<Menu> _menu = new List<Menu>();

        //Create
        public bool AddItemToTheMenu(Menu item)
        {
            int currentMenuCount = _menu.Count;
            
            _menu.Add(item);

            bool itemWasAdded = (_menu.Count > currentMenuCount) ? true : false;

            return itemWasAdded;
        }

        //Read
        public List<Menu> GetTheMenu()
        {
            return _menu;
        }

        public Menu GetMenuItemByNumber(int mealNumber)
        {
            foreach(Menu menuItem in _menu)
            {
                if(menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }

            return null;
        }

        //Update
        public bool UpdateExitingMenuItem(int menuNumber, Menu menuItem)
        {
            Menu currentMenuItem = GetMenuItemByNumber(menuNumber);
            
            if(currentMenuItem != null)
            {
                currentMenuItem.MealName = menuItem.MealName;
                currentMenuItem.MealDescription = menuItem.MealDescription;
                currentMenuItem.MealIngredients = menuItem.MealIngredients;
                currentMenuItem.Price = menuItem.Price;

                return true;
            }
            else
            {
                return false;
            }
        }
        
        //Delete
        public bool DeleteExitingMenuItem(Menu menuItem)
        {
            bool ItemWasRemoved = _menu.Remove(menuItem);

            return ItemWasRemoved;

        }
    }
}
