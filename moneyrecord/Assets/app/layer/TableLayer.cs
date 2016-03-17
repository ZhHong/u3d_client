using UnityEngine;
using System.Collections;

public class TableLayer : MonoBehaviour {

	private static bool showTable = false;

	void OnGUI(){
		//Todo
		//use data colums rows
		//use data length max to decided the label lenth
		//
		if (!showTable){
			return;
		}
		int rows = 10;
		int colums = 10;
		int labelWidth = 100;
		int labeHegith = 30;
		GUI.backgroundColor = Color.red;
		GUI.BeginScrollView (new Rect (100, 100, labelWidth * 10, labeHegith * 10),Vector2.zero,new Rect(0,0,labelWidth*3,labeHegith*2));
		for(int i =0;i<rows;i++){
			for(int j=0;j<colums;j++){
				GUI.Label (new Rect (100+(labelWidth*j), 100+(labeHegith*i), labelWidth, labeHegith), "mylabel");
			}
		}
		GUI.EndScrollView ();
	}

	public static void CreateTableView(){
		
	}

	public static void Show(){
		
	}
}
