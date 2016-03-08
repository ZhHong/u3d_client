using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using app.manager;

public class CreateRecordAction : MonoBehaviour {

    private int year = 0;
    private int month = 0;
    private int day = 0;

    private int moneyClass = 0;
    private int payType = 0;

    private double payValue = 0.0;
    private string noteMsg = "";


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCancelClick()
    {
        ResetData();
        GameWorld.getInstance().loadSceneWithoutLoading("DetailScene");
    }

    public void OnAddNewRecord() {
        //create action
        //reset data
    }


    public void setMoneyInputEnd(string payStr)
    {
        //on money input end check it
        double temp = double.Parse(payStr);
        payValue=Math.Round(temp, 2);
    }

    public void setMsgInputEnd(string msg)
    {
        //on msg input end check it
        Debug.Log("================" + msg.Length);
        
    }


    public void setYearSelected(Dropdown drp) {
        //on year selected
        year = int.Parse(drp.captionText.text);
    }

    public void setMonthSelected(Dropdown drp)
    {
        month = int.Parse(drp.captionText.text);
    }

    public void setDaySelected(Dropdown drp) {
        //need check month 2
        day = int.Parse(drp.captionText.text);
    }

    public void setMoneyClassSelected(Dropdown drp)
    {
        moneyClass = int.Parse(drp.captionText.text);
    }

    public void setPayTypeSelected(Dropdown drp)
    {
        payType = int.Parse(drp.captionText.text);
    }

    private void SetTextComponetTextState(string componetName,bool state) {
        //set warning text
    }


    private void CheckMonth2Day() {
        //check month 2
        bool changeDay = false;
        if (year !=0 && month !=0 && day!=0 && ((year%100 !=0 && year%4 ==0)|(year %400 ==0)) && month ==2) {
            if(day > 29)
            {
                day = 29;
                changeDay = true;
            }
        }
        else
        {
            if (day >28) {
                day = 28;
                changeDay = true;
            }
        }
        if (changeDay)
        {
            SetTextComponetTextState("TextTimeWarning",false);
        }
    }

    private void ResetData() {
        //call when data not need
    }
}
