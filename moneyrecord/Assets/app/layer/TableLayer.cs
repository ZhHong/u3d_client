using UnityEngine;
using System.Collections;
using LitJson;

public class TableLayer : MonoBehaviour {
    //example http://blog.csdn.net/aisajiajiao/article/details/17472503
    private static bool showTable = false;

    private Vector2 srollPostion = Vector2.zero;
    private int rows = 0;
    private int colums = 0;
    private int labelWidth = 40;
    private int labelHeight = 20;
    private LitJson.JsonData showData = null;

	void OnGUI(){
        //Todo
        //use data colums rows
        //use data length max to decided the label lenth
        //
		if (!showTable){
			return;
		}
        

        srollPostion=GUI.BeginScrollView(new Rect(100, 100, labelWidth * 5, labelHeight * 4), srollPostion, new Rect(0, 0, labelWidth * colums, labelHeight * rows));
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < colums; j++)
            {
                GUI.Label(new Rect(0 + (labelWidth * j), 0 + (labelHeight * i), labelWidth, labelHeight), (showData[i][j]).ToString());
            }
        }
        GUI.EndScrollView();
    }

	public void CreateTableView(JsonData data){
        rows = data.Count;
        foreach(JsonData hal in data)
        {
            colums = hal.Count;
        }
        showData = data;
    }

    public void UpdateTableData() {

    }

	public void Show(){
        showTable = true;
	}
}
