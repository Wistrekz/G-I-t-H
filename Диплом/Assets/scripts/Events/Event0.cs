using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event0 : MonoBehaviour
{
    public Animator Animations_ev0;
    public GameObject[] objects_forDestroy_ev0;
    public Image black_screen;
    public string Path;

    public static bool MissionGoing = true;
    public static bool Cutscenegoing, EventEnd;
    public static bool Special_watcher, NPCTalking = true;
    public static bool blackscreen = true;
    public static bool DialogEnd, DialogStart = true;
    public static string SearchingItem, PathToanim;

    private void Update()
    {
        EvenT0();
    }

    public void EvenT0()
    {
        Cutscenegoing = true;
        Debug.Log("wer");
        if (blackscreen)
        {
            Debug.Log("wer123");
            Animations_ev0.SetInteger("screenState", 2);
            
        }
        if (!blackscreen)
        {
            Debug.Log("wertyu7eikr11111");
            NPCTalking = false;
            DialogManager.Call_Cutscene_Dialog(Path);
            if (DialogEnd)
            {
                Animations_ev0.SetInteger("screenState", 1);
                DialogEnd = false;
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
                Debug.Log("Event выполнен");
                EventEnd = false;
                NPCTalking = true;
            }
        }

    }
}
