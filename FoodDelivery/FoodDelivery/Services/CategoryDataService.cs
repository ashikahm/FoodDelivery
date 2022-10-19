using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Firebase.Database.Query;
using System.Threading.Tasks;
using FoodDelivery.Model;

namespace FoodDelivery.Services
{
    internal class CategoryDataService
    {
        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient("https://fooddelivery-58ac9-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("categories")
                .OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryId= c.Object.CategoryId,
                    CategoryName= c.Object.CategoryName,
                    CategoryPoster=c.Object.CategoryPoster,
                    ImageUrl= c.Object.ImageUrl

                }).ToList();
            return categories;
        }

    }
}
