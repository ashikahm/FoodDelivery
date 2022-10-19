using Firebase.Auth;
using Firebase.Database;
using FoodDelivery.Model;
using FoodDelivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography.X509Certificates;
using User = FoodDelivery.Model.User;
using Firebase.Database.Query;

namespace FoodDelivery.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        UserService userService = new UserService();
        FirebaseClient client;
        public SignUpPage()
        {
            InitializeComponent();
            client = new FirebaseClient("https://fooddelivery-58ac9-default-rtdb.firebaseio.com/");
        }
        public async Task AddUserToDB(string name, string password)
        {
            await client.Child("UsersData").PostAsync(new User()
            {
                UserName = name,
                Password = password
            });
        }

        private async void ButtonSignUp_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = EmailEntry.Text;
                string password = PasswordEntry.Text;
                string name = NameEntry.Text;
                var result = await userService.SignUp(email, password, name);
                if( result)
                {
                    await DisplayAlert("Message", "SignUp Successfull! Please Login back", "ok");
                    AddUserToDB(name, password);
                    return;
                }
                else
                {
                    await DisplayAlert("Error", "SignUp Failed! Please Try again later", "ok");
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_EXISTS"))
                {
                    await DisplayAlert("Warning", "Email Already Exists", "Oh !!");
                }
                else
                {
                    await DisplayAlert("Error", ex.Message, "Oops");
                }
            }


        }

        private void ButtonSignIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginView());

        }
    }
}