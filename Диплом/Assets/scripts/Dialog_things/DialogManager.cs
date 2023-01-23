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

    public void Start()
    {
        replics = Dictionary_files.GetLangDictionary(path, gameObject.name);
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
        panel.SetActive(true);
        nametext.text = gameObject.name;
        number = 0;
        inTrigger = true;
        inscript = true;
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
