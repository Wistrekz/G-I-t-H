using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3 : MonoBehaviour
{
    public Animator sdfs;
    //Эвент - разговор с сестрой в комнате сохранения
    public GameObject TriggerForStart;
    public GameObject TriggerForBed;
    public GameObject PlaceforThoughts;
    public Animator BlackScreen;
    public GameObject Mama;
    public GameObject Sheriff;
    public GameObject[] objects_forDestroy, BordersTriggers;
    public string PathToThoughts;
    public string[] PathsToDialogs;


    public static bool MissionGoing;

    private int Completing;
    private int count;

    private void Update()
    {
        if (MissionGoing)
        {
            EvenT3();
        }
    }

    public void EvenT3()
    {
        if (Completing == 0)
        {
            Debug.Log("Зашли в дом");
            if(script_for_Events.blackscreen)
            {
                MIxed_dialog.Call_Cutscene_Dialog(PathsToDialogs[0]);
            }
            if(script_for_Events.DialogEnd)
            {
                Completing++;
            }
        }
        if (Completing == 1)
        {
            /*if(sdfs.GetBool("aweqw"))  //Если будет анимация то заменить норм значением
            {

            } А так будет работать просто выключение*/
            if (script_for_Events.DialogEnd)
            {
                Completing++;
            }

        }
        if (Completing == 2)
        {
            //Телепорт объектов после Разговора
            if (!script_for_Events.blackscreen)
            {
                BlackScreen.SetInteger("ScreenState", 2);
            }
            else
            {
                //Mama.Teleport(staticPosition);
                //Mama.ChangeSprite(forward);
                Debug.Log("Уничтожаются объекты");
                foreach (GameObject f in objects_forDestroy)
                {
                    Destroy(f);
                }
                Completing++;
            }
        }
        if (Completing == 3)
        {
            script_for_Events.MissionGoing = false;
            TriggerForStart.SetActive(false);
            gameObject.GetComponent<Event3>().enabled = true;
            gameObject.GetComponent<Event2>().enabled = false;
        }
    }
}
