using UnityEngine;
using System.Collections;
using app.manager;
namespace app.service
{
    public class LoginService
    {

        public static void Login(string username,string password)
        {
            GameWorld instance = GameWorld.getInstance();
            instance.CheckUserLogin(username,password);
        }
    }
}