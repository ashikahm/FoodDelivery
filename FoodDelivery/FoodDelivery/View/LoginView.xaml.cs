using FoodDelivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodDelivery.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        UserService userService= new UserService();
        public LoginView()
        {
            InitializeComponent();
        }

        private async void ButtonSignIn_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = EmailEntry.Text;
                string password = PasswordEntry.Text;
                var result = await userService.SignIn(email, password);
                if(string.IsNullOrEmpty(result))
                {
                    await DisplayAlert("Warning", "UserNotFound Please provide valid credentials", "Ok");
                    return;
                }
                else
                {
                    Navigation.PushAsync(new SignUpPage());
                }
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("INVALID_PASSWORD"))
                {
                    await DisplayAlert("Error", "Please provide correct password", "ok");
                    return;
                }
                else
                {
                    await DisplayAlert("Error",ex.Message, "ok");
                    return;
                }
            }            
        }

        private void ButtonSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}