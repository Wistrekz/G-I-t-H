using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_script : MonoBehaviour
{
    public GameObject Panel;

    public static bool Inventory_open;

    private void Update()
    {
        if(Input.GetButton("Fire3") || Input.GetButton("Fire4"))
        {
            if(!script_for_Events.Cutscenegoing)
                Inventory_open = true;
        }
        if(Inventory_open)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }
}
