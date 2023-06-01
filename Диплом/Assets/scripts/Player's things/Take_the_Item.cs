using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_the_Item : MonoBehaviour
{
    public GameObject Getter_object;

    public string PathForKomment, NameForComment, NameForCommentNull;

    public GameObject ThoughtsPanel;

    private int count = 0;
    private bool heExist;

    private bool StartScript;

    public static bool WeTakeIt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartScript = true; //Если игрок зайдёт в зону этого персонажа то стартует скрипт
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartScript = false; //Скрипт отменяется если пресонаж из неё вышел
    }

    private void Update()
    {
        if(StartScript)
        {
            Debug.Log("Rabotai");
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || heExist)
            {
                script_for_Events.ThinkStart = true;
                Debug.Log("1 " + Getter_object == null && !heExist);
                if (Getter_object == null && !heExist)
                {
                    Debug.Log("Rabotai!!!!!");
                    ThinkingReplics.Call_Cutscene_Dialog(PathForKomment, NameForCommentNull); //Персонаж думает или высказывает мнение
                    if (script_for_Events.ThinkEnd)
                    {
                        script_for_Events.ThinkEnd = false; //Закончил мысль
                        moving.CantMove = true;
                        heExist = true; Debug.Log("Pizdec");
                    }
                }
                else
                {
                    if(!heExist)
                    {
                        ThinkingReplics.Call_Cutscene_Dialog(PathForKomment, NameForComment);//Персонаж думает или высказывает мнение об отсутсвии
                        heExist = true;
                    }
                    Debug.Log("2 " + script_for_Events.ThinkEnd);
                    if (script_for_Events.ThinkEnd)
                    {
                        script_for_Events.ThinkStart = false;
                        script_for_Events.ThinkEnd = false; //Закончил мысль
                        count++;
                        Debug.Log(count);
                    }
                }
                if (count == 1)
                {
                    Cheats.Inventory_Add(Getter_object.name);
                    Debug.Log("Hide");
                    //Getter_object.GetComponent<AudioSource>().Play();  //проигрывается звук
                    moving.CantMove = false;
                    WeTakeIt = true;
                    script_for_Events.Special_Enter_Watcher = true;
                    heExist = false;
                }
            }
        }
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
