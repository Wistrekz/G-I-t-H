using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event6 : MonoBehaviour
{
    public GameObject Player;
    public Sprite SpriteForPlayer;
    public GameObject SpriteCherdak;
    public Animator BlackScreen;

    public GameObject triggerforGhost;

    public GameObject[] objects_forDestroy;

    public string Path_ToTalkWithGhost, Path_ToThinkaboutIt;


    private int Completing;
    private bool FirstFrame;

    private void Start()
    {
        script_for_Events.Trigger_for_SpecWatcher = triggerforGhost; //смена триггера
        script_for_Events.DialogStart = true;
        foreach (GameObject i in objects_forDestroy)
        {
            i.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        EvenT6();
        if(FirstFrame)
        {
            Player.GetComponent<SpriteRenderer>().sprite = SpriteForPlayer;
        }
    }

    public void EvenT6()
    {
        if(Completing == 0)
        {
            Debug.Log(Completing);
            Debug.Log(script_for_Events.Special_Watcher + " " + script_for_Events.blackscreen);
            if (script_for_Events.Special_Watcher && !script_for_Events.blackscreen) //Если игрок дошёл до специального триггера то двигаемся дальше
            {
                script_for_Events.DialogStart = true;
                Completing++;
            }
            if(script_for_Events.blackscreen && Room_traveler.SpriteForSizes == SpriteCherdak)
            {
                FirstFrame = true;
                MissionsShowing.HidePanel();
            }
        }
        if (Completing == 1)
        {
            Debug.Log(Completing);
            MIxed_dialog.Call_Cutscene_Dialog(Path_ToTalkWithGhost); //Разговор с призраком
            if (script_for_Events.DialogEnd)
            {
                script_for_Events.DialogStart = false;
                script_for_Events.ThinkStart = true;
                Destroy(triggerforGhost);
                Completing++;
            }
        }
        if (Completing == 2)
        {
            Player.GetComponent<SpriteRenderer>().sprite = SpriteForPlayer;
            BlackScreen.SetInteger("ScreenState", 2);
            if (script_for_Events.blackscreen)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
