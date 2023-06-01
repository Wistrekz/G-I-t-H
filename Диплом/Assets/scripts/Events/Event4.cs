using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4 : MonoBehaviour
{


    //publici huyabliki
    public GameObject Player;
    public GameObject[] objects_forDestroy;
    public Animator BlackScreen;
    public Animator StoryPicture;
    public GameObject Sprite_BurnAshes;
    public string[] Path_ForDialog;
    public float TimeForAwait, Rasstoyanie, speed;


    [Header("For Story part")]
    public Vector2 PositionForAgataHouse;
    public Sprite Hans_Sprite;


    private int Completing;
    private bool FirstFrame;

    private void Start()
    {

        foreach (GameObject i in objects_forDestroy)
        {
            i.SetActive(true);
        }
        script_for_Events.ScriptNumber = 4;
        Player.transform.position = PositionForAgataHouse;
        script_for_Events.NeedFreeCamera = false;
    }

    private void FixedUpdate()
    {
        EvenT4();
        Debug.Log(Completing);
        if(FirstFrame)
        {
            Player.GetComponent<SpriteRenderer>().sprite = Hans_Sprite;
        }
    }

    private void EvenT4()
    {
        //Predistoriya - Rasskaz
        if(Completing == 0)
        {
            if(script_for_Events.blackscreen)
            {
                BlackScreen.SetInteger("ScreenState", 1);
                FirstFrame = true;
            }
            if(!script_for_Events.blackscreen)
            {
                script_for_Events.DialogStart = true;
                Completing++;
            }
        }
        if(Completing == 1)
        {
            MIxed_dialog.Call_Cutscene_Dialog(Path_ForDialog[0]);
            if(script_for_Events.DialogEnd)
            {
                script_for_Events.DialogEnd = false;
                script_for_Events.DialogStart = true;
                Completing++;
            }
        }
        Debug.Log(script_for_Events.DialogEnd);
        if (Completing == 2)
        {
            //pokazivaetsya plakat
            MIxed_dialog.Call_Cutscene_Dialog(Path_ForDialog[1]);
            if (script_for_Events.DialogEnd)
            {
                script_for_Events.DialogEnd = false;
                script_for_Events.DialogStart = true;
                Completing++;
            }
        }
        if (Completing == 3)
        {
            //pokazivaetsya plakat s bolshei neprozrachnostyu
            MIxed_dialog.Call_Cutscene_Dialog(Path_ForDialog[1]);
            if (script_for_Events.DialogEnd)
            {
                script_for_Events.DialogEnd = false;
                script_for_Events.DialogStart = true;
                Completing++;
            }
        }
        if (Completing == 4)
        {
            //pokazivaetsya plakat s bolshei neprozrachnostyu
            //StoryPicture.ShowPicture(1, 1);
            Debug.Log("Stop talking");
            MIxed_dialog.Call_Cutscene_Dialog(Path_ForDialog[2]);
            Debug.Log(script_for_Events.DialogEnd);
            if (script_for_Events.DialogEnd)
            {
                script_for_Events.DialogEnd = false;
                Completing++;
            }
        }
        if (Completing == 5)
        {
            BlackScreen.SetInteger("ScreenState", 2);
            if(script_for_Events.blackscreen)
            {
                script_for_Events.DialogStart = false;
                Debug.Log("Event4 zakonchen");
                script_for_Events.MissionGoing = false;
                Room_traveler.SpriteForSizes = Sprite_BurnAshes;
                foreach (GameObject i in objects_forDestroy)
                {
                    Destroy(i);
                }
                script_for_Events.ScriptNumber = 5;
                gameObject.GetComponent<Event5>().enabled = true;
                gameObject.GetComponent<Event4>().enabled = false;
                
            }
        }
            
    }

    public IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
