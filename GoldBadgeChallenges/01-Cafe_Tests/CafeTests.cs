using _01_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class CafeTests
    {

        [TestMethod]
        public void AddItem_ShouldGetNotNull() 
        {
            //Arrange
            Menu menuTest = new Menu();
            MenuRepository menuRepo = new MenuRepository();
            menuTest.MealName = "Hot Pocket";
            //Act
            menuRepo.AddItem(menuTest);
            Menu menuFromDirectory = menuRepo.GetItemByName("Hot Pocket");
            //Assert
            Assert.IsNotNull(menuFromDirectory);
        }
        [TestMethod]
        public void GetAllItems_ShouldGetNotNull()
        {
            //Arrange
            Menu potato = new Menu();
            MenuRepository menuRepo = new MenuRepository();
            potato.MealNumber = 1;
            potato.MealName = "Potato";
            potato.MealDescription = "Big tater";
            List<string> potatoIngredients = new List<string>() {"potato", "butter" };
            potato.MealIngredients = potatoIngredients;
            potato.MealPrice = 2.05m;
            //Act
            menuRepo.AddItem(potato);
            menuRepo.GetAllItems();
            //Assert
            Assert.IsNotNull(potato);

        } [TestMethod]
        public void DeleteItem_ShouldReturnFalse()
        {
            //Arrange
            Menu potato = new Menu();
            MenuRepository menuRepo = new MenuRepository();
            potato.MealNumber = 1;
            potato.MealName = "Potato";
            potato.MealDescription = "Big tater";
            List<string> potatoIngredients = new List<string>() {"potato", "butter" };
            potato.MealIngredients = potatoIngredients;
            potato.MealPrice = 2.05m;
            //Act
            menuRepo.AddItem(potato);
            menuRepo.RemoveItem(potato.MealName);
            //Assert
            Assert.IsFalse(menuRepo.RemoveItem(potato.MealName));
        }

    }
}
