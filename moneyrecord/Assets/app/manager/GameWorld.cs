using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using Plugins.LocalData_Trans;
using app.dao;
using app.utils;
using app.model;
using app.proto;
namespace app.manager
{
    public sealed class GameWorld
    {
        private const int SUCCESS_STEP = 4;

        public string nextloadScene;

        private static GameWorld instance;
        private int init_step = 0;
        //config server info
        private LitJson.JsonData serverInfo;

		private static SqliteDB sqldb= null;

        private string[] sqlStatement = { };

		private int loginState =0;

        public ErrorData errorData = null;

        private LitJson.JsonData gameSave = null;


        private GameWorld()
        {
            var action = initGameWorld();
			if (action != SUCCESS_STEP){
                Debug.Log(" init game world field============");
            }
        }
        private int initGameWorld()
        {
            init_step = initConfig(init_step);
            init_step = initManager(init_step);
            init_step = initOtherData(init_step);
			init_step = initSqliteDB (init_step);
            return init_step;
        }

        public static GameWorld getInstance()
        {
            if (instance == null)
            {
                instance = new GameWorld();
            }
            return instance;
        }

		public void GameWorldDestroy()
		{
            //destroy the game world
            if (sqldb != null) {
                sqldb.CloseSqlConnection();
            }
            if (gameSave != null) {
                string gamev=gameSave.ToJson();
                string gamesave = Application.persistentDataPath + Utils.GLOBAL_GAME_SAVE_PATH;
                Debug.Log("app over set replace game save=============================="+ gamev);
                LocalData_Trans.SetData(gamesave, gamev);
            }

		}

		public int getLoginState(){
            //login process
			return loginState;
		}

        public void LogOut() {
            //log out process
            loginState = 0;
        }

        public void loadSceneWithLoading(string _nextscene)
        {
            nextloadScene = _nextscene;
            SceneManager.LoadScene("loading_scene");
        }

        public void loadSceneWithoutLoading(string _nextscene)
        {
            nextloadScene = _nextscene;
            SceneManager.LoadScene(_nextscene);
        }
        private int initConfig(int _init_s)
        {
            //write and read game save data
            /*
            string dirpath = Application.persistentDataPath + "/local";
            LocalData_Trans.CreateDirectory(dirpath);
			string fileName = dirpath + Utils.GLOBAL_GAME_SAVE_PATH;
            Hashtable data = new Hashtable();
            data["name"] = "zh";
            data["age"] = 123;
            string json_array = LitJson.JsonMapper.ToJson(data);
            LocalData_Trans.SetData(fileName, json_array);

            string get_data = LocalData_Trans.GetData(fileName);

            LitJson.JsonData jsdata = LitJson.JsonMapper.ToObject(get_data);
            Debug.Log(get_data);
            Debug.Log("get jsdata ==============jsdata['name']===" + jsdata["name"]);
            //Hashtable get_tab = LitJson.JsonMapper.ToObject (data);
            //Debug.Log ("get tab name==============="+get_tab["name"]);
			*/

            //load/write secret gamesave
            //check gamesave file if exists
            string gamesave = Application.persistentDataPath + Utils.GLOBAL_GAME_SAVE_PATH;
            bool issaveExists =LocalData_Trans.IsFileExists(gamesave);

            if (!issaveExists)
            {
                //write default gamesave
                Hashtable default_config = new Hashtable();
                default_config["re_name"] = "";
                default_config["re_pass"] = "";
                string jsonarry = LitJson.JsonMapper.ToJson(default_config);
                LitJson.JsonData gv = LitJson.JsonMapper.ToObject(jsonarry);
                Debug.Log("init default save========"+jsonarry);
                LocalData_Trans.SetData(gamesave, jsonarry);
                SetUserSaveDef(gv);
            }
            else
            {
                //get gamesave
                string get_save = LocalData_Trans.GetData(gamesave);
                Debug.Log("get game save ========"+get_save);
                LitJson.JsonData game_str = LitJson.JsonMapper.ToObject(get_save);
                SetUserSaveDef(game_str);

            }

            /*
			string configpath = Application.dataPath + Utils.GLOBAL_CONFIG_PATH;
            Hashtable config_data = new Hashtable ();
            Hashtable info = new Hashtable ();
            info ["host"] = "192.168.1.4";
            info ["port"] = "8888";
            config_data ["server1"] = info;

            string json_array_config = LitJson.JsonMapper.ToJson (config_data);
            LocalData_Trans.SetData (configpath, json_array_config);

            string get_config = LocalData_Trans.GetData(configpath);
            Debug.Log("get config data===============" + get_config);
            LitJson.JsonData config_js = LitJson.JsonMapper.ToObject(get_config);
            LitJson.JsonData ss = config_js["server1"];
            Debug.Log(ss["port"]);
            Debug.Log(ss["host"]);
            */

            //get and run db file
            //string dbInitPath = Application.dataPath + Utils.GLOBAL_DBINIT_PATH;
            TextAsset data = Resources.Load ("INITDB") as TextAsset;

            //string getDbInit = LocalData_Trans.GetData(dbInitPath,false);
			string getDbInit = data.text;
            sqlStatement = getDbInit.Split('#');


            //initConfigInfo(config_js);
			_init_s += 1;
            return _init_s;
        }

        private int initManager(int _init_s)
        {
			_init_s += 1;
            return _init_s;
        }

        private int initOtherData(int _init_s)
        {
            errorData = ErrorData.getInstance();
			_init_s += 1;
            return _init_s;
        }

		private int initSqliteDB(int _init_s)
		{
			if (sqldb == null) {
				//get db file location
				string db_file_location ="Data Source = "+Application.persistentDataPath+Utils.GLOBAL_DB_FILE_PATH;
				sqldb = SqliteDB.getInstance (db_file_location, sqlStatement);
			}
			_init_s += 1;
			return _init_s;
		}

        private void initConfigInfo(LitJson.JsonData jsdata)
        {
            serverInfo = jsdata;
        }
        public LitJson.JsonData getServerInfo(string serverid)
        {
            return serverInfo[serverid];
        }

        public void initNetWork()
        {
        }
			
		public void CheckUserLogin(string username, string password)
		{
			//sqldb.CreateUser(username, password);
			loginState =  sqldb.CheckUserLogin(username, password);
		}

        public string CheckUserInDB(string username) {
            return sqldb.CheckUserIfExsits(username);
        }

        public void CreateUser(string username,string password){
			sqldb.CreateUser (username, password);
		}

		public Hashtable LoadDefaultData(){
            return sqldb.GetCurrentMoneyRecord(User.Instance().GetUid());
		}

		public void CreateNewRecord(int year,int month,int day,int mc,int py,double payValue,string noteMsg){
			//create new record
			sqldb.CreateNewRecord(year,month,day,mc,py,payValue,noteMsg);
		}

		public Hashtable CountDataFromDB(int type){
			return sqldb.LoadCoutDataByCountType (type);
		}

        private void SetUserSaveDef(LitJson.JsonData js)
        {
            gameSave = js;
        }

        public void SetUserSaveDef(string savetype, string data) {
            gameSave[savetype] = data;
            Debug.Log(gameSave.ToJson()+">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }

        public string GetUserSaveDef(string savetype)
        {
            return gameSave[savetype].ToString();
        }
    }
}
