using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class script_for_Events : MonoBehaviour
{
    [Header("general_sets")]
    public int MissionNumber;
    [Space]



    public static bool MissionGoing = true;
    public static string Triggername;
    public static bool Cutscenegoing;
    public static bool Special_watcher;
    public static bool blackscreen = true;
    public static bool DialogEnd, DialogStart = true;
    public static string SearchingItem, PathToanim;


    private bool EventEnd;

    public void NextScene(int scene_num)
    {
        SceneManager.LoadScene(scene_num);
    }
    public void SetLanguageIn()
    {
        if (!settings_methods.LangSetIn)
        {
            Dictionary_files.Default_lang_settings();
        }
    }

    public bool PlayerHaveThisItem(string ItemName)
    {
        bool IsHehave = false;
        return IsHehave;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Hans")
        {
            Special_watcher = true;
            Triggername = gameObject.name;
        }
    }
}
