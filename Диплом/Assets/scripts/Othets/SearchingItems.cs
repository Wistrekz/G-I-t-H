using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingItems : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private string NameOfInfo;

    private string Path_ToReplics;

    private void Start()
    {
        Path_ToReplics = Dictionary_files.Mark_Reader("Assets/Languages_/ru/Static/ru_static.xml");
        Debug.Log(Path_ToReplics);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == Player.name)
        {
            if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                ThinkingReplics.Call_Cutscene_Dialog(Path_ToReplics, NameOfInfo);
                if (script_for_Events.ThinkEnd)
                {
                    script_for_Events.ThinkEnd = false;
                }
            }
        }
    }
}
