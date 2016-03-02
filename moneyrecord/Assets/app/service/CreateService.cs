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

		public static void CheckUserName(string _username){
			//check username 
			username =_username;
            bool canMatch=Regex.IsMatch(username, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
            Debug.Log("username can match the law==================="+canMatch);
            //check in database
            int checkAction= GameWorld.getInstance().CheckUserInDB(username);

            if (checkAction !=1) {
                Debug.Log("check username in db failed  it has exists!!");
            }

		}

		public static void CheckPassword(string _password){
			//check password
			password1 =_password;
            bool canMatch = Regex.IsMatch(password1, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
            if (!canMatch) {
                Debug.Log("password can not match the law");
            }
        }

		public static void CheckPasswrod2(string _password2){
			//check password
			password2 =_password2;
            bool canMatch = Regex.IsMatch(password2, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
            bool canPEP = true;
            if (password1 != password2) {
                Debug.Log("password1 can not match password2");
                canPEP = false;
            }
            if (!canPEP | !canMatch) {
                Debug.Log(" password match faild=====================");
            }
		}

		public static void CreateNewUser(){
			GameWorld gameworld = GameWorld.getInstance ();
			gameworld.CreateUser (username, password1);
		}
	}
}
