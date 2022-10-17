using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery.Helpers
{
    internal class AddCategoryData
    {
        public List<Category> categories;
        public AddCategoryData()
        {
            categories = new List<Category>();
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "name"
                };
            }
        }
    }
}
