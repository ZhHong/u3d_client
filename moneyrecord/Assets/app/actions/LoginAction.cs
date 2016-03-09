using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using app.dao;
using app.manager;
using app.service;
using app.layer;
public class LoginAction : MonoBehaviour {

    private static string _userName = "";
    private static string _password = "";
	private GameWorld gameworld = null;

    private bool CheckUserName = false;
    private bool CheckUserPass = false;

	void Start(){
		if (gameworld == null) {
			gameworld = GameWorld.getInstance ();
		}
        UpdateButtonLoginState();
	}

    public void OnApplicationQuit()
    {
        GameWorld.getInstance().GameWorldDestroy();
    }

    public void onLoginClick()
    {
        //check user
        if (!(CheckUserName && CheckUserPass)) {
            string showmsg = "Error";
            if (_userName == "" | _password == "") {
                showmsg += "user name and password can not be null";
            }
            else
            {
                showmsg += " user not exsits";
            }

            GameObject ifhas = GameObject.Find("LoginPreCheckFiled");
            if (ifhas != null) {
                MsgLayer msghas = ifhas.GetComponent<MsgLayer>();
                msghas.Show(showmsg);
                ResetInputTextField();
                return;
            }

            GameObject msglayer = new GameObject("LoginPreCheckFiled");
            MsgLayer msg = msglayer.AddComponent<MsgLayer>();
            msg.Show("showmsg");
            ResetInputTextField();
            return;
        }
        LoginService.Login(_userName,_password);
		if (gameworld.getLoginState () != 1) {
			Debug.Log ("login failed===============================");
            GameObject ifhas = GameObject.Find("LoginDataBaseCheckFiled");
            if (ifhas != null)
            {
                MsgLayer msghas = ifhas.GetComponent<MsgLayer>();
                msghas.Show("Error");
                ResetInputTextField();
                return;
            }
            GameObject msglayer = new GameObject("LoginDataBaseCheckFiled");
			MsgLayer msg = msglayer.AddComponent<MsgLayer>();
            ResetInputTextField();
            msg.Show ("Error");
		} else {
            //reset data
            ResetInputTextField();
            //load database data
            gameworld.loadSceneWithoutLoading("DetailScene");
			gameworld.LoadDefaultData ();
		}

	}

    public void SetUserName(string userName)
    {
        bool canMatch = Regex.IsMatch(userName, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
        if (!canMatch) {
            SetComponetTextState("TextLoginUserNameError","USERNAME_NOT_FIT");
            return;
        }
        _userName = userName;
        CheckUserName = true;
        SetComponetTextState("TextLoginUserNameError", "");
        UpdateButtonLoginState();
    }

    public void SetPassword(string password)
    {
        bool canMatch = Regex.IsMatch(password, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
        if (!canMatch) {
            SetComponetTextState("TextLoginPasswordError", "USERPASSWORD_NOT_FIT");
            return;
        }
        _password = password;
        CheckUserPass = true;
        SetComponetTextState("TextLoginPasswordError", "");
        UpdateButtonLoginState();
    }


    private void SetComponetTextState(string ComponetName,string ErrorString="") {
        //set componet Text State
        GameObject gbj = GameObject.Find(ComponetName);
        if (gbj != null) {
            Text t = gbj.GetComponent<Text>();
            if (ErrorString =="")
            {
                t.text = "";
				return;
            }
            GameWorld.getInstance().errorData.SetErrorData(ErrorString);
            t.text = GameWorld.getInstance().errorData.GetErrorString();
            t.color = Color.red;
        }
    }

    private void ResetInputTextField()
    {
        _userName = "";
        _password = "";
        CheckUserName = false;
        CheckUserPass = false;
        GameObject inputuser = GameObject.Find("InputUsername");
        if (inputuser != null) {
            InputField t =inputuser.GetComponent<InputField>();
            t.text = "";
        }
        GameObject inputpass = GameObject.Find("InputPassword");
        if (inputpass !=null) {
            InputField tp =inputpass.GetComponent<InputField>();
            tp.text = "";
        }
    }

    private void ResetButtonLoginState(bool state) {
        GameObject gbj = GameObject.Find("ButtonLogin");
        if (gbj != null) {
            Button b = gbj.GetComponent<Button>();
            b.enabled = state;
        }
    }

    private void UpdateButtonLoginState() {
        if (CheckUserName && CheckUserPass) {
            ResetButtonLoginState(true);
            return;
        }
        ResetButtonLoginState(false);
    }
}
