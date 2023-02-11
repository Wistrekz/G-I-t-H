using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog_cutscene : MonoBehaviour
{
    public Text dialogtext;
    public GameObject panel;
    public Text nametext;
    public string path, path_artists_info;

    public Animator animator;

    private string[] replics;
    private int rep_num;
    private string[] replic_name;

    private UnityEngine.Color char_color;




    public void Update()
    {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                DisplayNextReplics();
            }
    }

    public void StartDialog()
    {
        path = Dictionary_files.Mark_Reader(path);
        replics = Dictionary_files.GetLangDictionary(path, true);
        panel.SetActive(true);
    }

    public void DisplayNextReplics()
    {
        if (rep_num == replics.Length)
        {
            Invoke(nameof(EndDialog), 0.1f);
            rep_num = 0;
            return;
        }
        else
        {
            replic_name = replics[rep_num].Split(new string[1] { Artists_marks.Namemark_Symbol }, StringSplitOptions.None);
            ColorUtility.TryParseHtmlString(Dictionary_files.GetLangDictionary_FromNameToColor(path_artists_info, replic_name[0]), out char_color);
            nametext.text = replic_name[0];
            nametext.color = char_color;
            dialogtext.text = replic_name[1];
            dialogtext.color = char_color;
            rep_num++;
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
        rep_num = 0;
        animator.SetBool("IsTextEnd", true);
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
