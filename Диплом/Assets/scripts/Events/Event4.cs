using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4 : MonoBehaviour
{
    //Эвент - Задание: Найти цветочки
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

        }
        if (Completing == 1)
        {
            

        }
        if (Completing == 2)
        {
            //Телепорт объектов после Разговора

            
        }
        if (Completing == 3)
        {

        }
    }
}
