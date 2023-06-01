using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingProgress : MonoBehaviour
{
    public GameObject SavePanel;


    private bool ActivateScript;

    public static bool SavingSucsess;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Hans" && (Input.GetButton("Fire1") || Input.GetButton("Fire2")))
        {
            ActivateScript = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Hans")
        {

        }
    }

    private void Update()
    {
        if(ActivateScript)
        {
            
        }
    }
}
