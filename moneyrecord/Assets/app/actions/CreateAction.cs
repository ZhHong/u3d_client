using UnityEngine;
using System.Collections;
using app.service;
using app.manager;
using UnityEngine.UI;

public class CreateAction : MonoBehaviour {

    private bool CheckUserNameState =false;
    private bool CheckPasswordState = false;
    private bool checkPasswordAgain = false;

    void Start() {
        if (CheckUserNameState && CheckPasswordState && checkPasswordAgain) {
            SetCreateButtonState(true);
            return;
        }
        SetCreateButtonState(false);
    }

    void UpdateButonCreateState() {
        if (CheckUserNameState && CheckPasswordState && checkPasswordAgain)
        {
            SetCreateButtonState(true);
            return;
        }
        SetCreateButtonState(false);
    }

	public void OnCreateClick(){
        //loginscene call
		GameWorld.getInstance().loadSceneWithoutLoading ("CreateNew");
	}

    public void OnBackClick() {
        CreateService.ResetState();
        GameWorld.getInstance().loadSceneWithoutLoading("LoginScene");
    }
		
	public void setUserName(string _userName){
        CheckUserNameState = CreateService.CheckUserName (_userName);
        if (!CheckUserNameState) {
            string errorText=GameWorld.getInstance().errorData.GetErrorString();
            if (errorText !="") {
                GameObject gobj1 = GameObject.Find("TextUserNameError");
                GameObject gobj2 = GameObject.Find("TextEnterUsername");
                if (gobj1 != null) {
                    Text t1 = gobj1.GetComponent<Text>();
                    t1.text = errorText;
                }
                if (gobj2 !=null) {
                    Text t2 = gobj2.GetComponent<Text>();
                    t2.color = Color.red;
                }
            }
        }
        else
        {
            GameObject gobj1 = GameObject.Find("TextUserNameError");
            GameObject gobj2 = GameObject.Find("TextEnterUsername");
            if (gobj1 != null)
            {
                Text t1 = gobj1.GetComponent<Text>();
                t1.text = "";
            }
            if (gobj2 != null)
            {
                Text t2 = gobj2.GetComponent<Text>();
                t2.color = Color.green;
            }
            UpdateButonCreateState();
        }

	}

	public void setPassword(string password){
        CheckPasswordState = CreateService.CheckPassword (password);
        if (!CheckPasswordState)
        {
            string errorText = GameWorld.getInstance().errorData.GetErrorString();
            if (errorText != "")
            {
                GameObject gobj1 = GameObject.Find("TextPasswordError");
                GameObject gobj2 = GameObject.Find("TextEnterPassword");
                if (gobj1 != null)
                {
                    Text t1 = gobj1.GetComponent<Text>();
                    t1.text = errorText;
                }
                if (gobj2 != null)
                {
                    Text t2 = gobj2.GetComponent<Text>();
                    t2.color = Color.red;
                }
            }
        }
        else {
            GameObject gobj1 = GameObject.Find("TextPasswordError");
            GameObject gobj2 = GameObject.Find("TextEnterPassword");
            if (gobj1 != null)
            {
                Text t1 = gobj1.GetComponent<Text>();
                t1.text = "";
            }
            if (gobj2 != null)
            {
                Text t2 = gobj2.GetComponent<Text>();
                t2.color = Color.green;
            }
            UpdateButonCreateState();
        }
	}

	public void setPassword2(string password){
        checkPasswordAgain = CreateService.CheckPasswrod2 (password);
        if (!checkPasswordAgain)
        {
            string errorText = GameWorld.getInstance().errorData.GetErrorString();
            if (errorText != "")
            {
                GameObject gobj1 = GameObject.Find("TextPasswordAgainError");
                GameObject gobj2 = GameObject.Find("TextEnterPasswordAgain");
                if (gobj1 != null)
                {
                    Text t1 = gobj1.GetComponent<Text>();
                    t1.text = errorText;
                }
                if (gobj2 != null)
                {
                    Text t2 = gobj2.GetComponent<Text>();
                    t2.color = Color.red;
                }
            }
        }
        else
        {
            GameObject gobj1 = GameObject.Find("TextPasswordAgainError");
            GameObject gobj2 = GameObject.Find("TextEnterPasswordAgain");
            if (gobj1 != null)
            {
                Text t1 = gobj1.GetComponent<Text>();
                t1.text = "";
            }
            if (gobj2 != null)
            {
                Text t2 = gobj2.GetComponent<Text>();
                t2.color = Color.green;
            }
            UpdateButonCreateState();
        }
    }

	public void CreateNewUser(){
        ResetState();
		CreateService.CreateNewUser ();
        GameWorld.getInstance().loadSceneWithoutLoading("LoginScene");

	}

    public void ResetState() {
        CheckUserNameState = false;
        CheckPasswordState = false;
        checkPasswordAgain = false;
    }

    private void SetCreateButtonState(bool state) {
        GameObject gobj = GameObject.Find("ButtonCreate");
        if (gobj != null) {
            Button b = gobj.GetComponent<Button>();
            //gobj.SetActive(state);
            b.enabled = state;
        }
    }
}
