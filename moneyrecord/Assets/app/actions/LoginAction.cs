using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using app.dao;
using app.manager;
using app.service;
using app.layer;
public class LoginAction : MonoBehaviour {

    private static string _userName = "";
    private static string _password = "";
	private GameWorld gameworld = null;

	void Start(){
		Debug.Log ("on login ui start=================");
		if (gameworld == null) {
			gameworld = GameWorld.getInstance ();
		}
	}
    public void onLoginClick()
    {
        //check user
        Debug.Log("check user name===user name =="+_userName+"======password=="+_password);
        LoginService.Login(_userName,_password);
		if (gameworld.getLoginState () != 1) {
			Debug.Log ("login failed===============================");
			MsgLayer.Show ("error");
		} else {
			//load database data
			gameworld.loadSceneWithoutLoading("DetailScene");
			gameworld.LoadDefaultData ();
		}

	}

    public void SetUserName(string userName)
    {
        bool canMatch = Regex.IsMatch(userName, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
        if (!canMatch) {
            Debug.Log("user name can not pass the law");
        }
        _userName = userName;
    }

    public void SetPassword(string password)
    {
        bool canMatch = Regex.IsMatch(password, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
        if (!canMatch) {
            Debug.Log("password can not pass the law");
        }
        _password = password;
    }
}
