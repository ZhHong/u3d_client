using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System;
using System.Data;

namespace app.dao
{
    public class SqliteDB
    {
        private SqliteConnection dbConnection;

        private SqliteCommand dbCommand;

        private SqliteDataReader reader;

        private static SqliteDB instance = null;

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
				reader.Read ();
                string cryptopassword=reader.GetString(0);
				int uid = reader.GetInt32(1);
				int reg_time = reader.GetInt32(2);

				if(cryptopassword == password)
				{
					return 1;	
				}

                Debug.Log("sql result===========cryptopassword="+cryptopassword+"==uid="+uid+"===reg_time=="+reg_time);

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

		public int CheckUserIfExsits(string username){
			string sql = "select password,uid,reg_time from user_info where username = '" + username+"'";
			reader = ExecuteQuery (sql);
			if (reader.HasRows) {
				return -1;
			} else {
				return 1;
			}
		}
    }
}