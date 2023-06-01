using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event3 : MonoBehaviour
{
    //Event3 - pizdej s materyu i poisk cvetka i razgovor so polom
    public Animator Player;
    public Camera OsnCamera;
    public GameObject TriggerForStart;
    public Sprite SpriteForTurn;
    public GameObject TriggerForFlower, TriggerForEnd;
    public Animator BlackScreen;
    public GameObject Sprite_Agatahouse;


    [Header("For Destroy")]
    public GameObject[] objects_forDestroy;
    public string[] PathsToDialogs;

    [Header("MoveCamera")]
    public int speed;
    public float distance;

    [Header("Actors")]
    public GameObject Mama;
    public Sprite Mom_Sprite;
    public GameObject Pol;
    public Sprite Pol_Sprite, Hans_Sprite;


    public static bool MissionGoing;

    private int Completing;
    private int count;
    private float CamStarthere, CamStopHere; //Параметры для движения камеры
    private bool AnimStart, OneTimeEnd;
    private bool FirstFrame, SecondFirstFrame;

    private void Start()
    {
        foreach (GameObject i in objects_forDestroy) //Активация всех нужных объектов
        {
            i.SetActive(true);
        }
        Debug.Log("Event3 Start");
        script_for_Events.Trigger_for_SpecWatcher = TriggerForStart; //Переназначение специального триггера для слежкой за событиями
        Debug.Log(script_for_Events.Trigger_for_SpecWatcher);
        Pol.SetActive(false);
        MissionsShowing.HidePanel();
        script_for_Events.ScriptNumber = 3;
    }

    private void FixedUpdate()
    {
        EvenT3();
        if(SecondFirstFrame)
        {
            Player.GetComponent<SpriteRenderer>().sprite = SpriteForTurn;
        }
    }

    public void EvenT3()
    {
        if(!FirstFrame)
        {
            MissionsShowing.HidePanel();
            FirstFrame = true;
        }
        Debug.Log("Proverka");
        Debug.Log("Event3" + Completing);
        //После разговора с сестрой персонаж выходит из комнаты и видит мать
        if (Completing == 0)
        {
            Debug.Log("Proverka  0");
            Debug.Log(!script_for_Events.blackscreen && script_for_Events.Special_Watcher);
            if (!script_for_Events.blackscreen && script_for_Events.Special_Watcher) //После выхода из комнаты происходит анимация
                //и начинается диалог
            {
                Debug.Log("Proverka na event3");
                Debug.Log("AnimEnd " + script_for_Events.AnimateEnd);
                script_for_Events.Special_Watcher = false;
                script_for_Events.DialogStart = true;
                Player.GetComponent<SpriteRenderer>().sprite = SpriteForTurn;
                Completing++;

            }
        }
        if(Completing == 1)
        {
            MIxed_dialog.Call_Cutscene_Dialog(PathsToDialogs[0]);  //Начало диалога
            if (script_for_Events.DialogEnd)
            {
                MissionsShowing.UpdateMission();
                MissionsShowing.ShowPanel();
                Destroy(TriggerForStart);
                Mama.GetComponent<SpriteRenderer>().sprite = Mom_Sprite;
                script_for_Events.Trigger_for_SpecWatcher = TriggerForFlower;
                script_for_Events.DialogEnd = false;
                //MissionsShowing.UpdateMission(MissionsText); //Обновление миссии
                Completing++;
            }
        }
        if(Completing == 2)
        {
            if(script_for_Events.Special_Watcher)
            {
                Debug.Log("sdafwer0");
                script_for_Events.Trigger_for_SpecWatcher = TriggerForEnd; //Смена специального триггера
                script_for_Events.Special_Watcher = false;
                Completing++;
            }
            
        }
        if(Completing == 3)
        {
            //2-oi. ei ebanii
            if(!AnimStart)
            {
                script_for_Events.DialogStart = true;
                AnimStart = true;
            }
            MIxed_dialog.Call_Cutscene_Dialog(PathsToDialogs[1]); //Начало диалога
            Debug.Log(script_for_Events.DialogEnd);
            if (script_for_Events.DialogEnd)      //Конец диалога
            {
                script_for_Events.DialogEnd = false;
                script_for_Events.DialogStart = false;
                AnimStart = false;
                Pol.SetActive(true);
                Completing++;
            }
        }
        if (Completing == 4)
        {

            if (!AnimStart)
            {
                Debug.Log("sdafwer");
                CamStopHere = OsnCamera.transform.position.x - distance;
                CamStarthere = OsnCamera.transform.position.x;
                AnimStart = true;
                moving.CantMove = true;
                script_for_Events.Special_Watcher = false;
                script_for_Events.NeedFreeCamera = true;
                return;
            }
            if(AnimStart)
            {
                //Уничтожается объект для предотвращения ошибки
                if(!OneTimeEnd)
                {
                    Pol.GetComponent<SpriteRenderer>().sprite = Pol_Sprite;
                    SecondFirstFrame = true;
                    script_for_Events.DialogStart = true;
                    Destroy(TriggerForFlower);
                    OneTimeEnd = true;
                }
                //Снова камера двигается в нужную сторону
                if (OsnCamera.transform.position.x < CamStopHere)
                {
                    Debug.Log("sdafwer2");
                    //Начало диалога
                    MIxed_dialog.Call_Cutscene_Dialog(PathsToDialogs[2]);
                    if(script_for_Events.DialogEnd)
                        //Конец диалога
                    {
                        script_for_Events.DialogStart = false;
                        script_for_Events.DialogEnd = false;
                        AnimStart = false;
                        Completing++;
                    }
                }
                else
                {
                    moving.CantMove = true;
                    Debug.Log("Move left");     //После диалога происходит телепортация во время неё тоже двигаться нельзя
                    script_for_Events.NeedFreeCamera = true;
                    OsnCamera.GetComponent<Rigidbody2D>().MovePosition(OsnCamera.transform.position + Vector3.left * Time.deltaTime * speed);
                }
            }

        }
        if (Completing == 5)
        {
            //Утемнение экрана
            if(!script_for_Events.blackscreen)
            {
                BlackScreen.SetInteger("ScreenState", 2);
            }
            if(script_for_Events.blackscreen)
            {
                Room_traveler.SpriteForSizes = Sprite_Agatahouse;
                Completing++;
            }
        }
        if (Completing == 6)
        {
            MissionsShowing.HidePanel(); //Обновление миссии
            Debug.Log("Event3 zakonchen");
            script_for_Events.MissionGoing = false;
            foreach (GameObject i in objects_forDestroy)
            {
                Destroy(i);
            }
            script_for_Events.ScriptNumber = 4;
            gameObject.GetComponent<Event4>().enabled = true;
            gameObject.GetComponent<Event3>().enabled = false;
        }
    }
}
