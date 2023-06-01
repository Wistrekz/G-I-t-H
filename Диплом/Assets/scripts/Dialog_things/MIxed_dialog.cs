using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MIxed_dialog : MonoBehaviour
{
    public Text dialogtext;
    public GameObject panel;
    public Text nametext;
    public moving Player;

    private string[] replics;
    private bool inTrigger;
    private int number;
    private static string pathFor;
    private static string Namereplic = "Non";
    private static bool NeedName;
    void Update()
    {
        if (script_for_Events.DialogGoing && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
        {
            Called_DisplayNextReplics(); //Для работы системы разговора нужно нажатие кнопки и работа спец. переменной
        }
        Debug.Log(script_for_Events.DialogGoing);
    }

    

    public static void Call_Cutscene_Dialog(string Path)
    {
        if (script_for_Events.DialogStart)
        {
            Debug.Log("StartDialog");
            pathFor = Path;
            script_for_Events.DialogStart = false;      //Этот метод может вызваться из других скриптов
            script_for_Events.DialogGoing = true;
            script_for_Events.DialogEnd = false;
            Debug.Log(script_for_Events.DialogStart);
            script_for_Events.Cutscenegoing = true;
            NeedName = false;
            FindObjectOfType<MIxed_dialog>().Called_StartDialog(Path);
        }

    }
    public static void Call_Cutscene_Dialog(string Path, string name)
    {
        if (script_for_Events.DialogStart)
        {
            Debug.Log("StartDialog");
            pathFor = Path;
            Namereplic = name;
            script_for_Events.DialogStart = false;     //Этот метод может вызваться из других скриптов
            // В отличии от предыдущего, этот даёт право и конкретное имя в файле преподнести
            script_for_Events.DialogGoing = true;
            script_for_Events.DialogEnd = false;
            Debug.Log(script_for_Events.DialogStart);
            script_for_Events.Cutscenegoing = true;
            NeedName = true;
            FindObjectOfType<MIxed_dialog>().Called_StartDialog(Path);
        }

    }

    public void Called_StartDialog(string Path)
    {
        if(NeedName)
        {
            replics = Dictionary_files.GetLangDictionary(Path, Namereplic); //Запись в массив
        }
        else
        {
            replics = Dictionary_files.GetLangDictionary(Path, false);  //Запись в массив без имени
        }
        pathFor = Path;
        moving.CantMove = true;
        panel.SetActive(true);
        number = 0;
        Called_DisplayNextReplics();
    }

    public void Called_DisplayNextReplics()
    {
        if (number == replics.Length)
        {
            Invoke(nameof(Called_EndDialog), 0.1f);  //Ожидание 0.1 секунды и выполняется последний метод
            return;
        }
        else
        {
            nametext.text = Dictionary_files.GetLangDictionary_GetName(pathFor, replics[number]); //Следующая реплика берётся из пути
            dialogtext.text = replics[number];
            number++;
        }
        /*
        StopAllCoroutines();
        StartCoroutine(Typereplic(replic));*/
    }

    public void Called_EndDialog()
    {
        panel.SetActive(false);
        number = 0;
        moving.CantMove = false;
        script_for_Events.DialogStart = false;      //Обнуление всех переменных
        script_for_Events.DialogGoing = false;
        script_for_Events.Cutscenegoing = false;
        script_for_Events.DialogEnd = true;
    }

    //Zapiski i ih text

    public static void ShowNotesPanel(GameObject Panel, string Path, string NoteName)
    {
        Panel.SetActive(true);
        Panel.GetComponentInChildren<Text>().text = Dictionary_files.GetLangDictionary(Path, NoteName)[0];       //Показ содержимого записок
    }

    public static void HideNotesPanel(GameObject Panel)
    {
        Panel.SetActive(false); //Скрыть записку
    }
}
