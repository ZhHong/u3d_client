using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using app.manager;
using app.utils;

public class CreateRecordAction : MonoBehaviour
{

    private int year = 0;
    private int month = 0;
    private int day = 0;

    private string moneyClass = "";
    private string payType = "";

    private double payValue = 0.0;
    private string noteMsg = "";

    //private bool CheckYear = false;
    //private bool CheckMonth = false;
    //private bool CheckDay = false;
    //private bool CheckClass = false;
    //private bool CheckType = false;
    //private bool CheckValue = false;
    //private bool CheckMsg = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnApplicationQuit()
    {
        GameWorld.getInstance().GameWorldDestroy();
    }

    public void OnCancelClick()
    {
        ResetData();
        GameWorld.getInstance().loadSceneWithoutLoading("DetailScene");
    }

    public void OnAddNewRecord()
    {
        //create action
        CheckCanCreate();
        Debug.Log("time===" + year + "/" + month + "/" + day + ",======moneyclass=" + moneyClass + ",===pay_type=" + payType + ",=======pay_value" + payValue + ",======not msg=" + noteMsg);
        int mc = GameWorld.getInstance().errorData.GetMoneyTypeIndex(moneyClass);
        int py = GameWorld.getInstance().errorData.GetPayTypeStr(payType);

        if (mc == -1 | py == -1)
        {
            //throw error data
            return;
        }
        if (payValue == 0.0)
        {
            //throw error
            GameWorld.getInstance().errorData.SetErrorData("MONEY_CAN_NOT_NONE");
            SetTextComponetTextState("TextMoneyWarning", false);
            return;
        }
        if (noteMsg == "")
        {
            GameWorld.getInstance().errorData.SetErrorData("MSG_CAN_NOT_NONE");
            SetTextComponetTextState("TextMsgWarning", false);
            return;
        }

        //create args:{year,month,day,moneyclassvalue,payTypeValue,payValue,noteMsg}
        GameWorld.getInstance().CreateNewRecord(year, month, day, mc, py, payValue, noteMsg);
        //reset data
        ResetData();
    }


    public void setMoneyInputEnd(string payStr)
    {
        //on money input end check it
        if (payStr.Length == 0)
        {
            GameWorld.getInstance().errorData.SetErrorData("MONEY_CAN_NOT_NONE");
            SetTextComponetTextState("TextMoneyWarning", false);
            return;
        }
        SetTextComponetTextState("TextMoneyWarning", true);
        double temp = double.Parse(payStr);
        payValue = Math.Round(temp, 2);
    }

    public void setMsgInputEnd(string msg)
    {
        //on msg input end check it
        if (msg.Length == 0)
        {
            //not none
            GameWorld.getInstance().errorData.SetErrorData("MSG_CAN_NOT_NONE");
            SetTextComponetTextState("TextMsgWarning", false);
            return;
        }
        SetTextComponetTextState("TextMsgWarning", true);
        noteMsg = msg;

    }


    public void setYearSelected(Dropdown drp)
    {
        //on year selected
        Debug.Log(drp.captionText.text);
        year = int.Parse(drp.captionText.text);
        CheckMonth2Day();
    }

    public void setMonthSelected(Dropdown drp)
    {
        month = int.Parse(drp.captionText.text);
        CheckMonth2Day();
    }

    public void setDaySelected(Dropdown drp)
    {
        //need check month 2
        day = int.Parse(drp.captionText.text);
        CheckMonth2Day();
    }

    public void setMoneyClassSelected(Dropdown drp)
    {
        moneyClass = drp.captionText.text;
    }

    public void setPayTypeSelected(Dropdown drp)
    {
        payType = drp.captionText.text;
    }

    private void SetTextComponetTextState(string componetName, bool state)
    {
        //set warning text
        GameObject gobj = GameObject.Find(componetName);
        string err = GameWorld.getInstance().errorData.GetErrorString();
        if (!state)
        {
            if (err != "")
            {
                if (gobj != null)
                {
                    Text t = gobj.GetComponent<Text>();
                    t.text = err;
                    t.color = Color.red;
                }
            }
        }
        else
        {
            //
            if (gobj != null)
            {
                Text t = gobj.GetComponent<Text>();
                t.text = "";
                t.color = Color.green;
            }
        }
    }


    private void CheckMonth2Day()
    {
        //check month 2
        bool changeDay = false;
        if (year != 0 && month != 0 && day != 0 && ((year % 100 != 0 && year % 4 == 0) | (year % 400 == 0)) && month == 2)
        {
            if (day > 29)
            {
                day = 29;
                GameObject gobj = GameObject.Find("DropdownTimeDay");
                if (gobj != null)
                {
                    Dropdown dpd = gobj.GetComponent<Dropdown>();
                    if (dpd != null)
                    {
                        //reset the value
                    }
                }
                changeDay = true;
            }
        }
        else
        {
            if (day > 28)
            {
                day = 28;
                changeDay = true;
            }
        }
        if (changeDay)
        {
            GameWorld.getInstance().errorData.SetErrorData("MONTH_2_CHANGED");
            SetTextComponetTextState("TextTimeWarning", false);
        }
        else
        {
            SetTextComponetTextState("TextTimeWarning", true);
        }
    }

    private void CheckCanCreate()
    {
        //check if can create new record
        //if (year == 0)
        //{
        //    year = 2016;
        //}
        //if (month == 0)
        //{
        //    month = 1;
        //}
        //if (day == 0)
        //{
        //    day = 1;
        //}
        if (year ==0) {
            GameObject gobj = GameObject.Find("DropdownTimeYear");
            if (gobj !=null) {
                Dropdown dpd = gobj.GetComponent<Dropdown>();
                year = int.Parse(dpd.captionText.text);
            }
        }
        if (month ==0) {
            GameObject gobj = GameObject.Find("DropdownTimeMonth");
            if (gobj != null)
            {
                Dropdown dpd = gobj.GetComponent<Dropdown>();
                month = int.Parse(dpd.captionText.text);
            }
        }
        if (day ==0) {
            GameObject gobj = GameObject.Find("DropdownTimeDay");
            if (gobj != null)
            {
                Dropdown dpd = gobj.GetComponent<Dropdown>();
                day = int.Parse(dpd.captionText.text);
            }
        }
        if (moneyClass =="") {
            GameObject gobj = GameObject.Find("DropdownMoneyClass");
            if (gobj != null)
            {
                Dropdown dpd = gobj.GetComponent<Dropdown>();
                moneyClass = dpd.captionText.text;
            }
        }
        if (payType =="") {
            GameObject gobj = GameObject.Find("DropdownPayType");
            if (gobj != null)
            {
                Dropdown dpd = gobj.GetComponent<Dropdown>();
                payType = dpd.captionText.text;
            }
        }
    }

    private void ResetData()
    {
        //call when data not need
        year = 0;
        month = 0;
        day = 0;

        moneyClass = "";
        payType = "";

        payValue = 0.0;
        noteMsg = "";


        //CheckYear = false;
        //CheckMonth = false;
        //CheckDay = false;
        //CheckClass = false;
        //CheckType = false;
        //CheckValue = false;
        //CheckMsg = false;

        GameObject gbj1 = GameObject.Find("InputFieldPayValue");
        GameObject gbj2 = GameObject.Find("InputFieldMsg");

        if (gbj1 != null)
        {
            InputField ipt = gbj1.GetComponent<InputField>();
            if (ipt != null)
            {
                ipt.text = "";
            }
        }
        if (gbj2 != null)
        {
            InputField ipt = gbj2.GetComponent<InputField>();
            if (ipt != null)
            {
                ipt.text = "";
            }
        }
    }
}
