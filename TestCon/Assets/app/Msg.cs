using UnityEngine;
using System.Collections;

public class Msg{

	private const int MAX_LEN = 1024 * 50;

	private static char[] inbuffer = new char[MAX_LEN];

	private static char[] outbuffer = new char[MAX_LEN];

	public static void Reset(){
		
	}

	public static int writeBoolean(bool data){
		return 0;
	}

	public static int writeByte(char data){
		return 0;
	}

	public static int writeDouble(double data){
		return 0;
	}

	public static int writeLong(long data){
		return 0;
	}

	public static int writeFloat(float data){
		return 0;
	}

	public static int writeInt(int data){
		return 0;
	}

	public static int writeShort(short data){
		return 0;
	}

	public static int writeUTF(string data){
		return 0;
	}

	public static int writeData(string data){
		return 0;
	}

	public static bool readBoolean(){
		return false;
	}

	public static char readByte(){
		return 'a';
	}

	public static double readDouble(){
		return 0.0;
	}

	public static long readLong(){
		return 1L;
	}

	public static float readFloat(){
		return 0.0f;
	}

	public static int readInt(){
		return 1;
	}

	public static short readShort(){
		return 1;
	}

	public static string readUTF(){
		return "";
	}

	public static string readData(int datalen){
		return "";
	}
}
