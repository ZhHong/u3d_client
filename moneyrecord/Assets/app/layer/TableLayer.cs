using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;
using app.utils;
using System;

public class TableLayer : MonoBehaviour {
    //example http://blog.csdn.net/aisajiajiao/article/details/17472503
    private static int showTable = 0;

    private Vector2 srollPostion = Vector2.zero;
    private int rows = 0;
    private int colums = 0;

	private Hashtable showData = null;

    
	private int MaxTableWidth =0;

	private bool proview = false;

	private string proCommond ="";

	private string showString ="";

	private string showException ="";

	void OnGUI(){
		if (proview){
			DrawProview ();
			return;
		}
		DrawDataView ();
    }

	private void DrawDataView(){
		//update all times
		//Todo
		//use data colums rows
		//use data length max to decided the label lenth
		//

		int labelWidth = MaxTableWidth/6;
		int labelHeight = Screen.height/20;
		int Headerwidth = MaxTableWidth/20;

		Hashtable header = app.manager.GameWorld.getInstance().errorData.GetTextTable();
		string jsdata = LitJson.JsonMapper.ToJson(header);

		JsonData mydata = LitJson.JsonMapper.ToObject(jsdata);

		if (showTable%2 ==0){
			return;
		}
		if (showData == null | ((showData !=null) &&showData.Count ==0)) {
			showString = "没有记录!";
			GUI.contentColor = Color.red;
			GUIStyle gsl = new GUIStyle();
			gsl.fontSize = MaxTableWidth / 32;
			gsl.alignment= TextAnchor.MiddleCenter;
			if (showException != "") {
				gsl.fontSize = MaxTableWidth / 64;
				gsl.alignment = TextAnchor.LowerLeft;
				gsl.wordWrap = true;
				GUI.Label(new Rect(MaxTableWidth/8,Screen.height/8,MaxTableWidth*2/3,Screen.height*3/4),showException,gsl);
				return;
			}
			GUI.Label(new Rect(MaxTableWidth/8,Screen.height/8,MaxTableWidth/4,Screen.height/4),showString,gsl);
			return;
		}
		//GUI.contentColor = Color.red;
		GUI.BeginGroup (new Rect (MaxTableWidth/20,Screen.height/20,MaxTableWidth*9/10,Screen.height*9/10));
		srollPostion=GUI.BeginScrollView(new Rect(0, 0, MaxTableWidth * 9 / 10, Screen.height * 9 / 10), srollPostion, new Rect(0, 0, labelWidth * colums+Headerwidth, labelHeight * rows));
		GUI.Button(new Rect(0,0,Headerwidth,labelHeight),"");
		GUI.skin.button.fontSize = labelHeight * 1 / 2;
		for (int b=1;b<=colums;b++) {
			GUI.Button(new Rect(Headerwidth+(b-1)*labelWidth,0,labelWidth,labelHeight),(string)mydata[(b-1).ToString()]);
		}
		for (int i = 1; i <= rows; i++)
		{
			GUI.Button(new Rect(0, i * labelHeight, Headerwidth, labelHeight), i.ToString());
			Hashtable data_temp = (Hashtable)showData [i-1];
			for (int j = 1; j <=colums; j++)
			{
				string show_str = (data_temp[j - 1]).ToString();
				//Debug.Log ("data["+i+"],["+j+"]===="+str);
				GUI.Button(new Rect(Headerwidth + (labelWidth * (j-1)), 0 + (labelHeight * i), labelWidth, labelHeight), show_str);
			}
		}
		GUI.EndScrollView();
		GUI.EndGroup ();
		GUI.skin.button.fontSize = labelHeight*3 / 4;
		if (GUI.Button (new Rect (MaxTableWidth/20+MaxTableWidth*9/10, Screen.height*9/10-labelWidth/2, labelHeight, labelWidth/2), "↓")) {
			srollPostion.y += labelHeight;
		}
		if (GUI.Button (new Rect (MaxTableWidth/20+MaxTableWidth*9/10, Screen.height*9/10-labelWidth, labelHeight, labelWidth/2), "↑")) {
			srollPostion.y -= labelHeight;
		}
		if(GUI.Button(new Rect(MaxTableWidth/20+MaxTableWidth*9/10-labelWidth,Screen.height*9/10+labelHeight,labelWidth/2,labelHeight),"←")){
			srollPostion.x -= labelWidth / 2;
		}
		if(GUI.Button(new Rect(MaxTableWidth/20+MaxTableWidth*9/10-labelWidth/2,Screen.height*9/10+labelHeight,labelWidth/2,labelHeight),"→")){
			srollPostion.x += labelWidth / 2;
		}
	}

	private void DrawProview(){
		if (showTable%2 ==0){
			return;
		}
		int labelWidth = MaxTableWidth/6;
		int labelHeight = Screen.height/20;
		int Headerwidth = MaxTableWidth/20;
		if (proview){
			proCommond=GUI.TextArea (new Rect(MaxTableWidth/20,Screen.height/8,MaxTableWidth*9/10,labelHeight),proCommond);
			if (GUI.Button (new Rect (MaxTableWidth / 20 + MaxTableWidth * 9 / 10-labelWidth, Screen.height / 8+labelHeight,labelWidth,labelHeight), "Excute")) {
				Hashtable show = new Hashtable();
				try{
					show = app.manager.GameWorld.getInstance ().ExcuteManualSQl (proCommond);
				}catch(Exception e){
					showException = e.Message;
				}finally{
					CreateTableView(show,MaxTableWidth);
					proview = false;
				}
			}
			return;
		}
	}

	public void CreateTableView(Hashtable data ,int maxTableWidth){
        rows = data.Count;
		foreach(DictionaryEntry hal in data)
        {
			colums = ((Hashtable)hal.Value).Count;
        }
        showData = data;
		MaxTableWidth = maxTableWidth;
    }

	public void CreateProView(int maxTableWidth){
		proview = true;
		MaxTableWidth = maxTableWidth;
	}

    public void UpdateTableData() {

    }

	public void ReShow(){
		showTable += 1;
		proview = true;
		proCommond = "";
		showException = "";
	}

	public void Show(){
        showTable +=1;
	}
}
