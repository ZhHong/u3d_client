using UnityEngine;
using System.Collections;
using app.dao;
using app.manager;
namespace app.service{

	public class CreateService {

		private static string username = "";
		private static string password1 = "";
		private static string password2 = "";

		public static void CheckUserName(string _username){
			//check username 
			username =_username;

			//check in database

		}

		public static void CheckPassword(string _password){
			//check password
			password1 =_password;
		}

		public static void CheckPasswrod2(string _password2){
			//check password
			password2 =_password2;
			//check two password is the same
			if (password1 != password2){
				Debug.Log ("password error");
			}
		}

		public static void CreateNewUser(){
			GameWorld gameworld = GameWorld.getInstance ();
			gameworld.CreateUser (username, password1);
		}
	}
}
