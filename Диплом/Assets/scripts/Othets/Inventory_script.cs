using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_script : MonoBehaviour
{
    public GameObject Inventory_Panel;
    public GameObject Inventory_Pick;
    public GameObject Info_Panel;
    public moving Mover;
    public string path;
    public float movingInInventory;
    public GameObject ItemName, ItemInfo;
    public GameObject[] Item_places;

    public static bool Inventory_open;

    private int numberOfInventory;

    private void Update()
    {
        if(Input.GetButtonDown("Fire3") || Input.GetButton("Fire4"))
        {
            if(!script_for_Events.Cutscenegoing)
                Inventory_open = !Inventory_open;
        }
        if(Inventory_open)
        {
            Inventory_Panel.SetActive(true);
            Inventory_Pick.SetActive(true);
            Mover.StopMoving();
            for(int i = 0; i < Inventory_storage.Player_inventory.Length; i++)
            {

            }
        }
        else
        {
            Inventory_Panel.SetActive(false);
            Mover.StartMoving();
        }
        if (Input.GetButton("Left") || Input.GetButton("Right"))
        {
            if(Input.GetButtonDown("Left"))
            {
                if(numberOfInventory > 0)
                {
                    Inventory_Pick.transform.position = new Vector2(Inventory_Pick.transform.position.x - movingInInventory, Inventory_Pick.transform.position.y);
                    numberOfInventory--;
                }
            }
            if(Input.GetButtonDown("Right"))
            {
                if(numberOfInventory < 5)
                {
                    Inventory_Pick.transform.position = new Vector2(Inventory_Pick.transform.position.x + movingInInventory, Inventory_Pick.transform.position.y);
                    numberOfInventory++;
                }
            }
        }
        if(Inventory_open && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
        {
            if(Inventory_storage.Player_inventory != null)
            {
                for (int i = 0; i < ; i++)
                {
                    
                }
            }
            else
            {

            }
        }
    }
}
