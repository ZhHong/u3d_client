using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using LitJson;
namespace Plugins.LocalData_Trans{
	public static class LocalData_Trans{

		private static string sckey="xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

		public static bool IsFileExists(string fileName){
			return File.Exists (fileName);
		}

		public static bool IsDirectoryExists(string directoryName){
			return Directory.Exists (directoryName);
		}

		//create a file

		public static void CreateFile(string fileName,string directoryName){
			StreamWriter streamwriter = File.CreateText (fileName);
			streamwriter.Write (directoryName);
			streamwriter.Close ();
		}

		//create a directory
		public static void CreateDirectory(string directoryName){
			if (IsDirectoryExists (directoryName))
				return;
			Directory.CreateDirectory (directoryName);
		}

		public static void SetData(string fileName,string jsonStr){
			//crypro
			string toSave=Encrypto(jsonStr,sckey);
			StreamWriter streamwriter = File.CreateText (fileName);
			streamwriter.Write (toSave);
			streamwriter.Close ();
			Debug.Log ("  set data end=============================="+toSave);
		}
		public static string GetData(string fileName){
			StreamReader streamreader = File.OpenText (fileName);
			string data = streamreader.ReadToEnd ();
			//decrypro
			data=Decrypto(data,sckey);
			Debug.Log ("decode string======="+data);
			streamreader.Close ();
			return data;
		}

		private static string Encrypto(string pstring,string pkey){
			byte[] keyArray = UTF8Encoding.UTF8.GetBytes (pkey);
			byte[] encryptoArry = UTF8Encoding.UTF8.GetBytes (pstring);

			RijndaelManaged rdel = new RijndaelManaged ();
			rdel.Key = keyArray;
			rdel.Mode = CipherMode.ECB;
			rdel.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = rdel.CreateEncryptor ();
			//return encrypro str
			byte[] resultArry = cTransform.TransformFinalBlock(encryptoArry,0,encryptoArry.Length);

			return Convert.ToBase64String(resultArry,0,resultArry.Length);
		}
		private static string Decrypto(string pstring,string pkey){
			byte[] keyArray = UTF8Encoding.UTF8.GetBytes (pkey);
			byte[] decryproArray = Convert.FromBase64String (pstring);

			RijndaelManaged rdel = new RijndaelManaged ();
			rdel.Key = keyArray;
			rdel.Mode = CipherMode.ECB;
			rdel.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = rdel.CreateDecryptor ();
			byte[] resultArray = cTransform.TransformFinalBlock (decryproArray, 0, decryproArray.Length);

			return UTF8Encoding.UTF8.GetString(resultArray);
		}
	}
}