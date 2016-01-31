using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using app.manager;

public class Loading_action : MonoBehaviour {

	// Use this for initialization

    private float fps = 10.0f;
    private float time;
    //动画
    //public Texture2D[] animations;
    private int nowFrame;
    //异步对象
    AsyncOperation async;

    //进度
    int progress;
	void Start () {
	    //开始异步任务 协程
        StartCoroutine(loadScene());
	}
	
    IEnumerator loadScene(){
        //异步读取场景
        async = SceneManager.LoadSceneAsync(GameWorld.getInstance().nextloadScene);
        
        yield return async;
    }

    void OnGUI(){
        //DrawAnimation(animations);
        DrawAnimation();
    }

	// Update is called once per frame
	void Update () {
	    //计算进度
        progress = (int)(async.progress*100);
	}

    //void DrawAnimation(Texture2D[] tex){
    void DrawAnimation(){
        time+=Time.deltaTime;
        if (time>=1.0/fps){
            nowFrame++;
            time =0;
            //if(nowFrame>=tex.Length){
            //    nowFrame =0;
            //}
        }
        //GUI.DrawTexture(new Rect(100,100,40,60),tex[nowFrame]);

        GUI.Label(new Rect(100,180,300,60),"loading..."+progress);
    }
}
