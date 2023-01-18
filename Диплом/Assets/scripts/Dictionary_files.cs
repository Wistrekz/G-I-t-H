using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;


[XmlRoot("start")]
public class Dictionary_files : MonoBehaviour
{
    private static readonly List<string> Replics = new List<string>();
    private static string[] Replics_mas2;
    private static string[] Replics_mas1;
    private static Artists_marks actors;

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
        Replics_mas1 = new string[Replics.Count];
        Replics_mas1 = Replics.ToArray();
        Replics.Clear();
        return Replics_mas1;
    }

    public static string[] GetLangDictionary_players_color(string langFilepath)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(langFilepath);
        XmlNodeList wordList = xmlDoc.GetElementsByTagName("replic");
        foreach (XmlNode item in wordList)
        {
            Replics.Add(item.Attributes["name"] + item.InnerText);
        }
        Replics_mas1 = new string[Replics.Count];
        Replics_mas1 = Replics.ToArray();
        Replics.Clear();
        return Replics_mas1;
    }
}
