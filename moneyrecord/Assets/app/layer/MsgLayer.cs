using UnityEngine;
using System.Collections;
namespace app.layer{
public class MsgLayer : MonoBehaviour {

		private static string showString = "";
		private static int showWindow = 0;

        private int ShowWindowWidth = Screen.width ;
        private int ShowWIndowHeght = Screen.height ;

	// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		public void Show(string show_str){
            // show str
            // show size
            if (show_str !="") {
			    showString = show_str;
            }
			showWindow +=1;
		}

		void doWindow(int windowId){
            int BtnWidth = ShowWindowWidth / 2 / 10;
            int BtnHeight = ShowWIndowHeght / 2 / 10;
            //  width  2btn  3spaces
            int spaceWidth = (ShowWindowWidth / 2 - BtnWidth * 2) / 3;
            // height  
            int spaceHeight = (ShowWIndowHeght / 2) - 2 * BtnHeight;
			if (GUI.Button (new Rect (2*spaceWidth+BtnWidth, spaceHeight, BtnWidth, BtnHeight), "close")) {
				showWindow +=1;
			}
            if (GUI.Button(new Rect(spaceWidth, spaceHeight, BtnWidth,BtnHeight),"create")) {
                showWindow +=1;
                Debug.Log("create new record============");
            }
		}

		void OnGUI(){
			if((showWindow%2)!=0){
				GUI.Window (0, new Rect (Screen.width/4, Screen.height/4, ShowWindowWidth/2, ShowWIndowHeght/2), doWindow, showString);
			}
		}
	}
}