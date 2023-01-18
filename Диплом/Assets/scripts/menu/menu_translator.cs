using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_translator : MonoBehaviour
{   

    public string path;
    public TextAsset textAsset;
    public Text[] menu_texts;

    private string[] lang_mark;

    public void text_translate()
    {
        Array valuesAsArray = Enum.GetValues(typeof(settings_methods.Lang_marks));
        lang_mark = new string[valuesAsArray.Length];
        int i = 0;
        foreach (var f in valuesAsArray)
        {
            lang_mark[i] = f.ToString();
            i++;
        }
        foreach(var u in lang_mark)
        {
            if(path.Contains($"/{u}_"))
            {
                path = path.Replace($"/{u}_", "/"+settings_methods.Language_mark_for_all+"_");
                break;
            }
        }
        foreach(Text u in menu_texts)
        {
            u.text = Dictionary_files.GetLangDictionary(path, u.name)[0];
        }
    }
}
