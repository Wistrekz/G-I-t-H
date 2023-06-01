using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event5 : MonoBehaviour
{
    public GameObject Player;

    public GameObject ThoughtsPanel;
    public Animator BlackScreen;
    public GameObject triggerForTree, Static_triggerForTree, OsnCamera; //Обозначение специальных триггеров
    public GameObject[] objects_forDestroy;
    public Text MissionsText;

    //триггеры и спрайты для прсонажей
    public GameObject Pol_trigger, Agata_trigger, triggerForGates;
    public Sprite[] Pol_Sprites, Agata_sprites;


    public string Path_ToTalkInBurnAshes, Path_ToReadNote, Path_ToConnectWithTree, Path_ToFailConnectWithTree; //Пути для нужных диалогов и 
    public Vector2 TeleportToBurningPlace;

    //для телепортации персонажей
    public Vector2 AgataSearchPosition, PolSearchPosition;
    public Sprite Hans_Sprite;

    public string EventThing_ForTree, EventThingWeGet;


    //Пути диалогов для дополнительного лора
    public string Path_TalkWithAgata, Agata_Failfound, Agata_SuccessFound;
    public string Path_TalkWithPol, Pol_Failfound, Pol_SuccessFound;

    private int Completing;

    //Временная переменная нужная чтобы сделать часть скрипта один раз
    private bool IsDeleteBorders;

    //Для последовательности. Что было первым: дерево или записка?
    private bool Treefirst;

    private bool FirstFrame;

    private void Start()
    {
        foreach (GameObject i in objects_forDestroy) //Активация нужных объектов
        {
            i.SetActive(true);
        }
        Player.transform.position = TeleportToBurningPlace;
        script_for_Events.Trigger_for_Enter_SpecWatcher = triggerForTree; //Перенастройка специального триггера
        script_for_Events.ScriptNumber = 5;
    }


    private void FixedUpdate()
    {
        EvenT5();
    }

    private void EvenT5()
    {
        if(Completing == 0)
        {
            moving.CantMove = true;
            if (script_for_Events.blackscreen)
            {
                BlackScreen.SetInteger("ScreenState", 1); //Убирание тёмного экрана
                Player.GetComponent<SpriteRenderer>().sprite = Hans_Sprite;
            }
            if (!script_for_Events.blackscreen)
            {
                script_for_Events.DialogStart = true;

                moving.CantMove = false;
                Completing++;
            }
        }
        if (Completing == 1)
        {
            MIxed_dialog.Call_Cutscene_Dialog(Path_ToTalkInBurnAshes); // начало диалога
            if(script_for_Events.DialogEnd)
            {
                MissionsShowing.UpdateMission();
                MissionsShowing.ShowPanel();
                //Убирание тёмного экрана
                script_for_Events.DialogEnd = false;
                Completing++;
                return;
            }
        }
        if(Completing == 2)
        {
            foreach (Transform i in objects_forDestroy[1].GetComponentsInChildren<Transform>())
            {
                if (i.name.Contains("Agata"))
                {
                    i.position = Agata_trigger.transform.position; //Телепортация персонажей после разговора
                }
                if (i.name.Contains("Pol"))
                {
                    i.position = Pol_trigger.transform.position;
                    Completing++;
                    return;
                }
            }
            if (!script_for_Events.blackscreen)
            {

                script_for_Events.DialogStart = true;
                moving.CantMove = false;
                
            }
        }
        //tut nachinaetsya sam kvest
        if (Completing == 3)
        {
            //Если игрок подошёл к записке то триггер дерева меняется вместе с диалогом который к ней прикреплен
            if(script_for_Events.Special_Enter_Watcher || !Treefirst)
            {
                Debug.Log("hueta");
                Treefirst = true;
                if(script_for_Events.ReadsEventNote)
                {
                }
                else
                {
                    ThinkingReplics.Call_Cutscene_Dialog(Path_ToConnectWithTree, "FindFirst"); //Мысли героя
                    if (script_for_Events.ThinkEnd)
                    {
                        script_for_Events.ThinkEnd = false; //Конец мыслей
                        script_for_Events.ThinkStart = true;
                        Completing++;
                        return;
                    }
                }

            }
            //Чтение записки
            if (script_for_Events.ReadsEventNote)
            {
                Debug.Log("right");
                triggerForTree.SetActive(false);
                MissionsShowing.UpdateMission();
                Static_triggerForTree.SetActive(true);
                Completing++;
                return;
            }
        }
        if(Completing == 4)
        {
            Debug.Log("Completing 3");
            //Удаление границ через которые не мог пройти игрок пока не нашёл записку
            if (!IsDeleteBorders)
            {
                Destroy(triggerForGates);
                IsDeleteBorders = true;
            }
            if(Take_the_Item.WeTakeIt)
            {
                MissionsShowing.UpdateMission();
                script_for_Events.ThinkEnd = false;
                //MissionsShowing.UpdateMission(MissionsText); //Обновление миссии
                triggerForTree.SetActive(true);
                Static_triggerForTree.SetActive(false);
                script_for_Events.Trigger_for_Enter_SpecWatcher = triggerForTree;
                script_for_Events.Special_Enter_Watcher = false;
                script_for_Events.ThinkStart = true;
                //Смена триггера
                Completing++;
            }
        }
        if(Completing == 5)
        {
            Debug.Log("Completing " + Completing);
            if (script_for_Events.Special_Enter_Watcher)
            {
                Debug.Log("Ура");
                Debug.Log(Cheats.WRITEInventory());
                if (Cheats.CheckInventoryOnThisItem(EventThing_ForTree))
                {
                    ThinkingReplics.Call_Cutscene_Dialog(Path_ToConnectWithTree, "ThingDetected");
                    if (script_for_Events.ThinkEnd)
                    {
                        MissionsShowing.UpdateMission();
                        Cheats.Inventory_Delete("Cube");
                        Cheats.Inventory_Add("Ключ");
                        script_for_Events.ThinkEnd = false;
                        //MissionsShowing.UpdateMission(MissionsText); //Обновление миссии
                        Completing++;
                    }
                }
            }
        }
        if (Completing == 6)
        {
            Debug.Log("Event5 zakonchen");
            script_for_Events.MissionGoing = false;
            foreach (GameObject i in objects_forDestroy) //Уничтожение ненужных вещей
            {
                Destroy(i);
            }
            script_for_Events.ScriptNumber = 6;
            MissionsShowing.UpdateMission();
            gameObject.GetComponent<Event6>().enabled = true;
            gameObject.GetComponent<Event5>().enabled = false;
        }
    }
}
