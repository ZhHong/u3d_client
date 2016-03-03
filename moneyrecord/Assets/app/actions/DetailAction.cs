using UnityEngine;
using System.Collections;
using app.manager;
using app.service;

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
        GameObject tbl = new GameObject("TableLayer");
        TableLayer tablay = tbl.AddComponent<TableLayer>();
        //tablay.CreateTableView(app.model.MoneyRecord.Instance().GetRecordData());
        tablay.Show();
    }
}
