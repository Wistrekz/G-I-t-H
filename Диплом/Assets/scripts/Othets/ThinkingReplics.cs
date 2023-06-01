using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThinkingReplics : MonoBehaviour
{
    public Text dialogtext;
    public GameObject panel;
    public moving Player;

    public float timing = (float)0.05;

    private string[] replics;
    private bool inTrigger;
    private int number;
    private static string pathFor;
    private static string Placereplic = "Non";
    private static bool NeedName;
    void Update()
    {
        if (script_for_Events.ThinkGoing && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
        {
            Called_DisplayNextReplics();      //Для работы системы мыслей нужно нажатие кнопки и работа спец. переменной
        }
        Debug.Log(script_for_Events.ThinkGoing);
    }



    public static void Call_Cutscene_Dialog(string Path)
    {
        if (script_for_Events.ThinkStart)
        {
            Debug.Log("StartDialog");
            pathFor = Path;
            script_for_Events.ThinkStart = false; //Этот метод может вызваться из других скриптов
            script_for_Events.ThinkGoing = true;
            script_for_Events.ThinkEnd = false;
            Debug.Log(script_for_Events.ThinkStart); 
            NeedName = false;
            FindObjectOfType<ThinkingReplics>().Called_StartDialog(Path);
        }

    }
    public static void Call_Cutscene_Dialog(string Path, string Place)
    {
        if (script_for_Events.ThinkStart)
        {
            Debug.Log("StartThink");
            pathFor = Path;
            Placereplic = Place;
            script_for_Events.ThinkStart = false; //Этот метод может вызваться из других скриптов
            // В отличии от предыдущего, этот даёт право и конкретное имя в файле преподнести
            script_for_Events.ThinkGoing = true;
            script_for_Events.ThinkEnd = false;
            NeedName = true;
            FindObjectOfType<ThinkingReplics>().Called_StartDialog(Path);
        }

    }

    public void Called_StartDialog(string Path)
    {
        if (NeedName) //Нужно имя?
        {
            Debug.Log(Path +" "+ Placereplic);
            replics = Dictionary_files.GetLangDictionary(Path, Placereplic); //Запись в массив
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
            Invoke(nameof(Called_EndDialog), 0.1f); //Ожидание 0.1 секунды и выполняется последний метод
            return;
        }
        else
        {
            dialogtext.text = replics[number];
            script_for_Events.ThinkReplicNumber = number;
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
        script_for_Events.ThinkGoing = false; //Обнуление всех переменных
        script_for_Events.ThinkStart = false;
        script_for_Events.Cutscenegoing = false;
        script_for_Events.ThinkEnd = true;
        Debug.Log(script_for_Events.ThinkEnd);
    }
    /*public IEnumerator SmoothText(string[] replics,int number, float timing)
    {
        string replic = replics[number]; //Следующая реплика

        for(int i = 0; i < replic.Length; i++)
        {
            dialogtext.text += replic[i];
            if(Input.GetButtonDown("Fire2"))
            {
                dialogtext.text = replic;
                break;
            }
            yield return new WaitForSeconds(timing);
        }
        
    }*/
}
