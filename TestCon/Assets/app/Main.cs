using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	private string show_str = "";
	private LFL_NetWork network = null;

	private string modelId = "";
	private string actionId ="";

	private string msg = "";

	// Use this for initialization
	void Start () {
		if (network == null){
			network = LFL_NetWork.getInstance ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.TextArea (new Rect (10, 10, 500, 400), show_str);
		modelId =GUI.TextField (new Rect (520, 10, 80, 30), modelId);
		actionId=GUI.TextField (new Rect (600, 10, 80, 30), actionId);
		msg =GUI.TextField (new Rect (520, 50, 160, 30), msg);
		if (GUI.Button (new Rect (690, 10, 160, 30), "ADD_STR")) {
			show_str += "aaaaaaaaa\n";
		}
		if (GUI.Button (new Rect (690, 50, 160, 30), "SEND")) {
			string str = "SEND_MSG::" + modelId + "-" + actionId + " data =" + msg;

			show_str += str+ "\n";

		}
		if (GUI.Button (new Rect(690,90,160,30),"connect")){
			network.connectServer ();
		}
		if (GUI.Button(new Rect(690,130,160,30),"disconnect")){
			network.closeConnection ();
		}

	}
}
