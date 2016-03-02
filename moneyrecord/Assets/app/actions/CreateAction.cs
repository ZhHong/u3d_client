using UnityEngine;
using System.Collections;
using app.service;
using app.manager;

public class CreateAction : MonoBehaviour {

	private GameWorld gameworld = null;

	void Start(){
		Debug.Log ("on create ui start=================");
		if (gameworld == null) {
			gameworld = GameWorld.getInstance ();
		}
	}

	public void OnCreateClick(){
		Debug.Log("register");
		gameworld.loadSceneWithoutLoading ("CreateNew");
	}
		
	public void setUserName(string _userName){
		CreateService.CheckUserName (_userName);
	}

	public void setPassword(string password){
		CreateService.CheckPassword (password);
	}

	public void setPassword2(string password){
		CreateService.CheckPasswrod2 (password);
	}

	public void CreateNewUser(){
		CreateService.CreateNewUser ();
	}
}
