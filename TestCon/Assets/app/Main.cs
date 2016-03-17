using UnityEngine;
using System.Collections;
using System;

public class Main : MonoBehaviour {

	private string show_str = "";
	private LFL_NetWork network = null;

	private string modelId = "";
	private string actionId ="";

	private string msg = "";

    private Hashtable protocol = new Hashtable();

	// Use this for initialization
	void Start () {
		if (network == null){
			network = LFL_NetWork.getInstance ();
		}
        //init protocol
        protocol["0-0-s"] = "['String','String','String','String','Int','Int']";
        protocol["0-0-c"] = "['Byte','Int','Byte','Int']";

		string str =Plugins.LocalData_Trans.LocalData_Trans.Encrypto("singularity","singularitysingularitysingularit");
		Debug.Log ("========="+str);
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
			
		}
		if (GUI.Button (new Rect (690, 50, 160, 30), "SEND")) {
			string str =  modelId + "-" + actionId + " data =" + msg;

            string statc = "0,0,'538642', '1', '10002', '1', 99000000, 999999";

            AppendShowString(str);

		}
        if (GUI.Button(new Rect(690, 90, 160, 30), "connect")) {
            try { 
                network.connectServer();
                AppendShowString("connect to server");
            }
            catch (Exception e) {
                AppendShowString(e.ToString());
            }
		}
		if (GUI.Button(new Rect(690,130,160,30),"disconnect")){
            try
            {
                network.closeConnection();
                AppendShowString("disconnect server");
            }catch(Exception e)
            {
                AppendShowString(e.ToString());
            }
			
		}

	}

    private void AppendShowString(string str)
    {
        string str_time =DateTime.Now.ToString();
        show_str += "["+str_time+"]" + " MSG_INFO " + str+"\n";
    }

    private void EncodeMsg(int modelId, int actionId, string[] key_table,int index, string msg ) {

    }

    private string GetProtocol(string pro_key)
    {
        if (protocol.ContainsKey(pro_key)) {
            return protocol[pro_key].ToString();
        }
        return "";
    }
}
