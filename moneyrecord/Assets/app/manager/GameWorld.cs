using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using Plugins.LocalData_Trans;
using app.dao;
using app.utils;
using app.model;
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

		public static void GameWorldDestroy()
		{
            //destroy the game world
            if (sqldb != null) {
                sqldb.CloseSqlConnection();
            }
		}

		public int getLoginState(){
			return loginState;
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
			*

            //load/write secret config
			/*
			string configpath = Application.dataPath + Utils.GLOBAL_CONFIG_PATH;
            Hashtable config_data = new Hashtable ();
            Hashtable info = new Hashtable ();
            info ["host"] = "192.168.1.4";
            info ["port"] = "8888";
            config_data ["server1"] = info;

            string json_array_config = LitJson.JsonMapper.ToJson (config_data);
            Debug.Log ("config json array================"+json_array);
            LocalData_Trans.SetData (configpath, json_array_config);

            string get_config = LocalData_Trans.GetData(configpath);
            Debug.Log("get config data===============" + get_config);
            LitJson.JsonData config_js = LitJson.JsonMapper.ToObject(get_config);
            LitJson.JsonData ss = config_js["server1"];
            Debug.Log(ss["port"]);
            Debug.Log(ss["host"]);
            */

			//get and run db file
            string dbInitPath = Application.dataPath + Utils.GLOBAL_DBINIT_PATH;
            string getDbInit = LocalData_Trans.GetData(dbInitPath,false);
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
			_init_s += 1;
            return _init_s;
        }

		private int initSqliteDB(int _init_s)
		{
			if (sqldb == null) {
				//get db file location
				string db_file_location ="Data Source = "+Application.dataPath+Utils.GLOBAL_DB_FILE_PATH;
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

        public int CheckUserInDB(string username) {
            int action = sqldb.CheckUserIfExsits(username);
            return action;
        }

        public void CreateUser(string username,string password){
			sqldb.CreateUser (username, password);
		}

		public void LoadDefaultData(){
            MoneyRecord.Instance().InitRecordFromDB(
            sqldb.GetCurrentMoneyRecord(1));
		}
		
    }
}
