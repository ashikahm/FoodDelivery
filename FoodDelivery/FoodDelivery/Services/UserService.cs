using Firebase.Database;
using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Services
{

    FirebaseClient client;
    internal class UserService
    {
        
        client =  new FirebaseClient("https://fooddelivery-58ac9-default-rtdb.firebaseio.com/");
         
    }
  

}
