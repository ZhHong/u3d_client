using UnityEngine;
using System.Collections;
using LitJson;

public class TableLayer : MonoBehaviour {
    //example http://blog.csdn.net/aisajiajiao/article/details/17472503
    private static bool showTable = false;

    private Vector2 srollPostion = Vector2.zero;
    private int rows = 0;
    private int colums = 0;
	private int labelWidth = Screen.width/5;
	private int labelHeight = Screen.height/20;
	private Hashtable showData = null;

	void OnGUI(){
		//update all times
        //Todo
        //use data colums rows
        //use data length max to decided the label lenth
        //
		if (!showTable){
			return;
		}
		GUI.contentColor = Color.red;
		GUI.BeginGroup (new Rect (Screen.width/10,Screen.height/10,Screen.width*4/5,Screen.height*4/5));
		srollPostion=GUI.BeginScrollView(new Rect(0, 0, labelWidth *colums, labelHeight *rows), srollPostion, new Rect(0, 0, Screen.width*4/5,Screen.height*4/5));
        for (int i = 0; i < rows; i++)
        {
			Hashtable data_temp = (Hashtable)showData [i];
            for (int j = 0; j < colums; j++)
            {
				string str = (data_temp[j]).ToString();

				//Debug.Log ("data["+i+"],["+j+"]===="+str);
				GUI.Button(new Rect(0 + (labelWidth * j), 0 + (labelHeight * i), labelWidth, labelHeight), str);
            }
        }
        GUI.EndScrollView();
		GUI.EndGroup ();
    }

	public void CreateTableView(Hashtable data){
        rows = data.Count;
		foreach(DictionaryEntry hal in data)
        {
			colums = ((Hashtable)hal.Value).Count;
        }
        showData = data;
    }

    public void UpdateTableData() {

    }

	public void Show(){
        showTable = true;
	}
}
