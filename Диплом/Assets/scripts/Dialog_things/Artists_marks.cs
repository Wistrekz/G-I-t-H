using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artists_marks : MonoBehaviour
{
    public string[,] Artists_colors;

    public static string Namemark_Symbol = "*{KL::'}";

    private void Start()
    {
        SetLanguageIn();
    }

    public void SetLanguageIn()
    {
        if(!settings_methods.LangSetIn)
        {
            Dictionary_files.Default_lang_settings();
        }
    }
}
