using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_storage : MonoBehaviour
{
    public string pathToInfo;

    public static string PathInformation;

    public static List<Inventory_Storage> Player_inventory = new List<Inventory_Storage>();

    [System.Serializable]
    public struct Inventory_Storage
    {
        public GameObject Object;
        public string name;
        public Sprite Item_Sprite;
    }
    public Inventory_Storage[] Items_Storage;
    public static Inventory_Storage[] _Inventory_Storage;



    void Start()
    {
        _Inventory_Storage = Items_Storage;
        PathInformation = Dictionary_files.Mark_Reader(pathToInfo);
    }


}
