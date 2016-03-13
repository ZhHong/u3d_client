using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System;
using System.Data;
using app.utils;
using LitJson;
using app.model;
using app.manager;

namespace app.dao
{
    public class SqliteDB
    {
        private SqliteConnection dbConnection;

        private SqliteCommand dbCommand;

        private SqliteDataReader reader;

        private static SqliteDB instance = null;

		private static Hashtable getDbData = null;

		private SqliteDB( string db_file,string[] sqlstatement) {
			//init sql database
			OpenDB(db_file);
            //run database create table and update config
            for (int i=0;i<sqlstatement.Length;i++) {
                ExecuteQuery(sqlstatement[i],false);
            }

		}

		public static SqliteDB getInstance(string db_file,string[] sqlstatement)
        {
            if(instance == null)
            {
				instance = new SqliteDB(db_file, sqlstatement);
            }
            return instance;
        }

        public void OpenDB(string connectionStr)
        {
            OpenSQLDB(connectionStr);
            //Debug.Log(connectionStr);
        }

        public void OpenSQLDB(string connectionStr)
        {
            try
            {
                dbConnection = new SqliteConnection(connectionStr);
                dbConnection.Open();
                Debug.Log("connection to db");
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }
        }

        public void CloseSqlConnection()
        {
            if (dbCommand != null)
            {
                dbCommand.Dispose();
            }
            dbCommand = null;

            if (reader != null)
            {
                reader.Dispose();
            }
            reader = null;
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
            dbConnection = null;
            Debug.Log("disconect from db");
        }

		public SqliteDataReader ExecuteQuery(string sqlQuery,bool needReturn=true)
        {
            //do sql
            reader = null;
			dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
			if (needReturn) {
				reader = dbCommand.ExecuteReader ();
			} else {
				dbCommand.ExecuteNonQuery ();
			}
            return reader;
        }

        public int CheckUserLogin(string username, string password)
        {
            string sql = "select password,uid,reg_time from user_info where username = '" + username+"'";
            reader=ExecuteQuery(sql);
            if (reader.HasRows)
            {
				if (reader.Read ()) {
					string cryptopassword = reader.GetString (0);
					int uid = reader.GetInt32 (1);
					int reg_time = reader.GetInt32 (2);
					if (cryptopassword == password && password !="") {
                        User.Instance().ResetUser();
                        User.Instance().InitUser(username,password,uid,reg_time);
						return 1;	
					}
				}
            }
            return -1;
        }

        public int CreateUser(string username, string password)
        {
			//uid,username,password,reg_time
			int reg_time = utils.Utils.GetNowTime();
            string sql = "insert into user_info values(null,'" + username + "','" + password + "'," + reg_time + ")";
            reader = ExecuteQuery(sql);
			return 1;
        }

		public string CheckUserIfExsits(string username){
			string sql = "select password,uid,reg_time from user_info where username = '" + username+"'";
			reader = ExecuteQuery (sql);
			if (reader.HasRows) {
				return "USER_CREATE_EXSITS";
			} else {
				return "SUCCESS";
			}

		}

		public int InsertMoneyRecord(int uid, int record_time, int money_class, int pay_type, float pay_value, string msg){
			//insert into record
			//table {id,uid,record_time,money_class,pay_type,pay_value,msg,insert_time}
			int insert_time = Utils.GetNowTime();
			string sql = "inset into money_record values(null,"+uid+","+record_time+","+money_class+","+pay_type+","+pay_value+",'"+msg+"',"+insert_time+")";
			reader = ExecuteQuery (sql,false);
			return -1;
		}

		public Hashtable GetCurrentMoneyRecord(int uid){
            //get current user money record
			getDbData = new Hashtable();
			string sql = "select id,record_year,record_month,record_day,money_class,pay_type,pay_value,msg,insert_time from money_record where uid = "+uid;

            Hashtable tablehead = new Hashtable();
            tablehead[0] = "seq";
            tablehead[1] = "year";
            tablehead[2] = "month";
            tablehead[3] = "day";
            tablehead[4] = "money_class";
            tablehead[5] = "pay_type";
            tablehead[6] = "pay_value";
            tablehead[7] = "msg";
            tablehead[8] = "datetime";

            GameWorld.getInstance().errorData.PushTextTable(tablehead);

            reader = ExecuteQuery (sql);
			if (reader.HasRows) {
                //has records
                int i = 0;
				while(reader.Read()){
					int id = reader.GetInt32 (0);
					int record_year = reader.GetInt32 (1);
					int record_month = reader.GetInt32 (2);
					int record_day = reader.GetInt32 (3);
					int money_class = reader.GetInt32 (4);

                    string money_class_str = GameWorld.getInstance().errorData.GetMoneyTypeStr(money_class);

					int pay_type = reader.GetInt32 (5);
                    string pay_type_str = GameWorld.getInstance().errorData.GetPayTypeStr(pay_type);
					float pay_value = reader.GetFloat (6);
					string msg = reader.GetString (7);
					int insert_time = reader.GetInt32 (8);
                    string insert_time_str = Utils.GetTimeStr(insert_time).ToString();
					string record_time = record_year + "/" + record_month + "/" + record_day;

                    Hashtable temp = new Hashtable();
                    temp[0] = id;
                    temp[1] = record_time;
                    temp[2] = money_class_str;
                    temp[3] = pay_type_str;
                    temp[4] = pay_value;
                    temp[5] = msg;
                    temp[6] = insert_time_str;
					getDbData.Add(i, temp);
                    i++;
				}
			}
			return getDbData;
		}

		public void CreateNewRecord(int year,int month,int day,int mc,int py,double payValue,string noteMsg){
			//create new record
			int uid =User.Instance().GetUid();
			int now = Utils.GetNowTime ();
			//table {id,uid,record_year,record_month,record_day,money_class,pay_type,pay_value,msg,insert_time}
			string sql = "insert into money_record values( null,"+uid+","+year+","+month+","+day+","+mc+","+py+","+payValue+",'"+noteMsg+"',"+now+")";
			reader = ExecuteQuery (sql);
		}


		//--  year count
		//SELECT record_year,record_month,money_class,sum(pay_value) from money_record   WHERE uid = 1 GROUP BY record_year,record_month ORDER BY record_year,record_month;

		//-- month count
		//SELECT record_year,record_month,money_class,pay_type,sum(pay_value) from money_record   WHERE uid = 1 GROUP BY record_year,record_month,pay_type ORDER BY record_year,record_month,pay_type;

		//--classes count

		//SELECT record_year,money_class,pay_type,sum(pay_value) from money_record   WHERE uid = 1 GROUP BY record_year,money_class,pay_type ORDER BY record_year,money_class,pay_type;

		public Hashtable GetCountYearData(){
			//get year count
			getDbData = new Hashtable();
			string sql = "SELECT record_year,record_month,money_class,sum(pay_value) from money_record   WHERE uid = "+User.Instance().GetUid()+" GROUP BY record_year,record_month ORDER BY record_year,record_month";

            Hashtable tablehead = new Hashtable();
            tablehead[0] = "year";
            tablehead[1] = "month";
            tablehead[2] = "money_class";
            tablehead[3] = "count_value";

            GameWorld.getInstance().errorData.PushTextTable(tablehead);

            reader = ExecuteQuery (sql);
			if (reader.HasRows){
				int i = 0;
				while(reader.Read()){
					Hashtable temp = new Hashtable ();
					int year = reader.GetInt32(0);
					int month = reader.GetInt32 (1);
					int money_class = reader.GetInt32 (2);
                    string money_class_str = GameWorld.getInstance().errorData.GetMoneyTypeStr(money_class);
                    float sum_pay = reader.GetFloat (3);
					temp[0]=year;
					temp [1] = month;
					temp [2] = money_class_str;
					temp [3] = sum_pay;
					getDbData.Add (i, temp);
					i++;
				}
			}
			return getDbData;
		}

		public Hashtable GetCountMonthData(){
			//get month count
			getDbData = new Hashtable();
			string sql = "SELECT record_year,record_month,money_class,pay_type,sum(pay_value) from money_record   WHERE uid = "+User.Instance().GetUid()+" GROUP BY record_year,record_month,pay_type ORDER BY record_year,record_month,pay_type";

            Hashtable tablehead = new Hashtable();
            tablehead[0] = "year";
            tablehead[1] = "month";
            tablehead[2] = "money_class";
            tablehead[3] = "pay_type";
            tablehead[4] = "count_value";

            GameWorld.getInstance().errorData.PushTextTable(tablehead);

            reader = ExecuteQuery (sql);
			if (reader.HasRows){
				int i = 0;
				while(reader.Read()){
					Hashtable temp = new Hashtable ();
					int year = reader.GetInt32 (0);
					int month = reader.GetInt32 (1);
					int money_class = reader.GetInt32 (2);
                    string money_class_str = GameWorld.getInstance().errorData.GetMoneyTypeStr(money_class);
                    int pay_type = reader.GetInt32 (3);
                    string pay_type_str = GameWorld.getInstance().errorData.GetPayTypeStr(pay_type);
                    float sum_pay = reader.GetFloat (4);
					temp[0]=year;
					temp [1] = month;
					temp [2] = money_class_str;
					temp [3] = pay_type_str;
					temp [4] = sum_pay;
					getDbData.Add (i, temp);
					i++;
				}
			}
			return getDbData;
		}

		public Hashtable GetCountYearTypeData(){
			//get year type count
			getDbData = new Hashtable();
			string sql = "SELECT record_year,money_class,pay_type,sum(pay_value) from money_record   WHERE uid = "+User.Instance().GetUid()+" GROUP BY record_year,money_class,pay_type ORDER BY record_year,money_class,pay_type";

            //set table head
            Hashtable tablehead = new Hashtable();
            tablehead[0] = "year";
            tablehead[1] = "money_class";
            tablehead[2] = "pay_type";
            tablehead[3] = "count_value";

            GameWorld.getInstance().errorData.PushTextTable(tablehead);

            reader = ExecuteQuery (sql);
			if (reader.HasRows){
				int i = 0;
				while(reader.Read()){
					Hashtable temp = new Hashtable ();
					int year = reader.GetInt32 (0);
					int money_class = reader.GetInt32 (1);
                    string money_class_str = GameWorld.getInstance().errorData.GetMoneyTypeStr(money_class);
                    int pay_type = reader.GetInt32 (2);
                    string pay_type_str = GameWorld.getInstance().errorData.GetPayTypeStr(pay_type);
                    float sum_pay = reader.GetFloat (3);
					temp [0] = year;
					temp [1] = money_class_str;
					temp [2] = pay_type_str;
					temp [3] = sum_pay;
					getDbData.Add (i, temp);
					i++;
				}
			}
			return getDbData;
		}

		public Hashtable GetUserDefineData(string sql){
			//get user self define data
			getDbData = new Hashtable();
			reader = ExecuteQuery (sql);
			if (reader.HasRows){
				int i = 0;
				while(reader.Read()){
					i++;
				}
			}
			return getDbData;
		}

		public Hashtable LoadCoutDataByCountType(int type){
			if (type == 1) {
				return GetCountYearData ();
			} else if (type == 2) {
				return GetCountMonthData ();
			} else if (type == 3) {
				return GetCountYearTypeData ();
			}
			return new Hashtable ();
		}
    }
}