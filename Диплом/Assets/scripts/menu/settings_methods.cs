using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings_methods : MonoBehaviour
{
    public Text lang_place;

    public static string Language_mark_for_all;
    public static bool LangSetIn;

    public static string path_of_SetIn_Langs_forAll;

    private string[] Langs;
    private string[] Marks;

    private int count;

    void Start()
    {
        Dictionary_files.Default_lang_settings(); //нужно будет потом удалить
        StreamReader sr = new StreamReader(path_of_SetIn_Langs_forAll);
        string Langs_and_marks = sr.ReadToEnd();
        Debug.Log(Langs_and_marks);
        sr.Close();
        
        string[] Langs_and_marks_mas = Langs_and_marks.Split(new string[2] { " - ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        int i = 0, r = 0;
        Langs = new string[Langs_and_marks_mas.Length/2];
        Marks = new string[Langs_and_marks_mas.Length/2];
        foreach(string f in Langs_and_marks_mas)
        {
            if (r % 2 == 0)
            {
                Langs[i] = f;
                i++;
            }
            r++;
        }
        i = 0;
        r = 0;
        foreach (string f in Langs_and_marks_mas)
        {
            if (r % 2 != 0)
            {
                Marks[i] = f;
                i++;
            }
            r++;
        }
    }

    public void Leftlanguage()
    {
        if(count == 0)
        {
            if(lang_place.text != Langs[count])
            {
                lang_place.text = Langs[count];
            }
            
        }
        else
        {
            count--;
            if (lang_place.text != Langs[count])
            {
                lang_place.text = Langs[count];
            }
        }
    }
    public void Rightlanguage()
    {
        if (count == Langs.Length - 1)
        {
            if (lang_place.text != Langs[count])
            {
                lang_place.text = Langs[count];
            }
        }
        else
        {
            count++;
            if (lang_place.text != Langs[count])
            {
                lang_place.text = Langs[count];
            }
        }
        
    }
    public void SeT_language()
    {
        for(int f = 0; f < Langs.Length; f++)
        {
            if(lang_place.text == Langs[f])
            {
                Debug.Log(Langs[f]);
                Language_mark_for_all = Marks[f];
                Debug.Log(Language_mark_for_all);
                if(Language_mark_for_all != null)
                {
                    LangSetIn = true;
                }
                return;
            }
        }
        
    }
}
