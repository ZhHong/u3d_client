using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using app.manager;

public class Chose_fram_btn : MonoBehaviour {

	// 
	public void StartGameOffline () {
        Debug.Log("start game offline,go to role scene");
        //SceneManager.LoadScene("loading_scene");
        var next_scene ="role_scene";
        GameWorld.getInstance().loadSceneWithLoading(next_scene);
	}
	
	// 
	public void StartGameOnline () {
        Debug.Log("start game online go to login scene");
        //Application.LoadLevel("login_scene");
        //SceneManager.LoadScene("loading_scene");
        var next_scene = "login_scene";
        GameWorld.getInstance().loadSceneWithLoading(next_scene);
        GameWorld.getInstance().initNetWork();
    }
}
