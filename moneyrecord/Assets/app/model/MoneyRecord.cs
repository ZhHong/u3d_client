using UnityEngine;
using System.Collections;
using app.model;
namespace app.model{
	public class MoneyRecord{
		
		private User user = null;
		private Hashtable records=null;
		private static MoneyRecord record=null;

		private MoneyRecord(){
		}

		public static MoneyRecord Instance(){
			if(record == null){
				record = new MoneyRecord ();
			}
			return record;
		}

		public bool InitRecordFromDB(){
			//init data from db for user
			return true;
		}
	}
}