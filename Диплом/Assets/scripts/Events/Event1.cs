using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event1 : MonoBehaviour
{
    public GameObject TriggerForStart;
    public GameObject[] BordersTriggers;
    public Animator BlackScreen;
    public GameObject Thoughts;
    public string Path;

    public static bool MissionGoing = true;
    public static bool Cutscenegoing, OnStart;
    public static bool Special_watcher;
    public static bool blackscreen = true;
    public static bool DialogEnd, DialogStart = true;
    public static string SearchingItem, PathToanim;

    private int Completing;
    private int count;

    private void Awake()
    {

    }

    private void Update()
    {
        if(MissionGoing)
        {
            EvenT1();
        }
        if(script_for_Events.Special_watcher)
        {
            foreach(GameObject o in BordersTriggers)
            {
                if(o.gameObject.name == script_for_Events.Triggername)
                {
                    Dictionary_files.ShowMessage(Thoughts, Dictionary_files.GetLangDictionary(Path, $"Trigger{count}")[0]);
                    break;
                }
                count++;
            }
        }
    }

    public void EvenT1()
    {
        if(Completing == 0)
        {
            Debug.Log("Найти дом");
            //targetmenu.ShowMission();
            if (OnStart)
            {
                Dictionary_files.ShowMessage(Thoughts, Dictionary_files.GetLangDictionary(Path, $"TriggerStart")[0]);
                Completing++;
            }
        }
        if(Completing == 1)
        {

        }
        if(Completing == 2)
        {

        }
        if(Completing == 3)
        {

        }
        if(Completing == 4)
        {

        }

    }
}
