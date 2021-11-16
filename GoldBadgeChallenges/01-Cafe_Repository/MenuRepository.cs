﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class MenuRepository
    {
        private List<Menu> _listOfMenuItems = new List<Menu>();

        //Create
        public void AddItemToMenuList(Menu menu)
        {
            _listOfMenuItems.Add(menu);
        }

        //Read
        public List<Menu> GetMenuItemsList()
        {
            return _listOfMenuItems;
        }

        //Delete
        public bool RemoveMenuItemFromList(string mealName)
        {
            Menu menu = GetMenuItemByMealName(mealName);

            if (menu == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menu);

            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Get Item by mealName for delete method
        private Menu GetMenuItemByMealName(string mealName)
        {
            foreach (Menu menu in _listOfMenuItems)
            {
                if (menu.MealName == mealName)
                {
                    return menu;
                }
            }
            return null;
        }
    }
}
