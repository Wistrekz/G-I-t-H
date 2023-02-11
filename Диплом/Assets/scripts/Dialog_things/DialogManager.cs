using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;

public class DialogManager : MonoBehaviour
{

    public Text dialogtext;
    public GameObject panel;
    public bool inscript;
    public Text nametext;
    public string path, lang_mark;

    private string[] replics;
    private bool inTrigger;
    private int number;




    public void Update()
    {
        if (inTrigger && inscript && !script_for_Events.Cutscenegoing)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                DisplayNextReplics();
                foreach(string f in replics)
                {
                    Debug.Log(f);
                }
            }
        }
        if(script_for_Events.Cutscenegoing)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                Called_DisplayNextReplics();
                foreach (string f in replics)
                {
                    Debug.Log(f);
                }
            }
        }
    }

    public void StartDialog()
    {
        replics = Dictionary_files.GetLangDictionary(path, gameObject.name);
        
        panel.SetActive(true);
        nametext.text = gameObject.name;
        number = 0;
        inTrigger = true;
        inscript = true;
        DisplayNextReplics();
        Debug.Log($"{inTrigger}, {inscript}");
    }

    public void DisplayNextReplics()
    {
        if (number == replics.Length)
        {
            Invoke(nameof(EndDialog), 0.1f);
            return;
        }
        else
        {
            string replic = replics[number];
            dialogtext.text = replic;
            number++;
        }
        /*
        StopAllCoroutines();
        StartCoroutine(Typereplic(replic));*/
    }
    /*
    IEnumerator Typereplic(string replic)
    {
        dialogtext.text = "";
        foreach (char letter in replic.ToCharArray())
        {
            dialogtext.text += letter;
            yield return null;
        }
        StopCoroutine(Typereplic(replic));
    }*/
    public void EndDialog()
    {
        panel.SetActive(false);
        FindObjectOfType<moving>().StartMoving();
        inTrigger = false;
        inscript = false;
        number = 0;
        Debug.Log($"{inTrigger}, {inscript}");
    }

   /* 



    Разделитель типов диалогов




    */


    public static void Call_Cutscene_Dialog(string Path)
    {
        if(script_for_Events.DialogStart)
        {
            FindObjectOfType<DialogManager>().Called_StartDialog(Path);
            script_for_Events.Cutscenegoing = true;
            script_for_Events.DialogStart = false;
        }
        
    }

    public void Called_StartDialog(string Path)
    {
        Debug.Log("adefweruih");
        replics = Dictionary_files.GetLangDictionary(Path, false);
        string replic_name = Dictionary_files.GetLangDictionary_GetName(path, replics[0]);
        FindObjectOfType<moving>().StopMoving();
        panel.SetActive(true);
        nametext.text = replic_name;
        number = 0;
        Called_DisplayNextReplics();
        Debug.Log($"{inTrigger}, {inscript}");
    }

    public void Called_DisplayNextReplics()
    {
        if (number == replics.Length)
        {
            Invoke(nameof(Called_EndDialog), 0.1f);
            return;
        }
        else
        {
            string replic = replics[number];
            dialogtext.text = replic;
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
        if(script_for_Events.Special_watcher)
        {
            script_for_Events.Cutscenegoing = false;
        }
        script_for_Events.DialogEnd = true;
        Debug.Log($"{inTrigger}, {inscript}");
    }
    /*
    public void Start()
    {
        replics = new Queue<string>();
    }


    [Obsolete]

    public void Update()
    {
        if(inTrigger)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                DisplayNextReplics();
            }
        }
    }

    public void StartDialog(Dialog dialog)
    {
        panel.SetActive(true);
        nametext.text = dialog.name;
        replics.Clear();

        foreach(string replic in dialog.replics)
        {
            replics.Enqueue(replic);
        }
    }

    public void DisplayNextReplics()
    {
        if (replics.Count == 0)
        {
            EndDialog();
            return;
        }
        string replic = replics.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Typereplic(replic));
    }
    IEnumerator Typereplic(string replic)
    {
        dialogtext.text = "";
        foreach(char letter in replic.ToCharArray())
        {
            dialogtext.text += letter;
            yield return null;
        }
        StopCoroutine(Typereplic(replic));
    }
    public void EndDialog()
    {
        panel.SetActive(false);
        FindObjectOfType<moving>().StartMoving();
        inTrigger = false;
    }
    */
}
