using System;
using System.Collections.Generic;
using System.Linq;
using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class Menu_Test
    {
        [TestMethod]
        public void CreateMenuItem_ShouldInitialize()
        {
            //Arrange
            Menu menu = new Menu("Chicken", "Chicken Meal", new List<string> { "Chicken Leg", "Chicken Wing" }, 5.00m);

            //Act
            List<string> menuIngredients = new List<string> { "Chicken Leg", "Chicken Wing" };

            bool listAreTheSame = menu.MealIngredients.SequenceEqual(menuIngredients);

            //Assert
            Assert.AreEqual(menu.MealNumber, 1);
            Assert.AreEqual(menu.MealName, "Chicken");
            Assert.AreEqual(menu.MealDescription, "Chicken Meal");
            Assert.IsTrue(listAreTheSame);
            Assert.AreEqual(menu.Price, 5.00m);
        }
    }
}
