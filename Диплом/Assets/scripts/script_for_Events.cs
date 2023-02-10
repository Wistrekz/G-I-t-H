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
    public GameObject[] objects_scenes_ev0;
    [Header("1_Event")]
    public Animator Animations_ev1;
    public bool jier;
    public GameObject[] objects_scenes;



    public static bool MissionGoing;
    public static bool Cutscenegoing;
    public static string SearchingItem;

    private bool EventEnd;

    private void StartNewIvent()
    {
        MissionNumber++;
    }

    public void Event0()
    {
        Cutscenegoing = true;

        if(EventEnd)
        {
            StartNewIvent();
            EventEnd = false;
        }
    }

    public void Event1()
    {

        if (EventEnd)
        {
            StartNewIvent();
            EventEnd = false;
        }
    }

    public void Event2()
    {
        if (EventEnd)
        {
            StartNewIvent();
            EventEnd = false;
        }
    }
    public void Event3()
    {
        if(EventEnd)
        {
            StartNewIvent();
            EventEnd = false;
        }
    }
    public void Event4()
    {
        if (EventEnd)
        {
            StartNewIvent();
            EventEnd = false;
        }
    }
    public void Event5()
    {
        if (EventEnd)
        {
            StartNewIvent();
            EventEnd = false;
        }
    }


    void Update()
    {
        if(PlayerHaveThisItem(SearchingItem))
        {
            StartNewIvent();
        }
        if(MissionGoing)
        {
            switch (MissionNumber)
            {
                case 0:
                    Event0();
                    break;
                case 1:
                    Event1();
                    break;
                case 2:
                    Event2();
                    break;
                case 3:
                    Event3();
                    break;
            }
        }
    }

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
