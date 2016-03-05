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

    private int HeaderHeight = 0;
    private int Headerwidth = Screen.width/20;

	void OnGUI(){
        //update all times
        //Todo
        //use data colums rows
        //use data length max to decided the label lenth
        //
        Hashtable header = new Hashtable();
        header["0"] = "序号";
        header["1"] = "日期";
        header["2"] = "记录类别";
        header["3"] = "支付类型";
        header["4"] = "支付值";
        header["5"] = "备注";
        header["6"] = "记录时间";
        string jsdata = LitJson.JsonMapper.ToJson(header);

        JsonData mydata = LitJson.JsonMapper.ToObject(jsdata);

        if (!showTable){
			return;
		}
		GUI.contentColor = Color.red;
        GUI.BeginGroup (new Rect (Screen.width/10,Screen.height/10,Screen.width*4/5,Screen.height*4/5));
        
		srollPostion=GUI.BeginScrollView(new Rect(0, 0, Screen.width * 4 / 5, Screen.height * 4 / 5), srollPostion, new Rect(0, 0, labelWidth * colums, labelHeight * rows));
        GUI.Button(new Rect(0,0,Headerwidth,labelHeight),"");
        for (int b=1;b<=colums;b++) {
            GUI.Button(new Rect(Headerwidth+(b-1)*labelWidth,0,labelWidth,labelHeight),(string)mydata[(b-1).ToString()]);
        }
        for (int i = 1; i <= rows; i++)
        {
            GUI.Button(new Rect(0, i * labelHeight, Headerwidth, labelHeight), i.ToString());
            Hashtable data_temp = (Hashtable)showData [i-1];
            for (int j = 1; j <=colums; j++)
            {
				string str = (data_temp[j-1]).ToString();

				//Debug.Log ("data["+i+"],["+j+"]===="+str);
				GUI.Button(new Rect(Headerwidth + (labelWidth * (j-1)), 0 + (labelHeight * i), labelWidth, labelHeight), str);
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
