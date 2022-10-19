using Firebase.Auth;
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
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }
        public AddFoodItemData()
        {
            client = new FirebaseClient("https://fooddelivery-58ac9-default-rtdb.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ImageUrl = "pizza1.jpg",
                    Name = "Creamy Spinach Pizza - Veg",
                    Description = "Loaded with a delicious Spinach  topping , green capsicum, crunchy red and yellow bell peppers and black olives",
                    HomeSelected = "CompleteHeart",
                    Price = 459,
                    Rating = "4.5",
                    RatingDetail = "(75 Ratings)"
                },
                new FoodItem()
                {
                    ProductID = 2,
                    CategoryID = 1,
                    ImageUrl = "pizza2.png",
                    Name = "Peppy Paneer",
                    Description = "Flavorful trio of juicy paneer, crisp capsicum with spicy red paprika",
                    HomeSelected = "CompleteHeart",
                    Price = 459,
                    Rating = "4.5",
                    RatingDetail = "(100 Ratings)"
                },
                new FoodItem()
                {
                    ProductID = 3,
                    CategoryID = 1,
                    ImageUrl = "pizza3.png",
                    Name = "Spiced Double Chicken",
                    Description = "Delightful combination of our spicy duo- Pepper Barbecue Chicken and Peri Peri Chicken for Chicken Lovers.",
                    HomeSelected = "EmptyHeart",
                    Price = 559,
                    Rating = "4.2",
                    RatingDetail = "(175 Ratings)"
                },
                 new FoodItem()
                 {
                    ProductID = 4,
                    CategoryID = 1,
                    ImageUrl = "pizza4.jpg",
                    Name = "Double Chesse Pasta",
                    Description = "Delightful combination of Cheese and Tangy Tomato",
                    HomeSelected = "EmptyHeart",
                    Price = 559,
                    Rating = "4.2",
                    RatingDetail = "(175 Ratings)"
                },
                  new FoodItem()
                {
                    ProductID = 5,
                    CategoryID = 2,
                    ImageUrl = "burger1.jpg",
                    Name = "Double Chicken Patty Burger",
                    Description = "Delightful combination of Cheese and Chicken",
                    HomeSelected = "CompleteHeart",
                    Price = 259,
                    Rating = "4.8",
                    RatingDetail = "(275 Ratings)"
                },
                   new FoodItem()
                {
                    ProductID = 6,
                    CategoryID = 3,
                    ImageUrl = "Sandwitch1.jpg",
                    Name = "Grilled Potota Sandwitch- veg",
                    Description = "Grilled Potota with some natural herbs and vegetables",
                    HomeSelected = "CompleteHeart",
                    Price = 259,
                    Rating = "4.8",
                    RatingDetail = "(275 Ratings)"
                },
                   new FoodItem()
                {
                    ProductID = 7,
                    CategoryID = 4,
                    ImageUrl = "coffee1.jpg",
                    Name = "Hot filter Coffee",
                    Description = "Made with fresh milk and coffee",
                    HomeSelected = "CompleteHeart",
                    Price = 20,
                    Rating = "4.8",
                    RatingDetail = "(275 Ratings)"
                },
                   new FoodItem()
                {
                    ProductID = 8,
                    CategoryID = 5,
                    ImageUrl = "dessert1.jpg",
                    Name = "Oreo Milk Shake",
                    Description = "Made with crispy Oreo Biscuits and with milk",
                    HomeSelected = "CompleteHeart",
                    Price = 120,
                    Rating = "4.6",
                    RatingDetail = "(275 Ratings)"
                },
            };
        }
        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach(var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Description = item.Description,
                        HomeSelected = item.HomeSelected,
                        Price = item.Price,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail                           
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
