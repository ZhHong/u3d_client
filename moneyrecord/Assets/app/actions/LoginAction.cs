using UnityEngine;
using System.Collections;
using app.dao;

public class LoginAction : MonoBehaviour {

    private static string _userName = "";
    private static string _password = "";
    public void onLoginClick()
    {
        //check user
        Debug.Log("check user name===user name =="+_userName+"======password=="+_password);
        if (true)
        {
            //loadDB
        }
        
	}

    public void onRegClick()
    {
        Debug.Log("register");

    }

    public void SetUserName(string userName)
    {
        _userName = userName;
    }

    public void SetPassword(string password)
    {
        _password = password;
    }
}
