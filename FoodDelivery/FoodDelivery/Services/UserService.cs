using Firebase.Database;
using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Auth;

namespace FoodDelivery.Services
{

    public class UserService
    {
        FirebaseAuthProvider authProvider;
        string webkey = "AIzaSyDHEHFrMvePS2J4BZkOtriSHsvE-T_rGtM";
        public UserService()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(webkey));
        }
        public async Task<string> SignIn(string email, string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            var name = await authProvider.GetUserAsync(token.FirebaseToken);
            if (string.IsNullOrEmpty(token.FirebaseToken))
            {
                return "";
            }
            return token.FirebaseToken;
            

        }
        public async Task<bool> SignUp(string email,string password,string name)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password,name);
            if(string.IsNullOrEmpty(token.FirebaseToken))
            {
                return false;
            }
            return true;
        }
        public async Task<bool> ForgotPassword(string password)
        {
             await authProvider.SendPasswordResetEmailAsync(password);
            return true;
        }
    }
}

  
