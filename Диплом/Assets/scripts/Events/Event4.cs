using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4 : MonoBehaviour
{
    //����� - �������: ����� ��������
    public Animator sdfs;
    //����� - �������� � ������� � ������� ����������
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
            //�������� �������� ����� ���������

            
        }
        if (Completing == 3)
        {

        }
    }
}
