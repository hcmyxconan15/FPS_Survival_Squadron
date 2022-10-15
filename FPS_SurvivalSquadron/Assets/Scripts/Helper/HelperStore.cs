using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class HelperStore
{
    public static void WrriteData<T>(string nameFile, T[] list)
    {
        string path = Getpath(nameFile);
        string data = ToJason<T>(list);
        using(StreamWriter stream = new StreamWriter(path))
        {
            stream.WriteLine(data);
        }
    }
    public static T[] ReadData<T>(string nameFile)
    {
        string path = Getpath(nameFile);
        StreamReader reader = new StreamReader(path);
        string data = reader.ReadLine();
        T[] list = FromJson<T>(data);
        return list;
    }
    private static string Getpath(string nameFile)
    {
        return "Assets/Resources/Map/" + nameFile + ".csv";
    }
    private static string ToJason<T>(T[] list)
    {
        if(list !=null)
        {
            Wrraper<T> wrraper = new Wrraper<T>();
            wrraper.Items = list;
            string data = JsonUtility.ToJson(wrraper);
            return data;
        }
        else
        {
            Debug.Log("Mang can chuyen doi khonog ton tai");
            return null;
        }
        
    }

    private static T[] FromJson<T>(string data)
    {
        Wrraper<T> wrraper = JsonUtility.FromJson<Wrraper<T>>(data);
        return wrraper.Items;
    }
    private class Wrraper<T>
    {
        public T[] Items;
    }
}
