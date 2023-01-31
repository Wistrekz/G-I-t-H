using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_traveler : MonoBehaviour
{
    public GameObject Player;
    public GameObject Triggers_Parent;


    public enum direction
    {
        left = 0,
        right = 1,
        Up = 2,
        Down = 3
    }
    public direction dir;
    [Header("Def_sets")]
    public bool Isdoor;
    public bool IsOneHouse;
    public string scene_name;
    public int Block_numAdress;
    public float PercentOfTeleportation;

    private bool intrigger;
    private Vector2[] Teleport_Blocks_mas;

    private void Calc_rooms()
    {
        Teleport_Blocks_mas = new Vector2[Triggers_Parent.transform.childCount];
        for (int i = 0; i < Triggers_Parent.transform.childCount; i++)
            Teleport_Blocks_mas[i] = Triggers_Parent.transform.GetChild(i).transform.position;
    }

    public void Update()
    {
        if(intrigger)
        {
            Debug.Log("sdfgg");
            if (IsOneHouse)
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
                                switch (dir)
                                {
                                    case direction.left:
                                        Player.transform.position = new Vector2(Player.transform.position.x - PercentOfTeleportation, Player.transform.position.y);
                                        break;
                                    case direction.right:
                                        Player.transform.position = new Vector2(Player.transform.position.x + PercentOfTeleportation, Player.transform.position.y);
                                        break;
                                    case direction.Up:
                                        Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + PercentOfTeleportation);
                                        break;
                                    case direction.Down:
                                        Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - PercentOfTeleportation);
                                        break;

                                }
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
                            switch (dir)
                            {
                                case direction.left:
                                    Player.transform.position = new Vector2(Player.transform.position.x - PercentOfTeleportation, Player.transform.position.y);
                                    break;
                                case direction.right:
                                    Player.transform.position = new Vector2(Player.transform.position.x + PercentOfTeleportation, Player.transform.position.y);
                                    break;
                                case direction.Up:
                                    Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + PercentOfTeleportation);
                                    break;
                                case direction.Down:
                                    Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - PercentOfTeleportation);
                                    break;

                            }
                        }
                    }
                }
                
            }
            else
            {
                if (Isdoor)
                {
                    if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                    {

                        Artists_marks.Player_coordinates = Player.transform.position;
                        SceneManager.LoadScene(scene_name);
                        switch (dir)
                        {
                            case direction.left:
                                Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation), Player.transform.position.y);
                                break;
                            case direction.right:
                                Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation), Player.transform.position.y);
                                break;
                            case direction.Up:
                                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation));
                                break;
                            case direction.Down:
                                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation));
                                break;

                        }
                    }
                }
                else
                {
                    Artists_marks.Player_coordinates = Player.transform.position;
                    SceneManager.LoadScene(scene_name);
                    switch (dir)
                    {
                        case direction.left:
                            Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation), Player.transform.position.y);
                            break;
                        case direction.right:
                            Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation), Player.transform.position.y);
                            break;
                        case direction.Up:
                            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation));
                            break;
                        case direction.Down:
                            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * PercentOfTeleportation));
                            break;

                    }
                }
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
