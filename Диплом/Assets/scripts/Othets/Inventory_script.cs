using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_script : MonoBehaviour
{
    public GameObject Inventory_Panel, Inventory_sprites; // Панель и спрайты инвентаря
    public GameObject Inventory_Pick; // Префаб перетаскиваемого элемента
    public GameObject Info_Panel; // Панель для отображения информации о предметах
    public Text item_name, item_info; // Текстовые поля для отображения имени и описания предметов
    public float movingInInventory; // Дистанция между элементами на панели инвентаря
    public GameObject[] Item_places; // Массив для хранения мест на панели инвентаря

    public static bool Inventory_open; // Флаг, указывающий, открыт ли инвентарь

    private int numberOfInventory; // Индекс текущего отображаемого элемента панели инвентаря
    private bool InfoOpen; // Флаг, указывающий, открыта ли информационная панель
    private bool InventWasOpen; // Флаг, указывающий, был ли инвентарь открыт

    [System.Obsolete]
    private void Update()
    {
        // Открытие и закрытие инвентаря по кнопкам Fire3 или Fire4
        if (Input.GetButtonDown("Fire3") || Input.GetButton("Fire4"))
        {
            if (!script_for_Events.Cutscenegoing)
                Inventory_open = !Inventory_open; // Инвертирование флага открытия инвентаря
        }

        if (Inventory_open)
        {
            Inventory_Panel.SetActive(true); // Отображение панели инвентаря
            Inventory_sprites.SetActive(true); // Отображение спрайтов на панели инвентаря
            InventWasOpen = true;

            // Перебор элементов на панели инвентаря и отображение их спрайтов
            if (Inventory_storage.Player_inventory != null)
            {
                for (int i = 0; i < Inventory_storage.Player_inventory.Count; i++)
                {
                    Item_places[i].GetComponent<Image>().sprite = Inventory_storage.Player_inventory[i].Item_Sprite;
                    Item_places[i].SetActive(true);
                }
            }

            // Отображение перетаскиваемого элемента и установка его позиции на текущий элемент панели
            Inventory_Pick.SetActive(true);
            Inventory_Pick.transform.position = Item_places[numberOfInventory].transform.position;

            // Если открыта информационная панель, то отображается информация о предмете
            if (InfoOpen)
            {
                if (Inventory_storage.Player_inventory != null)
                {
                    if (Item_places[numberOfInventory].activeSelf)
                    {
                        Info_Panel.SetActive(true);
                        item_name.text = Inventory_storage.Player_inventory[numberOfInventory].name;
                        item_info.text = Dictionary_files.GetLangDictionary(Inventory_storage.PathInformation, Inventory_storage.Player_inventory[numberOfInventory].name)[0];
                    }
                    else // Если текущий элемент панели скрыт, то отображается "Пусто"
                    {
                        Info_Panel.SetActive(true);
                        item_name.text = "";
                        item_info.text = "Пусто";
                    }
                }
                else // Если инвентарь пуст, то отображается "Пусто"
                {
                    Info_Panel.SetActive(true);
                    item_name.text = "";
                    item_info.text = "Пусто";
                }
            }

            // Перелистывание элементов на панели инвентаря
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (numberOfInventory > 0)
                {
                    Item_places[numberOfInventory].SetActive(false);
                    numberOfInventory--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (numberOfInventory < Item_places.Length - 1)
                {
                    numberOfInventory++;
                    Item_places[numberOfInventory].SetActive(true);
                }
            }
        }
        else
        {
            Inventory_Panel.SetActive(false); // Скрываем панель инвентаря
            Info_Panel.SetActive(false); // Скрываем информационную панель

            // Скрываем перетаскиваемый элемент и устанавливаем его позицию за пределами экрана
            Inventory_Pick.SetActive(false);
            Inventory_Pick.transform.position = new Vector2(-1000, -1000);

            // Убираем выбор текущего элемента на панели инвентаря
            numberOfInventory = 0;
        }
        /*else // Если инвентарь закрыт, то скрываем его элементы и перетаскиваемый элемент
        {
            Inventory_Panel.SetActive(false);
            for (int i = 0; i < Item_places.Length; i++)
            {
                Item_places[i].SetActive(false);
            }
            Inventory_sprites.SetActive(false);
            Info_Panel.SetActive(false);
            Inventory_Pick.transform.position = new Vector2(Inventory_Panel.transform.position.x - 148, Inventory_Panel.transform.position.y);
            numberOfInventory = 0;
        }*/

        // Если открыта информационная панель и нажат Enter, то закрываем или отображаем информацию о предмете
        if (Inventory_open && Input.GetKeyDown(KeyCode.Return))
        {
            InfoOpen = !InfoOpen;
            if (!InfoOpen)
            {
                Info_Panel.SetActive(false);
            }
        }

        // Если открыта информационная панель и нажата кнопка Fire3 или Fire4, то закрываем информационную панель
        if (Inventory_open && (Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4")))
        {
            Info_Panel.SetActive(false);
        }
    }
}