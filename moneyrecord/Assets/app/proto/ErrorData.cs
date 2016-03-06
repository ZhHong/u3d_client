using UnityEngine;
using System.Collections;
namespace app.proto
{
    public class ErrorData
    {
        public string ErrorText = "";
        private Hashtable ErrorArry = new Hashtable();
        private static ErrorData instance = null;
        private ErrorData()
        {
            ErrorArry[0] = "未知错误!";
            ErrorArry["USERNAME_NOT_FIT"] = "用户名不符合规则!";
            ErrorArry["USERPASSWORD_NOT_FIT"] = "密码不符合规则!";
            ErrorArry["USERPASSWORD_AGAIN_NOT_FIT"] = "两次输入的密码不一致!";
            ErrorArry["USER_CREATE_EXSITS"] = "用户名已经存在!";
            ErrorArry["USER_LOGIN_ERROR"] = "用户名或者密码错误!";
            ErrorArry[""] = "";
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
    }
}