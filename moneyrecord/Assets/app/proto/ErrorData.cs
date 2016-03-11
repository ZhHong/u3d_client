using UnityEngine;
using System.Collections;
namespace app.proto
{
    public class ErrorData
    {
        public string ErrorText = "";
        private Hashtable ErrorArry = new Hashtable();
        private static ErrorData instance = null;

		private Hashtable MoneyType = new Hashtable();
		private Hashtable PayType = new Hashtable();
        private Hashtable TableHead = new Hashtable();

        private Hashtable textInpt = null;
        private ErrorData()
        {
            ErrorArry[0] = "未知错误!";
            ErrorArry["USERNAME_NOT_FIT"] = "用户名不符合规则!";
            ErrorArry["USERPASSWORD_NOT_FIT"] = "密码不符合规则!";
            ErrorArry["USERPASSWORD_AGAIN_NOT_FIT"] = "两次输入的密码不一致!";
            ErrorArry["USER_CREATE_EXSITS"] = "用户名已经存在!";
            ErrorArry["USER_LOGIN_ERROR"] = "用户名或者密码错误!";
            ErrorArry["MONEY_CAN_NOT_NONE"] = "必须输入金额!";
			ErrorArry ["MSG_CAN_NOT_NONE"] = "备注信息不能为空！";
			ErrorArry ["MONTH_2_CHANGED"] = "2月日期已经被修正";
			ErrorArry ["TIME_WARNING_FRUTURE"] = "这是一个未来时间！";
			ErrorArry ["TIME_WARNING_PASSED"] = "这是一个已经过去的时间！";


			MoneyType [0] = "支出";
			MoneyType [1] = "收入";

			PayType [0] = "吃";
			PayType [1] = "住";
			PayType [2] = "穿";
			PayType [3] = "交通";
			PayType [4] = "手机";
			PayType [5] = "网络";
			PayType [6] = "游戏";
			PayType [7] = "烟";
			PayType [8] = "零食";
			PayType [9] = "水果";
            PayType[10] = "工资";
            PayType[11] = "奖金";
            PayType[12] = "其它";

            TableHead["year"] = "年";
            TableHead["month"] = "月";
            TableHead["day"] = "日";
            TableHead["datetime"] = "插入日期";
            TableHead["money_class"] = "记录类别";
            TableHead["pay_type"] = "支付类别";
            TableHead["pay_value"] = "支付金额";
            TableHead["msg"] = "备注信息";
            TableHead["count_value"] = "总计";
            TableHead["seq"] = "序号";

        }

        public static ErrorData getInstance()
        {
            if (instance == null)
            {
                instance = new ErrorData();
            }
            return instance;
        }

        public void SetErrorData(string error_key)
        {
            if (error_key == "SUCCESS") { return; }
            if (ErrorArry.ContainsKey(error_key))
            {
                ErrorText = ErrorArry[error_key].ToString();
                return;
            }
            ErrorText = ErrorArry[0].ToString();
        }

        public string GetErrorString()
        {
            string temp = ErrorText;
            if (ErrorText != "")
            {
                ErrorText = "";
            }
            return temp;
        }

		public string GetMoneyTypeStr(int index){
			if (MoneyType.ContainsKey(index)){
				return MoneyType [index].ToString();
			}
			return "";
		}

		public int GetMoneyTypeIndex(string value){
			if (value == "") {
				return 0;
			}
			if(MoneyType.ContainsValue(value)){
				foreach(DictionaryEntry d in MoneyType){
					if(d.Value.ToString() == value){
						return int.Parse(d.Key.ToString());
					}
				}
			}
			return -1;
		}

		public string GetPayTypeStr(int index){
			if(PayType.ContainsKey(index)){
				return PayType [index].ToString();
			}
			return "";
		}

		public int GetPayTypeStr(string value){
			if(value == ""){
				return 0;
			}
			if(PayType.ContainsValue(value)){
				foreach(DictionaryEntry d in PayType){
					if(d.Value.ToString() == value){
						return int.Parse(d.Key.ToString());
					}
				}
			}
			return -1;
		}

        private string GetTableHeadStr(string index) {
            if (TableHead.ContainsKey(index)) {
                return TableHead[index].ToString();
            }
            return "";
        }

        public void PushTextTable(Hashtable t) {
            textInpt = new Hashtable();
            foreach (DictionaryEntry d in t) {
                var index = d.Key.ToString();
                var new_str=GetTableHeadStr(d.Value.ToString());
                textInpt[index] = new_str;
            }
        }

        public Hashtable GetTextTable()
        {
            return textInpt;
        }
    }
}