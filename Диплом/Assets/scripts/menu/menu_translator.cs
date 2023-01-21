using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_translator : MonoBehaviour
{   

    public string path;
    public Text[] menu_texts;


    public void text_translate()
    {
        path = Dictionary_files.Mark_Reader(path);
        Debug.Log("язык" + path);
        foreach(Text u in menu_texts)
        {
            u.text = Dictionary_files.GetLangDictionary(path, u.name)[0];

        }
    }
}
