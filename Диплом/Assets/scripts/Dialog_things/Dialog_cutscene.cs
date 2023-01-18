using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_cutscene : MonoBehaviour
{
    public Text dialogtext;
    public GameObject panel;
    public bool inscript;
    public Text nametext;
    public string path, lang_mark;
    public string[] players_scene;

    private string[] replics;
    private bool inTrigger;
    private int number;
    private int rep_num;
    private string[] replic_name;

    public void Start()
    {
        Debug.Log(gameObject.name);
        replics = Dictionary_files.GetLangDictionary_players_color(path);
    }




    public void Update()
    {
        if (inTrigger && inscript)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                DisplayNextReplics();
            }
        }
    }

    public void StartDialog()
    {
        replic_name = replics[rep_num].Split(new string[] { Artists_marks.Namemark_Symbol}, StringSplitOptions.None);
        panel.SetActive(true);
        nametext.text = replic_name[0];
        number = 0;
        inTrigger = true;
        inscript = true;
        rep_num++;
    }

    public void DisplayNextReplics()
    {
        if (number == replics.Length)
        {
            Invoke(nameof(EndDialog), 0.1f);
            number = 0;
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
        rep_num = 0;
    }

    /*

    

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
