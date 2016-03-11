using UnityEngine;
using System.Collections;
using System;

namespace app.utils{
	public class Utils{
		//game save path
		public const string GLOBAL_GAME_SAVE_PATH = "/CURENT.MR";
		//db path
		public const string GLOBAL_DB_FILE_PATH  = "/KWDUWIDAJ";
		//config path
		public const string GLOBAL_CONFIG_PATH = "config";
        //db init path
		public const string GLOBAL_DBINIT_PATH = "INITDB";

        public static int GetNowTime() {
            System.DateTime starttime = System.TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            System.DateTime nowTime = System.DateTime.Now;
            int unixtime = (int)System.Math.Round((nowTime-starttime).TotalSeconds,System.MidpointRounding.AwayFromZero);

            return unixtime;
        }

		public static int GetStrTime(int year,int month,int day){
			return 0;
		}

		public static DateTime GetTimeStr (int time){
            DateTime dt = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
            long itime = long.Parse(time+"0000000");
            TimeSpan tt = new TimeSpan(itime);
            return dt.Add(tt);
		}
	}
}