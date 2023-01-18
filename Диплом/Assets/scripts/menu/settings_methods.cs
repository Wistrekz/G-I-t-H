using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings_methods : MonoBehaviour
{
    public Text lang_place;

    public static string Language_mark_for_all;

    private string[] Lang_enum;
    private string[] mark_enum;

    private int count;
    private int num;
    enum Languages
    {
        Русский, English
    }
    public enum Lang_marks
    {
        ru, en
    }

    void Start()
    {
        Array valuesAsArray = Enum.GetValues(typeof(Languages));
        Lang_enum = new string[valuesAsArray.Length];
        int i = 0;
        foreach(var f in valuesAsArray)
        {
            Lang_enum[i] = f.ToString();
            i++;
        }
        Array valuesAsArray1 = Enum.GetValues(typeof(Lang_marks));
        mark_enum = new string[valuesAsArray1.Length];
        i = 0;
        foreach (var f in valuesAsArray1)
        {
            mark_enum[i] = f.ToString();
            i++;
        }
    }

    public void Leftlanguage()
    {
        if(count == 0)
        {
            if(lang_place.text != Lang_enum[count])
            {
                lang_place.text = Lang_enum[count];
            }
            
        }
        else
        {
            count--;
            if (lang_place.text != Lang_enum[count])
            {
                lang_place.text = Lang_enum[count];
            }
        }
    }
    public void Rightlanguage()
    {
        if (count == Lang_enum.Length - 1)
        {
            if (lang_place.text != Lang_enum[count])
            {
                lang_place.text = Lang_enum[count];
            }
        }
        else
        {
            count++;
            Debug.Log(count);
            if (lang_place.text != Lang_enum[count])
            {
                lang_place.text = Lang_enum[count];
            }
        }
        
    }
    public void SeT_language()
    {
        for(int f = 0; f < Lang_enum.Length; f++)
        {
            if(lang_place.text == Lang_enum[f])
            {
                Debug.Log(Lang_enum[f] + "равен");
                Language_mark_for_all = mark_enum[f];
                Debug.Log(Language_mark_for_all);
                return;
            }
            num++;
        }
        
    }
}
