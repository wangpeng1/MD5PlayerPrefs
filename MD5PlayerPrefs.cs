using System.Text;
using System.Security.Cryptography;
using UnityEngine;

public class MD5PlayerPrefs
{
    private static string md5(string encrypt){
        byte[] hashBytes = new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(encrypt + SystemInfo.deviceUniqueIdentifier));
        string hashString = "";
        int len = hashBytes.Length;
        for (int i = 0; i < len; i++) hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        return hashString.PadLeft(32, '0');
    }

    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static void DeleteAll(){
        PlayerPrefs.DeleteAll();
    }

    public static void DeleteKey(string key){
        PlayerPrefs.DeleteKey(md5(key));
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(md5(key), value);
    }

    public static float GetFloat(string key)
    {
        string keyMD5 = md5(key);
        if (HasKey(keyMD5)) return PlayerPrefs.GetFloat(keyMD5);
        else return 0.0f;
    }

    public static float GetFloat(string key, float defaultValue)
    {
        string keyMD5 = md5(key);
        if (HasKey(keyMD5)) return PlayerPrefs.GetFloat(keyMD5);
        else return defaultValue;
    }

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(md5(key), value);
    }

    public static int GetInt(string key)
    {
        string keyMD5 = md5(key);
        if (HasKey(keyMD5)) return PlayerPrefs.GetInt(keyMD5);
        else return 0;
    }

    public static int GetInt(string key, int defaultValue)
    {
        string keyMD5 = md5(key);
        if (HasKey(keyMD5)) return PlayerPrefs.GetInt(keyMD5);
        else return defaultValue;
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(md5(key), value);
    }

    public static string GetString(string key)
    {
        string keyMD5 = md5(key);
        if (HasKey(keyMD5)) return PlayerPrefs.GetString(keyMD5);
        else return "";
    }

    public static string GetString(string key, string defaultValue)
    {
        string keyMD5 = md5(key);
        if (HasKey(keyMD5)) return PlayerPrefs.GetString(keyMD5);
        else return defaultValue;
    }

    public static void Save(){
        PlayerPrefs.Save();
    }
}
