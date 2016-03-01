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

		private SqliteDB( string db_file) {
			//init sql database
			OpenDB(db_file);
			//run database create table and update config

		}

		public static SqliteDB getInstance(string db_file)
        {
            if(instance == null)
            {
				instance = new SqliteDB(db_file);
            }
            return instance;
        }

        public void OpenDB(string connectionStr)
        {
            OpenSQLDB(connectionStr);
            Debug.Log(connectionStr);
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

        public SqliteDataReader ExecuteQuery(string sqlQuery)
        {
            //do sql
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            reader = dbCommand.ExecuteReader();
            return reader;
        }

        public SqliteDataReader InsertData(string tableName, string[] values)
        {
            //insert data
            string query = "insert into " + tableName + " values(" + values[0];
            for (int i = 1; i < values.Length; i++)
            {
                query += ", " + values[i];
            }
            query += ")";
            return ExecuteQuery(query);
        }

        public SqliteDataReader UpdateData(string tableName, string[] cols, string[] colvalues, string select_key, string select_value)
        {
            string query = "update " + tableName + " set " + cols[0] + " = " + colvalues[0];
            for (int i = 1; i < colvalues.Length; i++)
            {
                query += ", " + cols[i] + " = " + colvalues[i];
            }
            query += " where " + select_key + " = " + select_value;
            return ExecuteQuery(query);
        }

        public SqliteDataReader UpdateTable()
        {
            string query = "";
            return ExecuteQuery(query);
        }

        public SqliteDataReader DeleteTables()
        {
            string query = "";
            return ExecuteQuery(query);
        }

        public SqliteDataReader CreateTables()
        {
            string query = "";
            return ExecuteQuery(query);
        }
    }
}