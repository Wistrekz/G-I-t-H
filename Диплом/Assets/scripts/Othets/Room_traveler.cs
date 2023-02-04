using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_traveler : MonoBehaviour
{
    public static bool IGotoRoom;
    public static bool TravelToLocation;

    public enum direction
    {
        left = 0,
        right = 1,
        Up = 2,
        Down = 3
    }
    [Header("Def_sets")]
    public GameObject Player;
    public GameObject Location_sprite;
    public static GameObject stat_Location_sprite;
    public direction dir;
    public float Player_PercentOfTeleportation;
    public bool Isdoor;
    [Header("Ouside_sets")]
    public GameObject Teleport_subject;
    public bool OnTheStreets;

    private bool intrigger;

    private void To_Teleport_Distance_Inside()
    {
        switch (dir)
        {
            case direction.left:
                Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                Debug.Log(Player.transform.position);
                break;
            case direction.right:
                Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                Debug.Log(Player.transform.position);
                break;
            case direction.Up:
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                Debug.Log(Player.transform.position);
                break;
            case direction.Down:
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                Debug.Log(Player.transform.position);
                break;

        }
    }

    private void Teleportation()
    {
        if(OnTheStreets)
        {
            if (Isdoor)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                {
                    TravelToLocation = true;
                    Player.transform.position = Teleport_subject.transform.position;
                    To_Teleport_Distance_Inside();
                }
            }
            else
            {
                TravelToLocation = true;
                Player.transform.position = Teleport_subject.transform.position;
                To_Teleport_Distance_Inside();
            }
        }
        else
        {
            if (Isdoor)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                {
                    IGotoRoom = true;
                    Player.transform.position = Teleport_subject.transform.position;
                    To_Teleport_Distance_Inside();
                }
            }
            else
            {
                IGotoRoom = false;
                Player.transform.position = Teleport_subject.transform.position;
                To_Teleport_Distance_Inside();

            }
        }
    }

    void Start()
    {
        if(OnTheStreets)
        {
            stat_Location_sprite = Location_sprite;
        }
    }

    public void Update()
    {
        if (intrigger)
        {
            Debug.Log("sdfgg");
            Teleportation();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hans")
        {
            intrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hans")
        {
            intrigger = false;
        }
    }
}
