using UnityEngine;
using System.Collections;
namespace app.layer{
public class MsgLayer : MonoBehaviour {

		private static string showString = "";
		private static bool showWindow = false;

	// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		public void Show(string show_str){
			showString = show_str;
			showWindow = true;
		}

		void doWindow(int windowId){
			GUI.TextField (new Rect (40, 30, 90, 30), "username or password error");
			if (GUI.Button (new Rect (10, 30, 80, 20), "close")) {
				showWindow = false;
			}
		}

		void OnGUI(){
			if(showWindow){
				GUI.Window (0, new Rect (100, 100, 300, 400), doWindow, showString);
			}
		}
	}
}