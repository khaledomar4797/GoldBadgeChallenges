using System;
using System.Collections.Generic;
using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class MenuRepository_Test
    {
        [TestCleanup]
        public void ResetStaticCounter()
        {
            Menu.mealCounter = 0;
        }
        
        [TestMethod]
        public void AddMenuItem_ShouldReturnCorrect()
        {
            //Arrange
            Menu newMenu = new Menu();
            MenuRepository _repo = new MenuRepository();

            //Act
            bool menuItemWasAdded = _repo.AddItemToTheMenu(newMenu);

            //Assert
            Assert.IsTrue(menuItemWasAdded);
        }

        [TestMethod]
        public void GetMenuList_ShouldReturnMenuList()
        {
            //Arrange
            Menu newMenu = new Menu();
            MenuRepository _repo = new MenuRepository();

            _repo.AddItemToTheMenu(newMenu);

            //Act
            List<Menu> newRepo = _repo.GetTheMenu();

            bool menuListIsReturn = newRepo.Contains(newMenu);

            //Assert
            Assert.IsTrue(menuListIsReturn);
        }

        [TestMethod]
        public void GetMenuItemByNumber_ShouldReturnCorrectMenuItem()
        {
            //Arrange
            Menu newMenu1 = new Menu();
            Menu newMenu2 = new Menu("Chicken", "Chicken Meal", new List<string> { "Chicken Leg", "Chicken Wing" },5.00m);
            MenuRepository _repo = new MenuRepository();
            
            newMenu1.MealName = "Pizza";
            _repo.AddItemToTheMenu(newMenu1);
            _repo.AddItemToTheMenu(newMenu2);

            //Act
            Menu testMenuNameOfPizza = _repo.GetMenuItemByNumber(1);
            Menu testMenuNameOfChicken = _repo.GetMenuItemByNumber(2);

            //Assert
            Assert.AreEqual(testMenuNameOfPizza.MealName, "Pizza");
            Assert.AreEqual(testMenuNameOfChicken.MealName, "Chicken");

        }

        [TestMethod]
        public void UpdateMenuItem_ShouldReturnCorrect()
        {
            //Arrange
            Menu currentMenu = new Menu("Chicken", "Chicken Meal", new List<string> { "Chicken Leg", "Chicken Wing" }, 5.00m);
            Menu newMenu = new Menu("Chicken", "Half Chicken Meal", new List<string> { "Chicken Leg", "Chicken Wing" }, 6.35m);
            
            MenuRepository _repo = new MenuRepository();
            _repo.AddItemToTheMenu(currentMenu);

            //Act
            bool menuItemIsUpdated = _repo.UpdateExitingMenuItem(1, newMenu);

            //Assert
            Assert.IsTrue(menuItemIsUpdated);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnCorrect()
        {
            //Arrange
            Menu newMenu = new Menu("Chicken", "Chicken Meal", new List<string> { "Chicken Leg", "Chicken Wing" }, 5.00m);
            MenuRepository _repo = new MenuRepository();

            _repo.AddItemToTheMenu(newMenu);

            //Act

            bool menuItemIsRemoved = _repo.DeleteExitingMenuItem(newMenu);

            //Assert
            Assert.IsTrue(menuItemIsRemoved);
        }
    }
}
