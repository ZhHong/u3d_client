using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;

namespace app.model
{
    //use skynet login
    /*
    登陆服务器和客户端的交互协议基于文本。每个请求和回应包，都以换行符 \n 分割。用户名、服务器名、token 等，为了保证可以正确在文本协议中传输，全部经过了 base64 编码。所以这些业务相关的串可以包含任何字符。
    下列通讯流程的协议描述中，S2C 表示这是一个服务器向客户端发送的包；C2S 表示是一个客户端向服务器发送的包。

    S2C : base64(8bytes random challenge) 这是一个 8 字节长的随机串，用于后序的握手验证。
    C2S : base64(8bytes handshake client key) 这是一个 8 字节的由客户端发送过来，用于交换 secret 的 key 。
    Server: Gen a 8bytes handshake server key 生成一个用户交换 secret 的 key 。
    S2C : base64(DH-Exchange(server key)) 利用 DH 密钥交换算法，发送交换过的 server key 。
    Server/Client secret := DH-Secret(client key/server key) 服务器和客户端都可以计算出同一个 8 字节的 secret 。
    C2S : base64(HMAC(challenge, secret)) 回应服务器第一步握手的挑战码，确认握手正常。
    C2S : DES(secret, base64(token)) 使用 DES 算法，以 secret 做 key 加密传输 token 串。
    Server : call auth_handler(token) -> server, uid (A user defined method)
    Server : call login_handler(server, uid, secret) -> subid (A user defined method)
    S2C : 200 base64(subid) 发送确认信息 200 subid ，或发送错误码。
    错误码

    400 Bad Request . 握手失败
    401 Unauthorized . 自定义的 auth_handler 不认可 token
    403 Forbidden . 自定义的 login_handler 执行失败
    406 Not Acceptable . 该用户已经在登陆中。（只发生在 multilogin 关闭时）
        */
    public class Client
    {
        private string host = "192.168.1.4";
        private int port = 8001;
        private Socket msc = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        private string secret = "";
        private int session = 0;
        public Client() {

        }

        public void connect() {
            IPAddress ip = IPAddress.Parse(host);
            try
            {
                msc.Connect(new IPEndPoint(ip, port));
            }
            catch (Exception e)
            {
                Debug.Log("connect to server " + host + ":" + port + " failed!!!!!!!");
            }
        }

        public void writeLine(int session_id,string text) {
            //send line to server
        }

        public void unpackLine(string text) {
            //unpack line
        }

        public void unpackF() {

        }

        public void Send(string sproto_type,SpObject args) {
        }

        public void Login(SpObject arg) {
            //read value from arg
            string token = arg["token"].Value.ToString();
            string challenge = arg["chanllenge"].Value.ToString();

            //use secert to encrypt token
            byte[] token_code = Convert.FromBase64String(token);
            byte[] secret_code = Convert.FromBase64String(secret);
            byte[] desencode_token_code = DES.Encode(secret_code,token_code);

            token = Convert.ToBase64String(desencode_token_code);
            //send sproto package
            Send("login",new SpObject(SpObject.ArgType.Table,
                "session",session,
                "token",token));
        }

    }
}
