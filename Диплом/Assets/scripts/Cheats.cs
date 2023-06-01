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
        if(ConsoleActivate)
        {
            
        }
        if(!ConsoleActivate)
        {

        }
    }

    public static void Inventory_Add(string Item)
    {
        bool daef = false;
        for(int i = 0; i < Inventory_storage._Inventory_Storage.Length; i++)
        {
            if (Inventory_storage._Inventory_Storage[i].Object != null && Inventory_storage._Inventory_Storage[i].name.Contains(Item.Remove(Item.Length - 1)))
            {
                Inventory_storage.Player_inventory.Add(Inventory_storage._Inventory_Storage[i]);
                daef = true;
                Debug.Log(Item + " добавлен");
            }
        }
        if(!daef)
        {
            Debug.Log("Takoi veshi net v hranilishe");
        }

    }

    public static void Inventory_Delete(string Item)
    {
        for (int i = 0; i < Inventory_storage.Player_inventory.Count; i++)
        {
            if (Inventory_storage.Player_inventory[i].Object != null && Inventory_storage.Player_inventory[i].name.Contains(Item.Remove(Item.Length - 1)))
            {
                Inventory_storage.Player_inventory.RemoveAt(i);
            }
        }

    }

    public static bool CheckInventoryOnThisItem(string Item)
    {
        bool result =false;

        for (int i = 0; i < Inventory_storage.Player_inventory.Count; i++)
        {
            Debug.Log(Item.Remove(Item.Length - 1));
            Debug.Log((Inventory_storage.Player_inventory[i].Object != null) + " " + Inventory_storage.Player_inventory[i].name.Contains(Item.Remove(Item.Length - 1)));
            if (Inventory_storage.Player_inventory[i].Object != null && Inventory_storage.Player_inventory[i].name.Contains(Item.Remove(Item.Length - 1)))
            {
                result = true;
            }
        }
        return result;
    }

    public static string WRITEInventory()
    {
        string log = "";
        for(int i = 0; i < Inventory_storage.Player_inventory.Count; i++)
        {
            log += " " + Inventory_storage.Player_inventory[i].name;
        }
        return log;
    }
}
