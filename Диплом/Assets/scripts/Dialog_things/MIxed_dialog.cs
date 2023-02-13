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
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            Called_DisplayNextReplics();
        }
    }

    public static void Call_Cutscene_Dialog(string Path)
    {
        if (script_for_Events.DialogStart)
        {
            pathFor = Path;
            FindObjectOfType<MIxed_dialog>().Called_StartDialog(Path);
            script_for_Events.Cutscenegoing = true;
            script_for_Events.DialogStart = false;
        }

    }

    public void Called_StartDialog(string Path)
    {
        replics = Dictionary_files.GetLangDictionary(Path, false);
        moving.CantMove = true;
        panel.SetActive(true);
        number = 0;
        Called_DisplayNextReplics();
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
            string replic_name = Dictionary_files.GetLangDictionary_GetName(pathFor, replics[number]);
            nametext.text = replic_name;
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
        moving.CantMove = false;
        Debug.Log(moving.CantMove);
        if (script_for_Events.Special_watcher)
        {
            script_for_Events.Cutscenegoing = false;
        }
        script_for_Events.DialogEnd = true;
    }
}
