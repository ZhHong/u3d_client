using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class Main : MonoBehaviour {
	private Client mClient = null;
	private string mText = "";
    private string mText2 = "";
	private string mText3 = "";

	void Start () {
		//new TestUnit ().Run ();
		//new Test ().Run ();
		//new TestAll ().Run ();
		new TestRpc ().Run ();
		//new TestPackUnPack ().run ();
	}

	void OnGUI () {
		if (mClient == null) {
			mClient = new Client ();
		}
		//if (GUI.Button (new Rect (10, 10, 100, 100), "Benchmark")){
		//	new Benchmark().Run ();
		//}
		if (mClient.isConnect) {
			GUI.enabled = false;
		}
		if (GUI.Button (new Rect (10, 10, 100, 100), "connect")){
			if(mClient == null || !mClient.isConnect){
				if (mClient ==  null){
					mClient = new Client ();
				}
				mClient.connect();
			}
		}

		GUI.enabled = true;
		if (mClient != null) {

			mText = GUI.TextField (new Rect(120, 10, 200, 40), mText, 25);
            mText2 = GUI.TextField(new Rect(120, 50, 200, 40), mText2, 25);
			mText3 = GUI.TextField (new Rect(120,90,200,40),mText3,25);
			if (GUI.Button (new Rect (330, 10, 80, 40), "Get")){
				if (mClient.isConnect) {
					mClient.SendGet (mText);
					mText = "";
				}
			}
			//GUI.enabled = false;
            if (GUI.Button(new Rect(330, 50, 80, 40), "Set")) {
				if (mClient.isConnect) {
					mClient.SendSet(mText2,mText2);
					mText2 = "";
				}
            }
			if (GUI.Button (new Rect (330, 90, 80, 40), "rpc")) {
				if (mClient.isConnect) {
					mClient.SendUserInfo (int.Parse(mText3));
					mText3 = "";
				}
			}
            GUI.enabled = false;
		}

	}
}
