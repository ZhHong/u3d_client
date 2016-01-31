using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using app.manager;
using System.Threading;

namespace app.network{
	public sealed class LFL_NetWork{
		private static Socket sc;
        private bool isConnected = false;
        private static LFL_NetWork instance = null;
        private byte[] receiveBuff = new byte[1024];

        private LFL_NetWork() {

        }
        public static LFL_NetWork getInstance() {
            if (instance == null) {
                instance = new LFL_NetWork();
            }
            return instance;
        }
		public void connectServer(){
			try{
				GameWorld gw= GameWorld.getInstance();
				string serverid ="server1";
				LitJson.JsonData server_info =gw.getServerInfo(serverid);
                Debug.Log(server_info["host"]+"================================"+server_info["port"]);
                int port = int.Parse(server_info["port"].ToString());
				string host=(server_info["host"]).ToString();

				IPAddress ipad=IPAddress.Parse(host);
				IPEndPoint ipend=new IPEndPoint(ipad,port);

				//create connection
				sc= new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
				Debug.Log("begin connect server "+host+":"+port);

				sc.Connect(ipend);

				//send msg to server
				string sendmsg="hello conenct";
				byte[] bs=Encoding.UTF8.GetBytes(sendmsg);

				sc.Send(bs,bs.Length,0);

				Debug.Log("------------CONNECT over-------------------");
                isConnected = true;
                if (sc.Connected) {
                    Debug.Log("begin recive msg from server=================================");
                    sc.BeginReceive(receiveBuff,0,receiveBuff.Length,0,new AsyncCallback(reciveMessageCallBack),null);
                }
                
			}
			catch(ArgumentNullException e){
				Debug.Log ("ArgumentNullException : "+e.ToString());
			}
			catch(SocketException e){
				Debug.Log ("SocketException : "+e.ToString());
			}
		}
		private void reciveMessageCallBack(IAsyncResult ar){
            //recive msg from server
            try {
                int Rend = sc.EndReceive(ar);
                string strReciveData = Encoding.UTF8.GetString(receiveBuff,0,Rend);
                Debug.Log(" get server data==============================="+strReciveData);
                msgHandler(strReciveData);
                sc.BeginReceive(receiveBuff, 0, receiveBuff.Length, 0, new AsyncCallback(reciveMessageCallBack), null);
            } catch(Exception e) {
                throw new Exception(e.Message);
            }
		}

        public void closeConnection() {
            if (!sc.Equals(null)) {
                sc.Close();
                isConnected = false;
            }
        }
        private void msgHandler(string recv_data) {
            //msg handler
            //recv_data = recv_data.Replace("/0","");
            if (!string.IsNullOrEmpty(recv_data)) {
                Debug.Log("recive msg from server============"+recv_data);
            }
        }
	}
}
