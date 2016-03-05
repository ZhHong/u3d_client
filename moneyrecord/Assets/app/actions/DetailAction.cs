using UnityEngine;
using System.Collections;
using app.manager;
using app.service;
using app.layer;

public class DetailAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//load default data for user
		GameWorld.getInstance().LoadDefaultData();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnBtnClick() {
        //click will create table view all the time
        TableLayer ifhas=GetComponent<TableLayer>();
        if (ifhas != null) {
            return;
        }
        GameObject tbl = new GameObject("TableLayer");
        TableLayer tablay = tbl.AddComponent<TableLayer>();
        tablay.CreateTableView(app.model.MoneyRecord.Instance().GetRecordData());
        tablay.Show();
    }

    public void OnCreateNewClick() {
        //create new record 
		GameObject msgl = new GameObject("MsgLayer");
		MsgLayer msg = msgl.AddComponent<MsgLayer> ();
		msg.Show ("Create New Record");
    }
}
