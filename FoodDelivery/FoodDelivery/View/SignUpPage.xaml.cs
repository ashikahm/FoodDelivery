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
    public partial class SignUpPage : ContentPage
    {
        UserService userService = new UserService();
             
        public SignUpPage()
        {
            InitializeComponent();
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
    }
}