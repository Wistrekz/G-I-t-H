using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event1 : MonoBehaviour
{
    public GameObject Player;
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

    private int Completing = -1;
    private int count;
    private int thoughtsReplics;
    private string[] Messages;
    private bool ThoughtShowen = true;

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
        
        if (TriggerForStart != null && script_for_Events.Triggername == TriggerForStart.name)
        {
            Completing++;
            Destroy(TriggerForStart);
            OnStart = true;

        }
        if (Completing == 0)
        {
            //targetmenu.ShowMission();
            if (OnStart && !script_for_Events.blackscreen)
            {
                Messages = Dictionary_files.GetLangDictionary(PathToThoughts, $"Event1Gates");
                if(ThoughtShowen)
                {
                    Dictionary_files.ShowMessage(Thoughts, Dictionary_files.GetLangDictionary(PathToThoughts, $"Event1Gates")[count]);
                    if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                    {
                        count++;
                    }
                    moving.CantMove = true;
                }
                if(count == Messages.Length)
                {
                    Dictionary_files.HideMessage(Thoughts);
                    OnStart = false;
                    moving.CantMove = false;
                    ThoughtShowen = false;
                    Completing++;
                }
                
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
            if(script_for_Events.blackscreen)
            {
                foreach (GameObject o in BordersTriggers)
                {
                    o.SetActive(false);
                }
                script_for_Events.MissionGoing = false;
                gameObject.GetComponent<Event2>().enabled = true;
                gameObject.GetComponent<Event1>().enabled = false;
            }
            
        }
    }
}
