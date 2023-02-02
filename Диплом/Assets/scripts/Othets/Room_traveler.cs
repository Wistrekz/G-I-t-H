using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_traveler : MonoBehaviour
{
    

    public enum direction
    {
        left = 0,
        right = 1,
        Up = 2,
        Down = 3
    }
    [Header("Def_sets")]
    public GameObject Player;
    public GameObject Triggers_Parent;
    public direction dir;
    public float PercentOfTeleportation;
    public bool Isdoor;
    [Header("Ouside_sets")]
    public bool DoorOutside;
    public string scene_name;
    [Header("Inside_sets")]
    public int Block_numAdress;
    public bool IsOneHouse;

    public static direction direct;
    public static float PercentOfTeleport;
    public static bool IsTeleported_Outside;

    private bool intrigger;
    private bool SceneLoaded;
    private Vector2[] Teleport_Blocks_mas;

    private void Calc_rooms()
    {
        Teleport_Blocks_mas = new Vector2[Triggers_Parent.transform.childCount];
        for (int i = 0; i < Triggers_Parent.transform.childCount; i++)
            Teleport_Blocks_mas[i] = Triggers_Parent.transform.GetChild(i).transform.position;
    }

    private void To_Teleport_Distance_Inside()
    {
        switch (dir)
        {
            case direction.left:
                Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation), Player.transform.position.y);
                Debug.Log(Player.transform.position);
                break;
            case direction.right:
                Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation), Player.transform.position.y);
                Debug.Log(Player.transform.position);
                break;
            case direction.Up:
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation));
                Debug.Log(Player.transform.position);
                break;
            case direction.Down:
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation));
                Debug.Log(Player.transform.position);
                break;

        }
    }

    private void To_Teleport_Distance(direction directon, float PercentOfTeleportik)
    {
        switch (directon)
        {
            case direction.left:
                Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportik), Player.transform.position.y);
                Debug.Log(Player.transform.position);
                break;
            case direction.right:
                Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportik), Player.transform.position.y);
                Debug.Log(Player.transform.position);
                break;
            case direction.Up:
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportik));
                Debug.Log(Player.transform.position);
                break;
            case direction.Down:
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportik));
                Debug.Log(Player.transform.position);
                break;

        }
    }

    private void InsideMemoring_and_Teleportation()
    {
        if (Isdoor)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                Calc_rooms();
                for (int i = 0; i < Teleport_Blocks_mas.Length; i++)
                {
                    Debug.Log(Teleport_Blocks_mas[i]);
                    if (i == Block_numAdress)
                    {
                        Player.transform.position = Teleport_Blocks_mas[i];
                        To_Teleport_Distance_Inside();
                    }
                }
            }
        }
        else
        {
            Calc_rooms();
            for (int i = 0; i < Teleport_Blocks_mas.Length; i++)
            {
                if (i == Block_numAdress)
                {
                    Player.transform.position = Teleport_Blocks_mas[i];
                    To_Teleport_Distance_Inside();
                }
            }
        }
    }

    private void OutsideMemoring_and_Teleportation()
    {
        if (Isdoor)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                if(DoorOutside)
                {
                    Debug.Log("q2134");
                    IsTeleported_Outside = true;
                    Set_static_sets();
                    SceneManager.LoadScene(scene_name);
                    Debug.Log(Artists_marks.Player_coordinates);
                    Debug.Log(direct + $" {PercentOfTeleport}");
                    
                }
                else
                {
                    Artists_marks.Player_coordinates = Player.transform.position;
                    Set_static_sets();
                    SceneManager.LoadScene(scene_name);
                    Debug.Log(Player.transform.position);
                    Debug.Log(Artists_marks.Player_coordinates);
                    Debug.Log(direct + $" {PercentOfTeleport}");
                }
                
            }
        }
        else
        {
            if (DoorOutside)
            {
                SceneManager.LoadScene(scene_name);
                Player.transform.position = Artists_marks.Player_coordinates;
            }
            else
            {
                Artists_marks.Player_coordinates = Player.transform.position;
                SceneManager.LoadScene(scene_name);
            }
            To_Teleport_Distance(direct, PercentOfTeleport);
        }
    }

    private void Set_static_sets()
    {
        direct = dir;
        PercentOfTeleport = PercentOfTeleportation;
    }

    private void Start()
    {
        SceneLoaded = true;
    }

    public void Update()
    {
        if (IsTeleported_Outside && SceneLoaded)
        {
            Debug.Log("3423y78f");
            Player.transform.position = Artists_marks.Player_coordinates;
            Debug.Log(Player.transform.position);
            To_Teleport_Distance(direct, PercentOfTeleport);
            IsTeleported_Outside = false;
        }
        if (intrigger)
        {
            Debug.Log(IsTeleported_Outside);
            Debug.Log("sdfgg");
            if (IsOneHouse)
            {
                InsideMemoring_and_Teleportation();
            }
            else
            {
                OutsideMemoring_and_Teleportation();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hans")
        {
            intrigger = true;
        }
        else
        {
            intrigger = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        intrigger = false;
    }
}
