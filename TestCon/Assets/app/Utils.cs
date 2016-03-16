using UnityEngine;
using System;
using System.Collections;

public class Utils{

	public static int GetNowTime() {
		System.DateTime starttime = System.TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
		System.DateTime nowTime = System.DateTime.Now;
		int unixtime = (int)System.Math.Round((nowTime-starttime).TotalSeconds,System.MidpointRounding.AwayFromZero);

		return unixtime;
	}

	public static string GetNowTimeStr(){
		return "";
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
