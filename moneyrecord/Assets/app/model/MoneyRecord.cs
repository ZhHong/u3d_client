using UnityEngine;
using System.Collections;
using app.model;
namespace app.model{
	public class MoneyRecord{
		
		public User user = null;
		private Hashtable records=null;
		private static MoneyRecord record=null;

		private MoneyRecord(){
			user = User.Instance ();
		}

		public static MoneyRecord Instance(){
			if(record == null){
				record = new MoneyRecord ();
			}
			return record;
		}

		public bool InitRecordFromDB(Hashtable data){
            //init data from db for user
            records = data;
			return true;
		}

		public Hashtable GetRecordData() {
            return records;
        }
	}
}