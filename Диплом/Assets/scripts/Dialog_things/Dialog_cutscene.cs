using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_cutscene : MonoBehaviour
{
    public Text dialogtext;
    public GameObject panel;
    public Text nametext;
    public string path, path_artists_info;

    public Animator animator;

    private string[] replics;
    private int number;
    private int rep_num;
    private string[] replic_name;

    public void Start()
    {
        replics = Dictionary_files.GetLangDictionary(path);
    }




    public void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            DisplayNextReplics();
            Debug.Log("f");
        }
    }

    public void StartDialog()
    {
        replic_name = replics[rep_num].Split(new string[] { Artists_marks.Namemark_Symbol}, StringSplitOptions.None);
        panel.SetActive(true);
        nametext.text = replic_name[0];

        number = 0;
        rep_num = 0;
    }

    public void DisplayNextReplics()
    {
        Debug.Log("q");
        replic_name = replics[rep_num].Split(new string[] { Artists_marks.Namemark_Symbol }, StringSplitOptions.None);
        rep_num++;
        Debug.Log("r");
        if (number == replics.Length - 1)
        {
            Debug.Log("preend");
            Invoke(nameof(EndDialog), 0.1f);
            number = 0;
            return;
        }
        else
        {
            Debug.Log("y");
            StringReader O = new StringReader(path_artists_info);
            string str = O.ReadToEnd();
            O.Close();
            Debug.Log("y");
            string[] krak = str.Split(new char[2] {'-','\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] Names = new string[krak.Length/2];
            string[] cols = new string[krak.Length/2];
            for(int r = 0; r < krak.Length; r++)
            {
                
                if(r != Names.Length)
                {
                    if (r % 2 == 0)
                        Names[r] = krak[r];
                }
            }
            Debug.Log("yw");
            for (int i = 0; i < krak.Length; i++)
            {
                if (i % 2 != 0)
                    cols[i] = krak[i];
            }
            UnityEngine.Color[] colors = new Color[cols.Length];
            for(int r1 = 0; r1 < colors.Length; r1++)
            {
                ColorUtility.TryParseHtmlString(cols[r1], out colors[r1]);
            }
            for(int y = 0; y < cols.Length; y++)
            {
                if(Dictionary_files.GetLangDictionary_FromNameToColor(path_artists_info, nametext.text) == cols[y])
                {
                    nametext.color = colors[y];
                    dialogtext.text = replic_name[1];
                    dialogtext.color = colors[y];
                    Debug.Log("zf");
                    Debug.Log(colors[y]);
                    number++;
                    break;
                }
            }
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
        rep_num = 0;
        animator.SetBool("IsTextEnd", true);
        Debug.Log("end");
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
