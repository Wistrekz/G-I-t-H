using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_script : MonoBehaviour
{
    public GameObject Inventory_Panel;
    public GameObject Inventory_Pick;
    public GameObject Info_Panel;
    public string path;

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
            Inventory_Panel.SetActive(true);
            Inventory_Pick.SetActive(true);
        }
        else
        {
            Inventory_Panel.SetActive(false);
        }
    }
}
