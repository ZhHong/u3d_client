using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using app.manager;

public class Login_action : MonoBehaviour
{

    private static string _userName = "";
    private static string _password = "";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startLogin()
    {
        //开始登陆
        Debug.Log("start login");
        var login_state = false;

        Debug.Log("check if i get the user info===============username" + _userName + "===user password==" + _password);

        //skynet watch dog confg
        var ip = "127.0.0.1";
        var port = 9988;



        NetworkConnectionError err = Network.Connect(ip,port);

        Debug.Log("connection state "+err);



        if (_userName == "root" && _password == "root")
        {
            Debug.Log(" login success===================");
            login_state = true;
        }
        if (login_state)
        {
            loginSuccess();
        }


    }

    public void setUserName(string username)
    {
        Debug.Log("go in set username " + username);
        _userName = username;
    }

    public void setUserPassword(string password)
    {
        Debug.Log("go in set password  " + password);
        _password = password;
    }

    void loginSuccess()
    {
        var next_scene = "role_scene";
        GameWorld.getInstance().loadSceneWithLoading(next_scene);
        //SceneManager.LoadScene("loading_scene");
    }
}
