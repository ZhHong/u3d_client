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

    private string RemeberUserName = "";
    private string RemeberPassword = "";
    private bool re_name = false;
    private bool re_pass = false;

	void Start(){
		if (gameworld == null) {
			gameworld = GameWorld.getInstance ();
		}
        GameObject ifhas = GameObject.Find("TextErrorLog");
        if (ifhas != null)
        {
            Text msghas = ifhas.GetComponent<Text>();
            string gamesave = Application.persistentDataPath + app.utils.Utils.GLOBAL_GAME_SAVE_PATH;
            string db_file_location = Application.persistentDataPath + app.utils.Utils.GLOBAL_DB_FILE_PATH;
            msghas.text = "初始化数据失败！\n" + gamesave+"\n"+db_file_location;
        }
        UpdateButtonLoginState();
        SetRememberState();
    }

    private void SetRememberState() {
        RemeberUserName = gameworld.GetUserSaveDef("re_name");
        RemeberPassword = gameworld.GetUserSaveDef("re_pass");
        if (RemeberUserName !="") {
            CheckUserName = true;
            GameObject gobj = GameObject.Find("ToggleRememberUserName");
            if (gobj != null) {
                Toggle tl = gobj.GetComponent<Toggle>();
                if (tl != null) {
                    tl.isOn = true;
                    GameObject gobj2 = GameObject.Find("InputUsername");
                    InputField ipt = gobj2.GetComponent<InputField>();
                    ipt.text = RemeberUserName;
                    SetUserName(RemeberUserName);
                }
            }
        }
        if (RemeberPassword != "" && RemeberUserName !="")
        {
            CheckUserPass = true;
            GameObject gobj = GameObject.Find("ToggleRememberPassword");
            if (gobj != null)
            {
                Toggle tl = gobj.GetComponent<Toggle>();
                if (tl != null)
                {
                    tl.isOn = true;
                    GameObject gobj2 = GameObject.Find("InputPassword");
                    InputField ipt = gobj2.GetComponent<InputField>();
                    ipt.text = RemeberPassword;
                    SetPassword(RemeberPassword);

                }
            }
        }
    }

    private void RemoveRememberState()
    {

    }

    public void OnApplicationQuit()
    {
        GameWorld.getInstance().GameWorldDestroy();
    }

    public void onLoginClick()
    {
        //check user
        if (!CheckUserName | !CheckUserPass) {
            GameObject ifhas = GameObject.Find("TextLoginCheckField");
            if (ifhas != null)
            {
                Text msghas = ifhas.GetComponent<Text>();
                msghas.text = "用户名,密码不能为空！";
                msghas.color = Color.red;
                ResetInputTextField();
                return;
            }
        }
        LoginService.Login(_userName,_password);
		if (gameworld.getLoginState () != 1) {
            GameObject ifhas = GameObject.Find("TextLoginCheckField");
            if (ifhas != null)
            {
                Text msghas = ifhas.GetComponent<Text>();
                msghas.text = "登录失败，用户名或密码错误！";
                msghas.color = Color.red;
                ResetInputTextField();
                return;
            }
		} else {
            if (re_name) {
                RemeberUserName = _userName;
                gameworld.SetUserSaveDef("re_name",RemeberUserName);
            }
            else
            {
                RemeberUserName = "";
                gameworld.SetUserSaveDef("re_name", RemeberUserName);
            }
            if (re_pass) {
                RemeberPassword = _password;
                gameworld.SetUserSaveDef("re_pass", RemeberPassword);
            }
            else
            {
                RemeberPassword = "";
                gameworld.SetUserSaveDef("re_pass", RemeberPassword);
            }
            GameWorld.getInstance().ReplaceGameSave();
            //reset data
            ResetInputTextField();
            //load database data
            gameworld.loadSceneWithoutLoading("DetailScene");
			gameworld.LoadDefaultData ();
		}

	}

    public void OnCreateClick()
    {
        //loginscene call
        GameWorld.getInstance().loadSceneWithoutLoading("CreateNew");
    }

    public void SetUserName(string userName)
    {
        bool canMatch = Regex.IsMatch(userName, "(^[a-zA-Z0-9]{6,16}$)|(^[\u4E00-\u9FA5]{2,8}$)");
        if (!canMatch) {
            SetComponetTextState("TextLoginUserNameError","USERNAME_NOT_FIT");
            return;
        }
        if (re_name) {
            RemeberUserName = userName;
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
        if (re_pass) {
            RemeberPassword = password;
        }
        _password = password;
        CheckUserPass = true;
        SetComponetTextState("TextLoginPasswordError", "");
        UpdateButtonLoginState();
    }

    public void OnRememberUserName(bool state) {
        if (state) {
            re_name = true;
        }
        else
        {
            re_name = false;
            re_pass = false;
            GameObject gob = GameObject.Find("ToggleRememberPassword");
            if (gob != null)
            {
                Toggle tl = gob.GetComponent<Toggle>();
                if (tl != null)
                {
                    tl.isOn = false;
                }
            }
            RemeberUserName = "";
            RemeberPassword = "";
        }
    }

    public void OnRememberPassWord(bool state) {
        if (state) {
            re_name = true;
            re_pass = true;
            GameObject gob = GameObject.Find("ToggleRememberUserName");
            if (gob != null) {
                Toggle tl = gob.GetComponent<Toggle>();
                if (tl !=null) {
                    tl.isOn = true;
                }
            }
        }
        else
        {
            re_pass = false;
            RemeberPassword = "";
        }
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
        UpdateButtonLoginState();
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
