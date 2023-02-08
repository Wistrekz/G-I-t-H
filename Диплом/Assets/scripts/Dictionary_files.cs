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

    private static string[] marks;

    public static string[] GetLangDictionary(string langFilepath, string obj_name)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(langFilepath);
        XmlNodeList wordList = xmlDoc.GetElementsByTagName("replic");

        foreach (XmlNode item in wordList)
        {
            if (item.Attributes["name"].Value.Contains(obj_name))
            {
                Replics.Add(item.InnerText);
            }
        }
        Replics_mas1 = Replics.ToArray();
        Replics.Clear();
        return Replics_mas1;
    }

    public static string[] GetLangDictionary(string langFilepath, bool withName)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(langFilepath);
        XmlNodeList wordList = xmlDoc.GetElementsByTagName("replic");
        if(withName)
        {
            foreach (XmlNode item in wordList)
            {
                Replics.Add(item.Attributes["name"].Value + item.InnerText);
                Debug.Log(item.Attributes["name"].Value);
            }
        }
        else
        {
            foreach (XmlNode item in wordList)
            {
                Replics.Add(item.InnerText);
            }
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

    public static string Mark_Reader(string path)
    {
        StreamReader sr = new StreamReader(settings_methods.path_of_SetIn_Langs_forAll);
        string Langs_and_marks = sr.ReadToEnd();
        sr.Close();
        string[] Langs_and_marks_mas = Langs_and_marks.Split(new string[2] { " - ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        marks = new string[Langs_and_marks_mas.Length/2];
        int i = 0;
        for(int r = 0; r < Langs_and_marks_mas.Length; r++)
        {
            if(r % 2 != 0)
            {
                marks[i] = Langs_and_marks_mas[r];
                i++;
            }
        }
        foreach (var u in marks)
        {
            if (path.Contains($"/{u}_"))
            {
                path = path.Replace($"/{u}_", "/" + settings_methods.Language_mark_for_all + "_");
                path = path.Replace($"/{u}/", "/" + settings_methods.Language_mark_for_all + "/");
                break;
            }
        }
        return path;
    }
    public static void Default_lang_settings()
    {
        settings_methods.Language_mark_for_all = "ru";
        settings_methods.path_of_SetIn_Langs_forAll = "Assets/Languages_/Settings/Languages_l_marks.txt";

    }
}
