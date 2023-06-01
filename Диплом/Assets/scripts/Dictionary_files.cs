using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using System;
using UnityEngine.UI;

[XmlRoot("start")]
public class Dictionary_files : MonoBehaviour
{
    private static readonly List<string> Replics = new List<string>();
    private static string[] Replics_mas1;
    public static GameObject ThoughtsPanel;

    private static string[] marks;

    public bool UseDefaultSets, UseNotDefaultSets;

    public static string[] GetLangDictionary(string langFilepath, string obj_name) //Этот метод позволяет взять массив реплик из файла XML опираясь на атрибут-"имя"
    {
        XmlDocument xmlDoc = new XmlDocument();
        langFilepath = langFilepath.Replace("Assets/", "").Replace("Resources/", "");
        langFilepath = langFilepath.Remove(langFilepath.Length - 4);
        Debug.Log(langFilepath);
        langFilepath = Mark_Reader(langFilepath);
        TextAsset textAsset = (TextAsset)Resources.Load(langFilepath);
        Debug.Log(langFilepath);
        Debug.Log(textAsset.text);
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList wordList = xmlDoc.GetElementsByTagName("replic");

        foreach (XmlNode item in wordList)
        {
            if (item.Attributes["name"].Value.Contains(obj_name) || item.Attributes["name"].Value == obj_name)
            {
                Replics.Add(item.InnerText);      
            }
        }
        Replics_mas1 = Replics.ToArray();
        Replics.Clear();
        return Replics_mas1;
    }

    public static string[] GetLangDictionary(string langFilepath, bool withName) //Этот метод позволяет взять массив всех не смотря на имя, но он может включить имя в сам текст
    {
        XmlDocument xmlDoc = new XmlDocument();
        Debug.Log("werwer");
        langFilepath = langFilepath.Replace("Assets/", "").Replace("Resources/", "");
        Debug.Log(langFilepath);
        langFilepath = langFilepath.Remove(langFilepath.Length - 4);
        Debug.Log(langFilepath);
        langFilepath = Mark_Reader(langFilepath);
        TextAsset textAsset = (TextAsset)Resources.Load(langFilepath);
        Debug.Log(textAsset.text);
            xmlDoc.LoadXml(textAsset.text);
            XmlNodeList wordList = xmlDoc.GetElementsByTagName("replic");
            if (withName)
            {
                foreach (XmlNode item in wordList)
                {
                    Replics.Add(item.Attributes["name"].Value + item.InnerText); //отбор текстов по имени
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



    public static string GetLangDictionary_GetName(string Filepath, string replic) //Этот метод позволяет взять имя из файла XML по его пути и реплике
    {
        Filepath = Filepath.Replace("Assets/", "").Replace("Resources/", "");
        Filepath = Filepath.Remove(Filepath.Length - 4);
        Filepath = Mark_Reader(Filepath);
        TextAsset textAsset = (TextAsset)Resources.Load(Filepath);       //Загрузка из файлов
        Debug.Log(textAsset.text);
        string replic_name = null;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList wordList = xmlDoc.GetElementsByTagName("replic");
        foreach (XmlNode item in wordList)
        {
            if(item.InnerText == replic)
            {
                replic_name = item.Attributes["name"].Value;
            }
        }
        return replic_name;
    }

    public static string Mark_Reader(string path) //Данный метод позволяет отрегулировать путь к файлам относительно выбранного пользователем языка
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
                marks[i] = Langs_and_marks_mas[r]; //подборка всех марок
                i++;
            }
        }
        foreach (var u in marks)
        {
            if (path.Contains($"/{u}_"))
            {
                path = path.Replace($"/{u}_", "/" + settings_methods.Language_mark_for_all + "_");
                path = path.Replace($"/{u}/", "/" + settings_methods.Language_mark_for_all + "/"); //замена пути на настоящий
                break;
            }
        }
        return path;
    }


    public static void ShowMessage(string Message)
    {
        /// <summary>
        /// Pokazivaet soobschenie kotoroe nado ubirat
        /// </summary>
        ThoughtsPanel.SetActive(true);
        ThoughtsPanel.GetComponentInChildren<Text>().text = Message;

    }


    public static void HideMessage(GameObject PlaceForThoughts)
    {
        /// <summary>
        /// Ubiraet pokazannoe soobschenie
        /// </summary>
        PlaceForThoughts.SetActive(false);
        script_for_Events.DialogEnd = true;
    }

    public static void Default_lang_settings()
    {
        settings_methods.Language_mark_for_all = "ru"; // русская марка
        settings_methods.path_of_SetIn_Langs_forAll = Application.streamingAssetsPath + "/Languages_l_marks.txt"; //Указывает путь к маркам всех языков локализации в игре

    }

    public static void NotDefault_lang_settings()
    {
        settings_methods.Language_mark_for_all = "en"; //английская марка
        settings_methods.path_of_SetIn_Langs_forAll = Application.streamingAssetsPath + "/Languages_l_marks.txt"; //Указывает путь к маркам всех языков локализации в игре

    }
    private void Start()
    {
        if (UseDefaultSets)
        {
            Non_static_Default_lang_settings();
        }
        if(UseNotDefaultSets)
        {
            Non_static_NotDefault_lang_settings();
        }
    }

    public void Non_static_Default_lang_settings()
    {
        Default_lang_settings();
    }

    public static void Non_static_NotDefault_lang_settings()
    {
        NotDefault_lang_settings();
    }


}
