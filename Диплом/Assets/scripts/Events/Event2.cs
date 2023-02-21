using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    //Эвент - разговор внутри
    public GameObject TriggerForStart;
    public GameObject TriggerForBed;
    public GameObject PlaceforThoughts;
    public Animator BlackScreen;
    public GameObject[] objects_forDestroy, BordersTriggers;
    public string PathToThoughts;
    public string PathToDialog;


    public static bool MissionGoing;

    private int Completing;
    private int count;

    private void Update()
    {
        if (MissionGoing)
        {
            EvenT2();
        }
    }

    public void EvenT2()
    {
        if (Completing == 0)
        {
            Debug.Log("Найти дом");
            //targetmenu.ShowMission();
        }
        if (Completing == 1)
        {
            MIxed_dialog.Call_Cutscene_Dialog(PathToDialog);
            if (script_for_Events.DialogEnd)
            {
                Completing++;
            }

        }
        if (Completing == 2)
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
                    //уничтожаются со звуком захода за дверь
                }
                Completing++;
            }
        }
        if (Completing == 3)
        {
            script_for_Events.MissionGoing = false;
            TriggerForBed.SetActive(false);
            gameObject.GetComponent<Event3>().enabled = true;
            gameObject.GetComponent<Event2>().enabled = false;
        }
    }
}
