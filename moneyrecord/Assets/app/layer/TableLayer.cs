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
        

        srollPostion=GUI.BeginScrollView(new Rect(100, 100, labelWidth * 5, labelHeight * 4), srollPostion, new Rect(0, 0, labelWidth * colums, labelHeight * rows));
        for (int i = 0; i < rows; i++)
        {
			Hashtable data_temp = (Hashtable)showData [i];
            for (int j = 0; j < colums; j++)
            {
				string str = (data_temp[j]).ToString();

				//Debug.Log ("data["+i+"],["+j+"]===="+str);
                GUI.Label(new Rect(0 + (labelWidth * j), 0 + (labelHeight * i), labelWidth, labelHeight), str);
            }
        }
        GUI.EndScrollView();
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
