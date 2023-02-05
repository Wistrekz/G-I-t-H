using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class script_for_Events : MonoBehaviour
{
    public static bool MissionGoing;
    public static bool Cutscenegoing;
    public static int MissionNumber;

    private void StartNewIvent()
    {
        MissionNumber++;
    }

    public static void Event1()
    {

    }

    void Update()
    {
        if(Input.GetButton("Fire3") || Input.GetButton("Fire4"))
        {
            StartNewIvent();
        }
        switch(MissionNumber)
        {
            case 1:
                Event1();
                break;
            case 2:
                Event1();
                break;
            case 3:
                Event1();
                break;
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
}
