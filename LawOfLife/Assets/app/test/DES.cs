using System;
using System.Security.Cryptography;
using System.Text;

//des encode decode
public class DES{

    public static byte [] Encode(byte[] secret,byte[] text) {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        return text;   
    }

    public static byte[] Decode(byte[] secret,byte[] text) {
        return text;
    }
}
