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
    public GameObject Player;

    public static bool MissionGoing = true;
    public static bool Cutscenegoing, AnimEnd;
    public static bool Special_watcher;
    public static bool DialogEnd, DialogStart = true;
    public static string SearchingItem, PathToanim;

    private int Completing;


    private void Update()
    {
        EvenT0();
    }

    public void EvenT0()
    {
        if(Completing == 0)
        {
            if (script_for_Events.blackscreen)
            {
                Animations_ev0.SetInteger("ScreenState", 1);
            }
            else
            {
                Debug.Log("Вызывается диалог");
                MIxed_dialog.Call_Cutscene_Dialog(Path);
                if (script_for_Events.DialogEnd)
                {
                    Debug.Log("диалог закончился");
                    Animations_ev0.SetInteger("ScreenState", 2);
                    script_for_Events.DialogEnd = false;
                    moving.CantMove = true;
                    Completing++;
                }
            }
        }
        if (Completing == 1)
        {
            if (!script_for_Events.blackscreen)
            {
                Animations_ev0.SetInteger("ScreenState", 2);
            }
            else
            {
                Debug.Log("Уничтожаются объекты");
                foreach (GameObject f in objects_forDestroy_ev0)
                {
                    Destroy(f);
                }
                Completing++;
            }
            
            
            
            
        }
        if (Completing == 2)
        {
            if (script_for_Events.blackscreen)
            {
                Animations_ev0.SetInteger("ScreenState", 1);
            }
            else
            {
                Debug.Log("Event выполнен");
                moving.CantMove = false;
                Player.GetComponent<Animator>().enabled = false;
                MissionGoing = false;
                gameObject.GetComponent<Event0>().enabled = false;
            }

        }
    }
}
