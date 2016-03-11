using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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

    public void OnApplicationQuit()
    {
        GameWorld.getInstance().GameWorldDestroy();
    }

    public void OnBtnClick() {
        //click will create table view all the time
		GameObject ifhas=GameObject.Find("AllReocrdView");
        if (ifhas != null) {
			TableLayer has = ifhas.GetComponent<TableLayer> ();
			has.Show ();
            return;
        }

		//get max width of the table
		int maxTableWidth =0;
		GameObject btnobj = GameObject.Find ("ButtonLogOut");

		UnityEngine.RectTransform rt = btnobj.GetComponent<RectTransform> ();

		Vector3 vecp=btnobj.transform.position;
		maxTableWidth = (int)(vecp.x-rt.rect.width/2);

		GameObject msgo = new GameObject ("AllReocrdView");
		TableLayer tbl = msgo.AddComponent<TableLayer> ();
		tbl.CreateTableView (app.model.MoneyRecord.Instance().GetRecordData(),maxTableWidth);
		tbl.Show ();
		HideOther ("AllReocrdView");
        
    }

    public void OnCreateNewClick() {
		//create new record
        GameWorld.getInstance().loadSceneWithoutLoading("CreateNewRecord");
    }

    public void OnLogOutClick() {
        //clear work
        //logout work
        GameWorld.getInstance().LogOut();
        GameWorld.getInstance().loadSceneWithoutLoading("LoginScene");
    }

	public void OnCountYearClick(){
		//cout year data
		GameObject ifhas=GameObject.Find("CountYearView");
		if (ifhas != null) {
			TableLayer has = ifhas.GetComponent<TableLayer> ();
			has.Show ();
			return;
		}

		//get max width of the table
		int maxTableWidth =0;
		GameObject btnobj = GameObject.Find ("ButtonLogOut");

		UnityEngine.RectTransform rt = btnobj.GetComponent<RectTransform> ();

		Vector3 vecp=btnobj.transform.position;
		maxTableWidth = (int)(vecp.x-rt.rect.width/2);

		GameObject msgo = new GameObject ("CountYearView");
		TableLayer tbl = msgo.AddComponent<TableLayer> ();
		tbl.CreateTableView (DetailService.LoadCountYearData(),maxTableWidth);
		tbl.Show ();
		HideOther ("CountYearView");

	}

	public void OnCountMonthClick(){
		GameObject ifhas=GameObject.Find("CountMonthView");
		if (ifhas != null) {
			TableLayer has = ifhas.GetComponent<TableLayer> ();
			has.Show ();
			return;
		}

		//get max width of the table
		int maxTableWidth =0;
		GameObject btnobj = GameObject.Find ("ButtonLogOut");

		UnityEngine.RectTransform rt = btnobj.GetComponent<RectTransform> ();

		Vector3 vecp=btnobj.transform.position;
		maxTableWidth = (int)(vecp.x-rt.rect.width/2);

		GameObject msgo = new GameObject ("CountMonthView");
		TableLayer tbl = msgo.AddComponent<TableLayer> ();
		tbl.CreateTableView (DetailService.LoadCountMonthData (),maxTableWidth);
		tbl.Show ();
		HideOther ("CountMonthView");
	}
	public void OnCountClassesClick(){
		
		GameObject ifhas=GameObject.Find("CountClassesView");
		if (ifhas != null) {
			TableLayer has = ifhas.GetComponent<TableLayer> ();
			has.Show ();
			return;
		}

		//get max width of the table
		int maxTableWidth =0;
		GameObject btnobj = GameObject.Find ("ButtonLogOut");

		UnityEngine.RectTransform rt = btnobj.GetComponent<RectTransform> ();

		Vector3 vecp=btnobj.transform.position;
		maxTableWidth = (int)(vecp.x-rt.rect.width/2);

		GameObject msgo = new GameObject ("CountClassesView");
		TableLayer tbl = msgo.AddComponent<TableLayer> ();
		tbl.CreateTableView (DetailService.LoadCountClassesData (),maxTableWidth);
		tbl.Show ();
		HideOther ("CountClassesView");
	}

	public void OnProActionClick(){
		//go to superadmin
	}

	private void HideOther(string keepCompolent){
		if (keepCompolent != "CountClassesView") {
			GameObject ifhas1 = GameObject.Find ("CountClassesView");
			if (ifhas1 != null) {
				ifhas1.SetActive (false);
				Destroy (ifhas1);
			}
		} else {
			GameObject ifhas1 = GameObject.Find ("CountClassesView");
			if (ifhas1 != null) {
				ifhas1.SetActive (true);
			}
		}
		if (keepCompolent != "CountMonthView") {
			GameObject ifhas1 = GameObject.Find ("CountMonthView");
			if (ifhas1 != null) {
				ifhas1.SetActive (false);
				Destroy (ifhas1);
			}
		} 
		if (keepCompolent != "CountYearView") {
			GameObject ifhas1 = GameObject.Find ("CountYearView");
			if (ifhas1 != null) {
				ifhas1.SetActive (false);
				Destroy (ifhas1);
			}
		}
		if (keepCompolent != "AllReocrdView") {
			GameObject ifhas1 = GameObject.Find ("AllReocrdView");
			if (ifhas1 != null) {
				ifhas1.SetActive (false);
				Destroy (ifhas1);
			}
		} 
	}
}
