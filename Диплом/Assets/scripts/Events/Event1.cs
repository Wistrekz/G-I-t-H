using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event1 : MonoBehaviour
{
    //dlya animacii
    [Header("For triggers")]
    public float speed;
    public float distance;
    public float CamPause;
    public GameObject OsnCamera;

    [Space]
    [Space]
    [Space]
    [Header("For controller")]
    public GameObject Player;
    public GameObject TriggerForStart;
    public GameObject TriggerForEnd, RealTriggerForEnd;
    public Animator BlackScreen;
    public GameObject[] objects_forDestroy;



    public string PathToThoughts, PathToDialog1, PathToDialog2; //Пути диалога

    public static bool MissionGoing = true;
    public static bool OnStart;                   //Временные переменные показывающие статус события
    public static bool Special_watcher;
    public static bool DialogEnd, DialogStart = true;

    private int Completing = -1;
    private bool ThoughtShowen = true;


    //Параметры движения камеры
    private float CamStopHere;
    private float CamStarthere;
    private bool AnimateStart;

    private bool FirstFrame;

    void Start()
    {
        script_for_Events.Trigger_for_SpecWatcher = TriggerForStart;
        Debug.Log(script_for_Events.Trigger_for_SpecWatcher);

        //Активируем триггеры

    }

    private void Update()
    {
        //Event1 - дойти до дома и поговорить с матерью
        if (MissionGoing)
        {
            EvenT1();
        }
        script_for_Events.Completing_static = Completing;
        Debug.Log("Event1 Completing " + script_for_Events.Completing_static);
    }

    public void EvenT1()
    {
        //Если триггер старта отсутствует
        if (TriggerForStart != null && script_for_Events.Triggername == TriggerForStart.name)
        {
            Completing++;
            Destroy(TriggerForStart);
            OnStart = true;
            script_for_Events.ThinkStart = true;
        }
        //Ожидание триггера катсцены
        if (Completing == 0)
        {
            if (OnStart && !script_for_Events.blackscreen)
            {
                if(ThoughtShowen)
                {
                    //misli geroya na triggere aktiviruyutsya
                    ThinkingReplics.Call_Cutscene_Dialog(PathToThoughts, "Event1Gates");
                    Debug.Log("Showing message");
                    if(script_for_Events.ThinkEnd)    //Показ сообщения
                    {
                        script_for_Events.ThinkEnd = false;
                        script_for_Events.ThinkStart = false;
                        Debug.Log("Hide");
                        OnStart = false;
                        ThoughtShowen = false;
                        script_for_Events.Trigger_for_SpecWatcher = TriggerForEnd;
                        Completing++;
                    }
                }
            }
        }
        //2 etap - proigrish katsceni
        if(Completing == 1)
        {
            //kamera idet k mestu
            Debug.Log(script_for_Events.Trigger_for_SpecWatcher);
            if (script_for_Events.Special_Watcher)
            {
                MissionsShowing.HidePanel();

                CamStopHere = OsnCamera.transform.position.x + distance;  //записывается место нахождение камеры и куда она должна прийти
                CamStarthere = OsnCamera.transform.position.x;
                AnimateStart = true;
            }
            if(AnimateStart)
            {
                Destroy(TriggerForEnd);
                
                script_for_Events.Trigger_for_SpecWatcher = RealTriggerForEnd;
                moving.CantMove = true;
                script_for_Events.NeedFreeCamera = true;                           //Чтобы камера двигалась нужно чтобы она освободилась от игрока
                Debug.Log("StartMovingCamera and " + script_for_Events.NeedFreeCamera);
                OsnCamera.GetComponent<Rigidbody2D>().MovePosition(OsnCamera.transform.position + Vector3.right * Time.deltaTime * speed);

                //Как только расстояние достигнет нужного то камера остановится и начётся диалог
                if (OsnCamera.transform.position.x > CamStopHere)
                {
                    script_for_Events.DialogStart = true;
                    Completing++;
                }
            }
        }
        //Скрипт начинает диалог
        if(Completing == 2)
        {

            MIxed_dialog.Call_Cutscene_Dialog(PathToDialog1);
            if (script_for_Events.DialogEnd)
            {
                script_for_Events.DialogStart = false;
                Completing++;
                script_for_Events.DialogEnd = false;
            }
        }
        if(Completing == 3)
        {
            moving.CantMove = true;  //После диалога камера возвращается на своё место. То есть к персонажу.
                                     //Ему всё время диалога и движения камерой нельзя было двигаться
            Debug.Log("StartMovingCamera and " + script_for_Events.NeedFreeCamera);
            OsnCamera.GetComponent<Rigidbody2D>().MovePosition(OsnCamera.transform.position + Vector3.left * Time.deltaTime * speed);


            //Камера возвращается назад
            //И после этого игроку будет разрешено двигаться
            if (OsnCamera.transform.position.x < CamStarthere)
            {
                moving.CantMove = false;
                script_for_Events.NeedFreeCamera = false;
                Completing++;
            }
            
        }
        if(Completing == 4)
        {
            if(!FirstFrame)
            {
                MissionsShowing.ShowPanel();
                MissionsShowing.UpdateMission(); //Обновление миссии
                FirstFrame = true;
            }

            if (script_for_Events.Special_Watcher)
            {
                foreach (GameObject i in objects_forDestroy) // Уничтожаются все использованные триггеры
                                                             // и объекты блокирующие проход в этом событии
                {
                    Destroy(i);
                }
                Destroy(TriggerForEnd);
                Debug.Log("Event1 vipolnen");
                script_for_Events.Trigger_for_SpecWatcher = null;
                script_for_Events.ScriptNumber = 2;
                script_for_Events.MissionGoing = false;
                
                gameObject.GetComponent<Event2>().enabled = true;
                gameObject.GetComponent<Event1>().enabled = false;
            }
        }
    }

}
