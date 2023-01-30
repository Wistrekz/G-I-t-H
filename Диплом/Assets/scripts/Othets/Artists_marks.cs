using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artists_marks : MonoBehaviour
{
    public static string Namemark_Symbol = "*{KL::'}";
    public static Vector2 Player_coordinates;

    private void Start()
    {
        Debug.Log("sdjghluio098677");
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
