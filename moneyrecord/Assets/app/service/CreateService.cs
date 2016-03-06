using UnityEngine;
using System.Collections;
using app.dao;
using app.manager;
using System.Text.RegularExpressions;

namespace app.service{

	public class CreateService {

		private static string username = "";
		private static string password1 = "";
		private static string password2 = "";

		public static bool CheckUserName(string _username){
			//check username 
			username =_username;
            bool canMatch=Regex.IsMatch(username, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
            if (!canMatch) {
                GameWorld.getInstance().errorData.SetErrorData("USERNAME_NOT_FIT");
                return false;
            }
            //check in database
            string checkAction= GameWorld.getInstance().CheckUserInDB(username);

            if (checkAction !="SUCCESS") {
                GameWorld.getInstance().errorData.SetErrorData(checkAction);
                return false;
            }

            return true;

		}

		public static bool CheckPassword(string _password){
			//check password
			password1 =_password;
            bool canMatch = Regex.IsMatch(password1, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
            if (!canMatch) {
                GameWorld.getInstance().errorData.SetErrorData("USERPASSWORD_NOT_FIT");
                return false;
            }
            return true;
        }

		public static bool CheckPasswrod2(string _password2){
			//check password
			password2 =_password2;
            bool canMatch = Regex.IsMatch(password2, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
            if (!canMatch) {
                GameWorld.getInstance().errorData.SetErrorData("USERPASSWORD_NOT_FIT");
                return false;
            }
            if (password1 != password2) {
                GameWorld.getInstance().errorData.SetErrorData("USERPASSWORD_AGAIN_NOT_FIT");
                return false;
            }
            return true;
		}

		public static void CreateNewUser(){
			GameWorld gameworld = GameWorld.getInstance ();
			gameworld.CreateUser (username, password1);
		}


        public static void ResetState() {
            username = "";
            password1 = "";
            password2 = "";
        }
	}
}
