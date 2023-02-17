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
    private bool Teleport_activated, Anim_start;

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
        if(OnTheStreets && !Anim_start)
        {
            if (Isdoor)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                {
                    Debug.Log("setyui11111");
                    BlackScreen.SetInteger("ScreenState", 2);
                    BlackScreen.SetBool("AnimEnd", true);
                    Teleport_activated = true;
                    Anim_start = true;
                }
            }
            else
            {
                Debug.Log("setyui11111");
                BlackScreen.SetInteger("ScreenState", 2);
                BlackScreen.SetBool("AnimEnd", true);
                Debug.Log(BlackScreen.GetInteger("ScreenState"));
                Teleport_activated = true;
                Anim_start = true;
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
                    BlackScreen.SetBool("AnimEnd", true);
                    Teleport_activated = true;
                    Anim_start = true;
                }
            }
            else
            {
                Debug.Log("setyui11111");
                BlackScreen.SetInteger("ScreenState", 2);
                BlackScreen.SetBool("AnimEnd", true);
                Teleport_activated = true;
                Anim_start = true;
            }
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
            BlackScreen.SetInteger("ScreenState", 1);
            BlackScreen.SetBool("AnimEnd", false);
            Anim_start = false;
        }
        if(script_for_Events.blackscreen && !OnTheStreets)
        {
            IGotoRoom = true;
            Player.transform.position = Teleport_subject.transform.position;
            To_Teleport_Distance_Inside();
            script_for_Events.blackscreen = false;
            BlackScreen.SetInteger("ScreenState", 1);
            BlackScreen.SetBool("AnimEnd", false);
            Teleport_activated = false;
            Anim_start = false;
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
        Debug.Log(BlackScreen.GetInteger("ScreenState"));
        if (intrigger && !Teleport_activated)
        {
            Debug.Log("sdfgg");
            Teleportation();
        }
        if(Teleport_activated)
        {
            TeleportInBlack();
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
