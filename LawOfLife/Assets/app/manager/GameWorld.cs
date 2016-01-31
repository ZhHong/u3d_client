using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using app.protocol;
using Plugins.LocalData_Trans;
using app.network;
namespace app.manager
{
    public sealed class GameWorld
    {
        public void OnApplicationQuit()
        {
            //app close clean something
            lflnet.closeConnection();
        }

        ~GameWorld() {
            OnApplicationQuit();
        }

        private const int SUCCESS_STEP = 4;

        public string nextloadScene;
        private static GameWorld instance;
        private int init_step = 0;
        //config server info
        private LitJson.JsonData serverInfo;

        private LFL_NetWork lflnet;

        private GameWorld()
        {
            var action = initGameWorld();
            if (action != (int)ErrorData.ACTION_SUCCESS)
            {
                Debug.Log("PRINT ERROR DATA" + ErrorData.ACTIVITY_CONDITION_NO_ENOUGH);
            }
        }
        private int initGameWorld()
        {
            init_step = initConfig(init_step);
            init_step = initManager(init_step);
            init_step = initOtherData(init_step);
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
            Debug.Log("===================init data begin");
            string dirpath = Application.persistentDataPath + "/local";
            LocalData_Trans.CreateDirectory(dirpath);
            string fileName = dirpath + "/game.sav";
            Hashtable data = new Hashtable();
            data["name"] = "zh";
            data["age"] = 123;
            string json_array = LitJson.JsonMapper.ToJson(data);
            Debug.Log("my data=====================" + json_array);
            LocalData_Trans.SetData(fileName, json_array);

            string get_data = LocalData_Trans.GetData(fileName);

            LitJson.JsonData jsdata = LitJson.JsonMapper.ToObject(get_data);
            Debug.Log(get_data);
            Debug.Log("get jsdata ==============jsdata['name']===" + jsdata["name"]);
            //Hashtable get_tab = LitJson.JsonMapper.ToObject (data);
            //Debug.Log ("get tab name==============="+get_tab["name"]);

            //load/write secret config
            string configpath = "Assets/app/conf/config";
            //Hashtable config_data = new Hashtable ();
            //Hashtable info = new Hashtable ();
            //info ["host"] = "192.168.1.4";
            //info ["port"] = "8888";
            //config_data ["server1"] = info;

            //string json_array_config = LitJson.JsonMapper.ToJson (config_data);
            //Debug.Log ("config json array================"+json_array);
            //LocalData_Trans.SetData (configpath, json_array_config);

            string get_config = LocalData_Trans.GetData(configpath);
            Debug.Log("get config data===============" + get_config);
            LitJson.JsonData config_js = LitJson.JsonMapper.ToObject(get_config);
            LitJson.JsonData ss = config_js["server1"];
            Debug.Log(ss["port"]);
            Debug.Log(ss["host"]);
            initConfigInfo(config_js);
            return _init_s;
        }

        private int initManager(int _init_s)
        {
            //LFL_NetWork lflnet = new LFL_NetWork ();
            //lflnet.connectServer ();
            return _init_s;
        }

        private int initOtherData(int _init_s)
        {
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
            lflnet = LFL_NetWork.getInstance();
            lflnet.connectServer();
        }

    }
}
