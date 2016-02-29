using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System;

public class Client {
	private string c2s = @"
		.package {
			type 0 : integer
			session 1 : integer
		}

		handshake 1 {
			response {
				msg 0  : string
			}
		}

		get 2 {
			request {
				what 0 : string
			}
			response {
				result 0 : string
			}
		}

		set 3 {
			request {
				what 0 : string
				value 1 : string
			}
        quit 5 {
		}
        userinfo 4 {
            request{
                who 0 : integer
            }
            response{
                uid 0 : integer
				uname 1 : string
				sex 2 : integer
				level 3 : integer
				exp 4 : integer
				gold 5 : intege
            }
        }
		
		createuserinfo 6{
			request{
				rolename 0 : string
			}
			response{
				uid 0 : integer
				uname 1 : string
				sex 2 : integer
				level 3 : integer
				exp 4 : integer
				gold 5 : intege
			}
		}
        
        
		}";

    private string s2c = @"
        .package {
	        type 0 : integer
	        session 1 : integer
        }

        heartbeat 1 {}
        ";

	private Socket mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	SpStream mSendStream = new SpStream ();
	private byte[] mRecvBuffer = new byte[1024];
	private int mRecvOffset = 0;
	private int mSession = 0;
	private SpRpc mRpc;
	public bool isConnect =false;

	private string serverhost="192.168.1.4";
	private int serverport=8101;

	public void connect(){
		IPAddress ip = IPAddress.Parse (serverhost);
		try{
			Util.Log("begin connect Server ip "+serverhost+":"+serverport+".......");
			mSocket.Connect(new IPEndPoint(ip, serverport));
			isConnect =true;
		}catch(Exception exp){
			Util.Log ("cann't connect Server,please try again.....");
		}
		if (isConnect) {
			Run ();
		}
	}

	public void Run () {
        mRpc = SpRpc.Create (s2c, "package");
        mRpc.Attach (c2s);

		Send ("handshake", null);
		Send ("set", new SpObject (SpObject.ArgType.Table, 
		                           "what", "hello", 
		                           "value", "world"));

		mSocket.BeginReceive (mRecvBuffer, 0, mRecvBuffer.Length, SocketFlags.None, new AsyncCallback(ReadCallback), this);
	}

	public void Recv (IAsyncResult ar) {
		int ret = mSocket.EndReceive (ar);

		if (ret > 0) {
			mRecvOffset += ret;

			int read = 0;
			while (mRecvOffset > read) {
				int size = (mRecvBuffer[read + 1] | (mRecvBuffer[read + 0] << 8));

				read += 2;
				if (mRecvOffset >= size + read) {
					SpStream stream = new SpStream (mRecvBuffer, read, size, size);
					SpRpcResult result = mRpc.Dispatch (stream);
					switch (result.Op) {
					case SpRpcOp.Request:
						Util.Log ("Recv Request : " + result.Protocol.Name + ", session : " + result.Session);
						if (result.Arg != null)
							Util.DumpObject (result.Arg);
						break;
					case SpRpcOp.Response:
						Util.Log ("Recv Response : " + result.Protocol.Name + ", session : " + result.Session);
						if (result.Arg != null)
							Util.DumpObject (result.Arg);
						break;
					}
					
					read += size;
				}
			}
			Util.Assert (mRecvOffset == read);
			mRecvOffset = 0;
		}
		
		mSocket.BeginReceive (mRecvBuffer, 0, mRecvBuffer.Length, SocketFlags.None, new System.AsyncCallback(ReadCallback), this);
	}

	public static void ReadCallback(IAsyncResult ar) {
		Client client = (Client)ar.AsyncState;
		client.Recv (ar);
	}

	private void Send (string proto, SpObject args) {
		mSendStream.Reset ();
		mSession++;

		Util.Log ("Send Request : " + proto + ", session : " + mSession);
		if (args != null)
			Util.DumpObject (args);

		mSendStream.Write ((short)0);
		Util.Log ("proto=========="+proto);
		Util.DumpObject (args);
		Util.DumpStream (mSendStream);
		mRpc.Request (proto, args, mSession, mSendStream);
		int len = mSendStream.Length - 2;
		mSendStream.Buffer[0] = (byte)((len >> 8) & 0xff);
		mSendStream.Buffer[1] = (byte)(len & 0xff);
		mSocket.Send (mSendStream.Buffer, mSendStream.Length, SocketFlags.None);
	}
    // send sproto type get
	public void SendGet (string str) {
		Util.Log ("send requset get =============what=="+str);
		Send ("get", new SpObject (SpObject.ArgType.Table, "what", str));
	}

	//send sproto type userinfo
	public void SendUserInfo(int who){
		Util.Log ("send requset userinfo==========who="+who);
		Send ("userinfo",new SpObject(SpObject.ArgType.Table,"who",who));
	}
	//send sproto type set
	public void SendSet(string what, string value){
		Util.Log ("send request get==========what="+what+"======value="+value);
		Send ("set", new SpObject(SpObject.ArgType.Table,"what",what,"value",value));
	}
}
