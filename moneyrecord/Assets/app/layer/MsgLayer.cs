using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace app.layer{
public class MsgLayer : MonoBehaviour {

		private static string showString = "";
		private static int showWindow = 0;

        private int ShowWindowWidth = Screen.width ;
        private int ShowWIndowHeght = Screen.height ;

        private float RadioValue = 0.8f;

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

            float labelWidth = ShowWindowWidth * RadioValue / 6;
            float labelHeight = ShowWIndowHeght * RadioValue / 10;

            float BtnWidth = ShowWindowWidth * RadioValue / 10;
            float BtnHeight = ShowWIndowHeght * RadioValue / 10;

            //  width  2btn  3spaces
            float spaceWidth = (ShowWindowWidth * RadioValue - BtnWidth * 2) / 3;
            // height  
            float spaceHeight = (ShowWIndowHeght * RadioValue) - 2 * BtnHeight;

            //label  space height width
            float distancehight = (spaceHeight)/50;
            //label
            GUIStyle gsl= new GUIStyle();
            gsl.alignment = TextAnchor.MiddleLeft;
            gsl.fontSize =(int)labelHeight * 2/5;
            GUI.Label(new Rect(distancehight, distancehight, labelWidth, labelHeight), "记录时间：下拉列表",gsl);
            GUI.Label(new Rect(distancehight, distancehight * 2 + labelHeight, labelWidth*2, labelHeight), "记录时间：下拉列表",gsl);
            GUI.Label(new Rect(distancehight, distancehight * 3 + labelHeight * 2, labelWidth, labelHeight), "记录类别：下拉列表", gsl);
            GUI.Label(new Rect(distancehight, distancehight * 4 + labelHeight * 3, labelWidth, labelHeight), "记录类别：下拉列表", gsl);
            GUI.Label(new Rect(distancehight, distancehight * 5 + labelHeight * 4, labelWidth, labelHeight), "支付类型：下拉列表", gsl);
            GUI.Label(new Rect(distancehight, distancehight * 6 + labelHeight * 5, labelWidth, labelHeight), "支付类型：下拉列表", gsl);
            GUI.Label(new Rect(distancehight, distancehight * 7 + labelHeight * 6, labelWidth, labelHeight), "支付金额：文本输入框", gsl);
            GUI.TextField(new Rect(distancehight+labelWidth, distancehight * 7 + labelHeight * 6, labelWidth, labelHeight),"金额");
            GUI.Label(new Rect(distancehight, distancehight * 8 + labelHeight * 7, labelWidth, labelHeight), "支付金额：文本输入框", gsl);
            GUI.Label(new Rect(distancehight, distancehight * 9 + labelHeight * 8, labelWidth, labelHeight), "备    注：文本输入框", gsl);
            GUI.TextField(new Rect(distancehight+labelWidth, distancehight * 9 + labelHeight * 8, labelWidth, labelHeight), "备注");
            GUI.Label(new Rect(distancehight, distancehight * 10 + labelHeight * 9, labelWidth, labelHeight), "备    注：文本输入框", gsl);

            //btn



            if (GUI.Button (new Rect (2*spaceWidth+BtnWidth, spaceHeight, BtnWidth, BtnHeight), "关闭")) {
				showWindow +=1;
			}
            if (GUI.Button(new Rect(spaceWidth, spaceHeight, BtnWidth,BtnHeight),"创建")) {
                showWindow +=1;
                Debug.Log("create new record============");
            }
		}

		void OnGUI(){
			if((showWindow%2)!=0){
				GUI.Window (0, new Rect (Screen.width * ((1-RadioValue)/2), Screen.height * ((1-RadioValue)/2), ShowWindowWidth * RadioValue, ShowWIndowHeght * RadioValue), doWindow, showString);
            }
		}
	}
}