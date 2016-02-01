using System.Collections;
using System.IO;

public class TestRpc {
    private const string server_proto = @"
        .package {
	        type 0 : integer
	        session 1 : integer
        }

        foobar 1 {
	        request {
		        what 0 : string
	        }
	        response {
		        ok 0 : boolean
	        }
        }

        foo 2 {
	        response {
		        ok 0 : boolean
	        }
        }

        bar 3 {}

        blackhole 4 {
	        request {}
        }
		
		userinfo 5 {
		request {
			who 0 : integer
		}
		response{ 
			ok 0 : integer
			uid 1 : integer
			rolename 2 : string
			choserole 3 : integer
			level 4 : integer
			exp 5 : integer
			gold 6 : integer
			}
		}
        ";

    const string client_proto = @"
        .package {
	        type 0 : integer
	        session 1 : integer
        }
        ";

    private SpRpc server;
    private SpRpc client;

	public void Run () {
        SpTypeManager server_tm = SpTypeManager.Import (server_proto);

        server = SpRpc.Create (server_tm, "package");

        client = SpRpc.Create (client_proto, "package");
        client.Attach (server_tm);

        //TestFoobar ();
        //TestFoo ();
        //TestBar ();
        //TestBlackhole ();
		TestUserInfo ();
	}

    private void TestFoobar () {
        Util.Log ("client request foobar");

        SpObject foobar_request = new SpObject ();
        foobar_request.Insert ("what", "foo");
        SpStream req = client.Request ("foobar", foobar_request, 1);

        Util.Assert (req.Length == 11);
        Util.Log ("request foobar size = " + req.Length);

        req.Position = 0;
		SpRpcResult dispatch_result = server.Dispatch (req);
		Util.Assert (dispatch_result.Arg["what"].AsString ().Equals ("foo"));
		Util.DumpObject (dispatch_result.Arg);

        Util.Log ("server response");

        SpObject foobar_response = new SpObject ();
        foobar_response.Insert ("ok", true);
		SpStream resp = server.Response (dispatch_result.Session, foobar_response);

        Util.Assert (resp.Length == 7);
        Util.Log ("response package size = " + resp.Length);

        Util.Log ("client dispatch");

        resp.Position = 0;
		dispatch_result = client.Dispatch (resp);
        Util.Assert (dispatch_result.Arg["ok"].AsBoolean () == true);
        Util.DumpObject (dispatch_result.Arg);
    }

    private void TestFoo () {
        SpStream req = client.Request ("foo", null, 2);

        Util.Assert (req.Length == 4);
		Util.Log ("request foo size = " + req.Length);

        req.Position = 0;
        SpRpcResult dispatch_result = server.Dispatch (req);

        SpObject foobar_response = new SpObject ();
        foobar_response.Insert ("ok", false);
		SpStream resp = server.Response (dispatch_result.Session, foobar_response);

        Util.Assert (resp.Length == 7);
		Util.Log ("response package size = " + resp.Length);

		Util.Log ("client dispatch");

        resp.Position = 0;
        dispatch_result = client.Dispatch (resp);
        Util.Assert (dispatch_result.Arg["ok"].AsBoolean () == false);
        Util.DumpObject (dispatch_result.Arg);
    }

    private void TestBar () {
        SpStream req = client.Request ("bar");

        Util.Assert (req.Length == 3);
		Util.Log ("request bar size = " + req.Length);

        req.Position = 0;
        server.Dispatch (req);
    }

    private void TestBlackhole () {
        SpStream req = client.Request ("blackhole");
        Util.Assert (req.Length == 3);
		Util.Log ("request blackhole size = " + req.Length);
    }

	private void TestUserInfo(){
		Util.Log ("client request userinfo====================");
		SpObject userinfo_request = new SpObject ();
		userinfo_request.Insert ("who", 3000);

		SpStream req = client.Request ("userinfo",userinfo_request,5);
		//Util.Assert (req.Length == 3);
		Util.Log ("request userinfo size ============"+req.Length);

		req.Position = 0;
		SpRpcResult dispath_result = server.Dispatch (req);
		//Util.Assert (dispath_result.Arg[]);
		Util.Log("respone args============="+dispath_result.Arg["who"].AsInt());
		Util.DumpObject (dispath_result.Arg);

		Util.Log ("server respnse============================");

		SpObject userinfo_response = new SpObject ();
		//ok 0 : integer
		//uid 1 : integer
		//rolename 2 : string
		//choserole 3 : integer
		//level 4 : integer
		//exp 5 : integer
		//gold 6 : integer
		userinfo_response.Insert ("ok",1);
		userinfo_response.Insert ("uid",3000);
		userinfo_response.Insert ("rolename","cutely");
		userinfo_response.Insert ("choserole",1);
		userinfo_response.Insert ("level",1);
		userinfo_response.Insert ("exp",11);
		userinfo_response.Insert ("gold",8888);

		SpStream resp = server.Response (dispath_result.Session, userinfo_response);
		Util.Log ("response package size============"+resp.Length);
		Util.Log ("client dispatch");
		resp.Position = 0;

		dispath_result = client.Dispatch (resp);
		Util.DumpObject (dispath_result.Arg);
		Util.Log ("response args===================================");
		Util.Log ("state======="+dispath_result.Arg["ok"].AsInt());
		Util.Log ("UID========="+dispath_result.Arg["uid"].AsInt());
		Util.Log ("roleName===="+dispath_result.Arg["rolename"].AsString());
		Util.Log ("choserole==="+dispath_result.Arg["choserole"].AsInt());
		Util.Log ("level======="+dispath_result.Arg["level"].AsInt());
		Util.Log ("exp========="+dispath_result.Arg["exp"].AsInt());
		Util.Log ("gold========"+dispath_result.Arg["gold"].AsInt());
	}
}
