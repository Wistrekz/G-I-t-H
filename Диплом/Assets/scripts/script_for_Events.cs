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
    public static string SearchingItem;


    private bool EventEnd;

    private void StartNewIvent()
    {
        MissionNumber++;
    }

    public void Event0()
    {
        Debug.Log("wer");
        if(blackscreen)
        {
            Debug.Log("wertyu7eikr");
            Appearance.Dissappear(black_screen, black_screen_step, black_screen_interval);
        }
        if(!blackscreen)
        {
            Debug.Log("wertyu7eikr11111");
            DialogManager.Call_Cutscene_Dialog(Path);
            if (DialogEnd)
            {
                Animations_ev0.SetBool("dialog1End", true);
                DialogEnd = false;
                Appearance.Appears(black_screen, black_screen_step, black_screen_interval);
                if (blackscreen)
                {
                    foreach (GameObject f in objects_forDestroy_ev0)
                    {
                        Destroy(f);
                    }
                    EventEnd = true;
                }
            }

            if (EventEnd)
            {
                StartNewIvent();
                EventEnd = false;
            }
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
        if(PlayerHaveThisItem(SearchingItem) && SearchingItem != null)
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
