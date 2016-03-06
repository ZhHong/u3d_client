using UnityEngine;
using System.Collections;
namespace app.model{
	public class User{

		public int UserStatus =0;

		private int uid =0;
		private string username = "";
		private string password = "";
		private int reg_time =0;

		private static User user = null;

		private User(){
			
		}

		public static User Instance(){
			if(user == null){
				user = new User ();
			}
			return user;
		}

		public int GetUid(){
			return uid;
		}

		public string GetUserName(){
			return username;
		}

		public int GetRegTime(){
			return reg_time;
		}

		public bool InitUser(string uname,string pwd,int _uid,int _reg_time){
            UserStatus = 1;
            username = uname;
            password = pwd;
            uid = _uid;
            reg_time = _reg_time;
			return true;
		}

		public void ResetUser(){
			UserStatus = 0;
			username = "";
			password = "";
            uid = 0;
			reg_time = 0;
		}

		public void DestroyUser(){
			//app over destory
		}

	}
}
