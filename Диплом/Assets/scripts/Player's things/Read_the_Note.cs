using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read_the_Note : MonoBehaviour
{

    public string NoteMessage_Path;
    public string NoteMessage_Replic;

    public GameObject NotesPanel;

    private int count;
    private bool hestart, HeReadnote;

    private bool StartScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartScript = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartScript = false;
    }

    private void Update()
    {
        Debug.Log(StartScript);
        if (StartScript)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                Debug.Log("&&&&&");
                hestart = !hestart;
                if(hestart)
                {
                    Debug.Log("Show");
                    MIxed_dialog.ShowNotesPanel(NotesPanel, NoteMessage_Path, NoteMessage_Replic);
                    moving.CantMove = true;
                    return;
                }
                else
                {
                    Debug.Log("Hide");
                    MIxed_dialog.HideNotesPanel(NotesPanel);
                    moving.CantMove = false;
                    if(!HeReadnote)
                    {
                        script_for_Events.ReadsEventNote = true;
                        HeReadnote = true;
                    }
                    //targetmenu.Shownextmission();
                    count--;
                }
            }
        }
    }
}
