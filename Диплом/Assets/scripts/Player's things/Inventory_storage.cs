using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_storage : MonoBehaviour
{
    public int count_Items;
    public string pathToInfo;

    public static string PathInformation;

    public static List<Inventory_Storage> Player_inventory;

    [System.Serializable]
    public struct Inventory_Storage
    {
        public string name;
        public Sprite Item_Sprite;
    }
    public List<Inventory_Storage> Items_Storage;
    public static List<Inventory_Storage> _Inventory_Storage;

    void Start()
    {
        _Inventory_Storage = Items_Storage;
        PathInformation = Dictionary_files.Mark_Reader(pathToInfo);
    }


}
