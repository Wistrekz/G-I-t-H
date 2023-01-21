using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using System;

[XmlRoot("start")]
public class Dictionary_files : MonoBehaviour
{
    private static readonly List<string> Replics = new List<string>();
    private static string[] Replics_mas1;

    public static string[] GetLangDictionary(string langFilepath, string obj_name)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(langFilepath);
        XmlNodeList wordList = xmlDoc.GetElementsByTagName("replic");
        foreach (XmlNode item in wordList)
        {
            if (item.Attributes["name"].Value == obj_name)
            {
                Replics.Add(item.InnerText);
            }
        }
        Replics_mas1 = Replics.ToArray();
        Replics.Clear();
        return Replics_mas1;
    }

    public static string[] GetLangDictionary(string langFilepath)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(langFilepath);
        XmlNodeList wordList = xmlDoc.GetElementsByTagName("replic");
        foreach (XmlNode item in wordList)
        {
            Replics.Add(item.Attributes["name"].Value + item.InnerText);
            Debug.Log(item.Attributes["name"].Value);
        }
        Replics_mas1 = new string[Replics.Count];
        Replics_mas1 = Replics.ToArray();
        Replics.Clear();
        return Replics_mas1;
    }
    public static string GetLangDictionary_FromNameToColor(string Filepath, string Name)
    {
        StreamReader sr = new StreamReader(Filepath);
        string Colors_and_names = sr.ReadToEnd();
        sr.Close();
        Debug.Log(Name);
        string[] Colors_and_names_mas = Colors_and_names.Split(new string[2] { "-", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        for(int i = 0; i < Colors_and_names_mas.Length; i++)
        {
            if(Colors_and_names_mas[i] == Name)
            {
                return Colors_and_names_mas[i + 1];
            }
        }
        Replics.Clear();
        return Colors_and_names_mas[Colors_and_names_mas.Length - 1];
    }
}
