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
    [Header("0_Event")]
    public Animator Animations_ev0;
    public GameObject[] objects_forDestroy_ev0;
    public Image black_screen;
    public float black_screen_step, black_screen_interval;
    public string PathToAnim;
    public string Path;
    [Header("1_Event")]
    public Animator Animations_ev1;
    public bool jier;
    public GameObject[] objects_scenes;



    public static bool MissionGoing = true;
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
}
