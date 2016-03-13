using UnityEngine;
using System.Collections;
using app.manager;
namespace app.service{
public class DetailService{


		public static Hashtable LoadCountYearData(){
			return GameWorld.getInstance ().CountDataFromDB (1);
		}

		public static Hashtable LoadCountMonthData(){
			return GameWorld.getInstance ().CountDataFromDB (2);
		}

		public static Hashtable LoadCountClassesData(){
			return GameWorld.getInstance ().CountDataFromDB (3);
		}

        public static Hashtable LoadALlRecord()
        {
            return GameWorld.getInstance().LoadDefaultData();
        }
	}
}
