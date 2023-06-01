using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event2 : MonoBehaviour
{
    //Event2 - razgovor v dome s sestroi i vzyatie medalyona
    public GameObject TriggerForStart;
    public GameObject TriggerForBed;
    public GameObject Medallion;
    public GameObject PlaceforThoughts;
    public Animator BlackScreen;
    public GameObject[] objects_forDestroy, BordersTriggers;
    public string PathToThoughts;




    public GameObject Sister;

    public string PathToDialog, Staticpath, NameOfCatchMedal;

    public static bool MissionGoing;

    private int Completing;

    private bool FirstFrame;
    private void Start()
    {
        script_for_Events.Trigger_for_SpecWatcher = TriggerForStart;
        script_for_Events.ScriptNumber = 2;

        //���������� ��� ����� �������
        foreach (GameObject i in objects_forDestroy)
        {
            i.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        EvenT2();
        Debug.Log("Event2" + Completing);
    }

    public void EvenT2()
    {
        if (Completing == 0 && !script_for_Events.blackscreen)
        {
            Debug.Log("Awaiting");
            //������� �� ������������ �������� � ������� � �������.
        }
        if (script_for_Events.Special_Watcher)
        {
            script_for_Events.Special_Watcher = false;
            script_for_Events.DialogStart = true;
            Destroy(TriggerForStart);
            Completing++;
        }
        if (Completing == 1)
        {
            if(!script_for_Events.blackscreen)
            {
                if(!FirstFrame)
                {

                }
                MIxed_dialog.Call_Cutscene_Dialog(PathToDialog); //���� ����� �� ����� �� ���������� ������
            }
            if (script_for_Events.DialogEnd)
            {
                script_for_Events.DialogStart = false;
                script_for_Events.DialogEnd = false;
                Completing++;
            }

        }
        if(Completing == 2)
        {
            //MissionsShowing.UpdateMission(MissionsText); //���������� ������
            script_for_Events.Trigger_for_Enter_SpecWatcher = TriggerForBed;
            Debug.Log(Inventory_storage.Player_inventory.Count);
            if (Cheats.CheckInventoryOnThisItem("Medallion"))
            {
                Destroy(Medallion);
                Take_the_Item.WeTakeIt = false;
                script_for_Events.Special_Enter_Watcher = false;
                Completing++;
            }
        }
        if (Completing == 3)
        {
            Debug.Log("Event2 vipolnen");
            foreach (GameObject i in objects_forDestroy)  //����������� ��������
            {
                Destroy(i);
            }
            Debug.Log("������������ �������");
            script_for_Events.ScriptNumber = 3;
            gameObject.GetComponent<Event3>().enabled = true;
            gameObject.GetComponent<Event2>().enabled = false;
        }
    }
}
