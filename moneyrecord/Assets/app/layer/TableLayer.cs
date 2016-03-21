using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;
using app.utils;

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

	void OnGUI(){
        //update all times
        //Todo
        //use data colums rows
        //use data length max to decided the label lenth
        //

		int labelWidth = MaxTableWidth/6;
		int labelHeight = Screen.height/20;
		int HeaderHeight = 0;
		int Headerwidth = MaxTableWidth/20;
		if (proview){
            proCommond=GUI.TextArea (new Rect(MaxTableWidth/20,Screen.height/8,MaxTableWidth*9/10,labelHeight),proCommond);
			if (GUI.Button (new Rect (MaxTableWidth / 20 + MaxTableWidth * 9 / 10-labelWidth, Screen.height / 8+labelHeight,labelWidth,labelHeight), "Excute")) {
				Debug.Log ("excute commond===================");
			}
			return;
		}

        Hashtable header = app.manager.GameWorld.getInstance().errorData.GetTextTable();
        string jsdata = LitJson.JsonMapper.ToJson(header);

        JsonData mydata = LitJson.JsonMapper.ToObject(jsdata);

        if (showTable%2 ==0){
			return;
		}
        if (showData == null | showData.Count ==0) {
            GUI.contentColor = Color.red;
            GUIStyle gsl = new GUIStyle();
            gsl.fontSize = MaxTableWidth / 32;
            gsl.alignment= TextAnchor.MiddleCenter;
            GUI.Label(new Rect(MaxTableWidth/8,Screen.height/8,MaxTableWidth/4,Screen.height/4),"没有记录！",gsl);
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

	public void Show(){
        showTable +=1;
	}
}
