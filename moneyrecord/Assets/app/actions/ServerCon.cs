using UnityEngine;
using System.Collections;
using System;
using System.Text;
using app.network;

public class ServerCon : MonoBehaviour {
	private string show_str = "";
	private LFL_NetWork network = null;

	private string modelId = "";
	private string actionId ="";

	private string msg = "";

	private Hashtable protocol = new Hashtable();

    private Vector3 scrollPosition = Vector3.zero;

	public void OnApplicationQuit(){
		if(network !=null){
			network.closeConnection ();
		}
	}

	// Use this for initialization
	void Start () {
		if (network == null){
			network = LFL_NetWork.getInstance ();
		}
		//init protocol
		protocol["0-0-s"] = "['String','String','String','String','Int','Int']";
		protocol["0-0-c"] = "['Byte','Int','Byte','Int']";

		//string str =Plugins.LocalData_Trans.LocalData_Trans.Encrypto("singularity","singularitysingularitysingularit");
		//Debug.Log ("========="+str);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
        int btnWidth = Screen.width / 8;
        int btnHight = Screen.height /20;

		GUI.TextArea (new Rect (Screen.width/20, Screen.height/20, Screen.width/2, Screen.height*2/3), show_str);
		modelId =GUI.TextField (new Rect (Screen.width*11/20, Screen.height/20, btnWidth, btnHight), modelId);
		actionId=GUI.TextField (new Rect (Screen.width*11/20+btnWidth, Screen.height/20, btnWidth, btnHight), actionId);
		msg =GUI.TextField (new Rect (Screen.width * 11 / 20, Screen.height/20+btnHight, btnWidth*2, btnHight), msg);
		if (GUI.Button (new Rect (Screen.width*11/20+2*btnWidth, Screen.height/20, btnWidth, btnHight), "清除记录")) {
            show_str = "";
		}
		if (GUI.Button (new Rect (Screen.width*11/20+2*btnWidth, Screen.height/20+btnHight, btnWidth, btnHight), "发送")) {
			string str =  modelId + "-" + actionId + " data =" + msg;
			AppendShowString(str);

		}
		if (GUI.Button(new Rect(Screen.width * 11 / 20 + 2 * btnWidth, Screen.height / 20 + btnHight*2, btnWidth, btnHight), "连接")) {
			try { 
				network.connectServer();
				AppendShowString("connect to server");
			}
			catch (Exception e) {
				AppendShowString(e.Message);
			}
		}
		if (GUI.Button(new Rect(Screen.width * 11 / 20 + 2 * btnWidth, Screen.height / 20 + btnHight*3, btnWidth,btnHight),"断开连接")){
			try
			{
				network.closeConnection();
				AppendShowString("disconnect server");
			}catch(Exception e)
			{
				AppendShowString(e.Message);
			}

		}
        if (GUI.Button(new Rect(Screen.width * 11 / 20 + 2 * btnWidth, Screen.height / 20 + btnHight * 4, btnWidth, btnHight), "返回")) {
            app.manager.GameWorld.getInstance().loadSceneWithoutLoading("DetailScene");
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
