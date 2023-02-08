using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_script : MonoBehaviour
{
    public GameObject Inventory_Panel;
    public GameObject Inventory_Pick;
    public GameObject Info_Panel;
    public Text item_name, item_info;
    public moving Mover;
    public string path;
    public float movingInInventory;
    public GameObject ItemName, ItemInfo;
    public GameObject[] Item_places;

    public static bool Inventory_open;

    private int numberOfInventory;

    [System.Obsolete]
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
            if (Inventory_storage.Player_inventory != null)
            {
                for (int i = 0; i < Inventory_storage.Player_inventory.Count; i++)
                {
                    Item_places[i].GetComponent<Image>().sprite = Inventory_storage.Player_inventory[i].Item_Sprite;
                    Item_places[i].SetActive(true);
                }
            }
        }
        else
        {
            Inventory_Panel.SetActive(false);
            for (int i = 0; i < Item_places.Length; i++)
            {
                Item_places[i].SetActive(false);
            }
            Info_Panel.SetActive(false);
            Mover.StartMoving();
            Inventory_Pick.transform.position = new Vector2(Inventory_Panel.transform.position.x - 148, Inventory_Panel.transform.position.y);
            numberOfInventory = 0;
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
                if(Item_places[numberOfInventory].active)
                {
                    Info_Panel.SetActive(true);
                    item_name.text = Inventory_storage.Player_inventory[numberOfInventory].name;
                    item_info.text = Dictionary_files.GetLangDictionary(Inventory_storage.PathInformation, Inventory_storage.Player_inventory[numberOfInventory].name)[0];
                }
                else
                {
                    Info_Panel.SetActive(true);
                    item_info.text = "осярн";
                }
            }
            else
            {
            }
        }
        if(Inventory_open && (Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4")))
        {
            Info_Panel.SetActive(false);
        }
    }
}
