using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event1 : MonoBehaviour
{
    public GameObject TriggerForStart;
    public GameObject TrrigerForDialog;
    public GameObject TrrigerForDialog2;
    public GameObject[] BordersTriggers;
    public Animator BlackScreen;
    public GameObject Thoughts;
    public GameObject[] objects_forDestroy;
    public string PathToThoughts, PathToDialog1, PathToDialog2;

    public static bool MissionGoing = true;
    public static bool Cutscenegoing, OnStart;
    public static bool Special_watcher;
    public static bool DialogEnd, DialogStart = true;

    private int Completing;
    private int count;

    private void Awake()
    {

    }

    private void Update()
    {
        //Эвент - Говор вокруг дома и внутри
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
                    Dictionary_files.ShowMessage(Thoughts, Dictionary_files.GetLangDictionary(PathToThoughts, $"Trigger{count}")[0]);
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
                Dictionary_files.ShowMessage(Thoughts, Dictionary_files.GetLangDictionary(PathToThoughts, $"TriggerStart")[0]);
                Completing++;
            }
        }
        if(Completing == 1)
        {
            MIxed_dialog.Call_Cutscene_Dialog(PathToDialog1);
            if(script_for_Events.DialogEnd)
            {
                Completing++;
            }

        }
        if(Completing == 2)
        {
            if (!script_for_Events.blackscreen)
            {
                BlackScreen.SetInteger("ScreenState", 2);
            }
            else
            {
                Debug.Log("Уничтожаются объекты");
                foreach (GameObject f in objects_forDestroy)
                {
                    Destroy(f);
                }
                Completing++;
            }
        }
        if(Completing == 3)
        {
            foreach(GameObject o in BordersTriggers)
            {
                o.SetActive(false);
            }
            script_for_Events.MissionGoing = false;
            gameObject.GetComponent<Event1>().enabled = false;
        }
    }
}
