using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event0 : MonoBehaviour
{
    public Animator Animations_ev0;        //Подготовка вещей
    public GameObject[] objects_forDestroy_ev0; //Объекты для уничтожения
    public GameObject SpriteForStart;
    public Image black_screen;
    public string Path;  //Путь для разговора 
    public GameObject Player;    //Игрок


    public static bool MissionGoing = true;
    public static bool Cutscenegoing, AnimEnd;
    public static bool Special_watcher;

    private int Completing = 0; //Счётчик законченности события

    private void Awake()
    {
        MissionsShowing.HidePanel();
        script_for_Events.ScriptNumber = 0;
        Room_traveler.SpriteForSizes = SpriteForStart;
        
    }

    private void Update()
    {
        EvenT0();
        script_for_Events.Completing_static = Completing;
    }

    public void EvenT0()
    {
        Debug.Log("Completing " + script_for_Events.Completing_static);
        //Катсцена с уездом отца
        if (Completing == 0)
        {
            if (script_for_Events.blackscreen)
            {
                script_for_Events.DialogStart = true;
                Debug.Log("диалогСтарт " + script_for_Events.DialogStart);  
                Animations_ev0.SetInteger("ScreenState", 1);            //Убирается чёрный экран
            }
            else
            {
                Debug.Log("Вызывается диалог");
                MIxed_dialog.Call_Cutscene_Dialog(Path);  //Диалог начался
                if (script_for_Events.DialogEnd)
                {
                    Debug.Log("диалог закончился");  //Диалог закончился
                    Animations_ev0.SetInteger("ScreenState", 2);
                    script_for_Events.DialogEnd = false;
                    
                    moving.CantMove = true;  //Игра запрещает двигаться
                    Completing++;
                }
            }
        }
        if (Completing == 1)
        {
            if (!script_for_Events.blackscreen)
            {
                Animations_ev0.SetInteger("ScreenState", 2);   //Экран становится чёрным
            }
            else
            {
                Debug.Log("Уничтожаются объекты");
                foreach (GameObject f in objects_forDestroy_ev0) //Уничтожаются объекты
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
                Animations_ev0.SetInteger("ScreenState", 1); //Убирается чёрный экран
            }
            else
            {
                MissionsShowing.ShowPanel();
                MissionsShowing.UpdateMission();
                Debug.Log("Event0 выполнен");
                moving.CantMove = false;
                MissionGoing = false;                              //Обнуляются все переменные
                script_for_Events.AnimateEnd = false;
                Player.GetComponent<Animator>().enabled = false;
                script_for_Events.ScriptNumber = 1;
                gameObject.GetComponent<Event1>().enabled = true;   //Активируется следующий скрипт
                gameObject.GetComponent<Event0>().enabled = false;
            }

        }
    }
}
