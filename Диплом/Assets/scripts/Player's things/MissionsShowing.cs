using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionsShowing : MonoBehaviour
{
    public GameObject Star; 
    [SerializeField]
    private Animator StarAnim, TextAnim;
    [SerializeField]
    private Text MissionText;

    public static string FreshMission;
    private static int Numbermissions = 0;


    void Update()
    {

    }

    public static void UpdateMission()
    {
        Debug.Log("Миссия №" + Numbermissions);
        FindObjectOfType<MissionsShowing>().MissionText.text = Dictionary_files.GetLangDictionary(Dictionary_files.Mark_Reader(script_for_Events.Path_ToMissions), "Mission")[Numbermissions];
        Numbermissions++; //Смена миссий Через XML-файлы
    }

    public static void ShowText()
    {
        FindObjectOfType<MissionsShowing>().MissionText.GetComponent<Animator>().SetInteger("TextState", 2); //Плавное убирание задания
    }

    public static void ShowPanel()
    {
        FindObjectOfType<MissionsShowing>().Star.GetComponent<Animator>().SetInteger("StarState", 2); //Плавное убирание задания
        FindObjectOfType<MissionsShowing>().MissionText.GetComponent<Animator>().SetInteger("TextState", 2);
    }

    public static void HidePanel()
    {
        FindObjectOfType<MissionsShowing>().Star.GetComponent<Animator>().SetInteger("StarState", 1); //Плавное возвращение задания
        FindObjectOfType<MissionsShowing>().MissionText.GetComponent<Animator>().SetInteger("TextState", 1); //Плавное возвращение задания
    }
    public static void ClosePanel()
    {
        FindObjectOfType<MissionsShowing>().Star.SetActive(false); //Плавное возвращение задания
    }
}
