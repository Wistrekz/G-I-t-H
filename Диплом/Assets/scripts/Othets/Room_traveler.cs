using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_traveler : MonoBehaviour
{
    public Animator BlackScreen;

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
    private bool Teleport_activated;

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
                    Debug.Log("setyui11111");
                    BlackScreen.SetInteger("ScreenState", 2);
                    Teleport_activated = true;
                }
            }
            else
            {
                Debug.Log("setyui11111");
                BlackScreen.SetInteger("ScreenState", 2);
                Debug.Log(BlackScreen.GetInteger("ScreenState"));
                Teleport_activated = true;
            }
        }
        else
        {
            if (Isdoor)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                {
                    Debug.Log("setyui11111");
                    BlackScreen.SetInteger("ScreenState", 2);
                    Teleport_activated = true;
                }
            }
            else
            {
                Debug.Log("setyui11111");
                BlackScreen.SetInteger("ScreenState", 2);
                Teleport_activated = true;
            }
        }


        if(Teleport_activated)
        {
            TeleportInBlack();
        }

    }

    public void TeleportInBlack()
    {
        Debug.Log(script_for_Events.blackscreen && OnTheStreets);
        if(script_for_Events.blackscreen && OnTheStreets)
        {
            TravelToLocation = true;
            Player.transform.position = Teleport_subject.transform.position;
            To_Teleport_Distance_Inside();
            script_for_Events.blackscreen = false;
            Teleport_activated = false;
            Debug.Log("setyuiwe5r423");
            BlackScreen.SetInteger("ScreenState", 1);
            Debug.Log("setyui");
        }
        if(script_for_Events.blackscreen && !OnTheStreets)
        {
            IGotoRoom = true;
            Player.transform.position = Teleport_subject.transform.position;
            To_Teleport_Distance_Inside();
            script_for_Events.blackscreen = false;
            BlackScreen.SetInteger("ScreenState", 1);
            Teleport_activated = false;
            Debug.Log("setyui2526");
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
            BlackScreen.speed *= 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hans")
        {
            intrigger = false;
            BlackScreen.speed /= 2;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Hans")
        {
            intrigger = false;
        }
    }
}
