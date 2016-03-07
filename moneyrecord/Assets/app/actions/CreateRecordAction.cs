using UnityEngine;
using System.Collections;
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


    public void OnMoneyInputEnd(string money)
    {
        //on money input end check it
    }

    public void OnMsgInputEnd(string msg)
    {
        //on msg input end check it
    }


    public void OnYearSelected(int index) {
        //on year selected
    }

    public void OnMonthSelected(int index)
    {
        //on year selected
    }

    public void OnDaySelected(int index) {

    }

    public void OnMoneyClassSelected(int index)
    {

    }

    public void OnPayTypeSelected(int index)
    {

    }

    private void SetTextComponetTextState(string componetName,bool state) {
        //set warning text
    }

    private void ResetData() {
        //call when data not need
    }
}
