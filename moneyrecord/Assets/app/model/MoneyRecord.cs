using UnityEngine;
using System.Collections;
using app.model;
namespace app.model{
	public class MoneyRecord{
		
		private User user = null;
		private LitJson.JsonData records=null;
		private static MoneyRecord record=null;

		private MoneyRecord(){
		}

		public static MoneyRecord Instance(){
			if(record == null){
				record = new MoneyRecord ();
			}
			return record;
		}

		public bool InitRecordFromDB(LitJson.JsonData data){
            //init data from db for user
            records = data;
			return true;
		}

        public LitJson.JsonData GetRecordData() {
            return records;
        }
	}
}