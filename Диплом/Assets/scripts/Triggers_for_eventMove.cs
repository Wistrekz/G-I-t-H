using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers_for_eventMove : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In Fucking Trigger");
        if (script_for_Events.Trigger_for_SpecWatcher != null)
        {
            Debug.Log(script_for_Events.Trigger_for_SpecWatcher.name);
            Debug.Log(gameObject.name);
            if (collision.gameObject.name == "Hans" && script_for_Events.Trigger_for_SpecWatcher == gameObject)
            {
                script_for_Events.Special_Watcher = true;
                Debug.Log("Got It");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (script_for_Events.Trigger_for_SpecWatcher != null)
        {
            if (collision.gameObject.name == "Hans" && script_for_Events.Trigger_for_SpecWatcher == gameObject)
            {
                script_for_Events.Special_Watcher = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(script_for_Events.Trigger_for_Enter_SpecWatcher != null && collision.gameObject.name == "Hans" && script_for_Events.Trigger_for_Enter_SpecWatcher == gameObject && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
        {
            script_for_Events.Special_Enter_Watcher = true;
        }
        if(script_for_Events.Trigger_for_SpecWatcher != null)
        {
            Debug.Log(script_for_Events.Trigger_for_SpecWatcher);
        }
    }
}
