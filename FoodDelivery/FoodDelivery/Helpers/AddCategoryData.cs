using Firebase.Database;
using Firebase.Database.Query;
using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodDelivery.Helpers
{
    internal class AddCategoryData
    {
        public List<Category> categories;
        FirebaseClient client;

        public AddCategoryData()
        {
            client = new FirebaseClient("https://fooddelivery-58ac9-default-rtdb.firebaseio.com/");
            categories = new List<Category>()
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Pizza",
                    CategoryPoster = "pizzaIcon.png",
                    ImageUrl = "pizzaIcon.png"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Burger",
                    CategoryPoster = "burgerIcon.png",
                    ImageUrl = "burgerIcon.png"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Sandwich",
                    CategoryPoster = "SandWitch.png",
                    ImageUrl = "SandWitchIcon.png"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Bevarages",
                    CategoryPoster = "CoffeIcon.png",
                    ImageUrl = "CoffeIcon.png"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Desserts",
                    CategoryPoster = "DessertIcon.png",
                    ImageUrl = "DessertIcon.png"
                }
            };
        }
        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in categories)
                {
                    await client.Child("categories").PostAsync(new Category()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
                    });
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }
        }
    }
}
