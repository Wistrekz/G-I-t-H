using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public string codeKeys;
    public GameObject cheats_menu;

    private bool ConsoleActivate;
    public static void Console(bool value)
    {
        
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cheats_button1") && Input.GetButtonDown("Cheats_button2"))
        {
            ConsoleActivate = !ConsoleActivate;
        }
        Debug.Log(ConsoleActivate);
        if(ConsoleActivate)
        {
            Inventory_Add("Ключ");
            Debug.Log("bruh");
            ConsoleActivate = false;
        }
        if(!ConsoleActivate)
        {

        }
    }

    public static void Inventory_Add(string Item)
    {
        for(int i = 0; i < Inventory_storage._Inventory_Storage.Length; i++)
        {
            if (Inventory_storage._Inventory_Storage[i].name == Item)
            {
                Inventory_storage.Player_inventory.Add(Inventory_storage._Inventory_Storage[i]);
                Debug.Log(Inventory_storage._Inventory_Storage[i].name);
                Debug.Log(Inventory_storage._Inventory_Storage[i].Item_Sprite);
            }
        }
        
    }


}
