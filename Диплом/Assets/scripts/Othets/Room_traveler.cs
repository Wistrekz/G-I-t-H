using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_traveler : MonoBehaviour
{
    public Animator BlackScreen;

    public static bool IGotoRoom;
    public static bool TravelToLocation;
    public static GameObject SpriteForSizes; 

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
    public direction dirToNextRoom;
    public direction dirToBack;
    public float Player_PercentOfTeleportation;
    public float Player_PercentOfTeleportation_Back;
    public bool Isdoor;
    [Header("Ouside_sets")]
    public GameObject Teleport_subject;
    public bool OnTheStreets;
    [Header("MoreConditions")]
    public GameObject ThoughtsPanel;
    public string NeedableItem; //If dont need, not write
    public int[] NumberofEventsblocking; //If dont need, not write
    public string Path_ToSuccess, Path_ToFailure, NameOfPlace;  //Путь до файлов которые прокоментируют успех или ошибку

    private bool intrigger;
    private bool Teleport_activated, Anim_start, Player_teleported;

    private bool BadEvent, FirstTimeFrame, UseItemCommented;


    private void To_Teleport_Distance_Inside() //метод телепортирует персонажа недалеко от триггера телепортации чтобы не произошла она повторно
    {
        switch (dirToNextRoom)
        {
            case direction.left:
                Player.transform.position = new Vector2(Teleport_subject.transform.position.x - Player_PercentOfTeleportation, Teleport_subject.transform.position.y);
                break;
            case direction.right:
                Player.transform.position = new Vector2(Teleport_subject.transform.position.x + Player_PercentOfTeleportation, Teleport_subject.transform.position.y);
                break;
            case direction.Up:
                Player.transform.position = new Vector2(Teleport_subject.transform.position.x, Teleport_subject.transform.position.y + Player_PercentOfTeleportation);
                Debug.Log(Player.transform.position);
                break;
            case direction.Down:
                Player.transform.position = new Vector2(Teleport_subject.transform.position.x, Teleport_subject.transform.position.y - Player_PercentOfTeleportation);
                break;

        }
    }

    private void To_Teleport_Distance_Back()//метод телепортирует персонажа назад из-за ошибки
    {
        switch (dirToNextRoom)
        {
            case direction.left:
                Player.transform.position = new Vector2(Player.transform.position.x - Player_PercentOfTeleportation_Back, Player.transform.position.y);
                break;
            case direction.right:
                Player.transform.position = new Vector2(Player.transform.position.x + Player_PercentOfTeleportation_Back, Player.transform.position.y);
                break;
            case direction.Up:
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation_Back));
                break;
            case direction.Down:
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation_Back));
                break;
        }
    }

    private void Teleportation()
    {
        if(OnTheStreets && !Anim_start) //Если персонаж не на основных локациях то система счисления будет работать по другому
        {
            if (Isdoor) //Если это дверь то надо нажимать кнопку
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                {
                    BlackScreen.SetInteger("ScreenState", 2);  //при телепортации затемняется экран
                    Teleport_activated = true;
                    Anim_start = true;
                }
            }
            else
            {
                Debug.Log("setyui11111");
                BlackScreen.SetInteger("ScreenState", 2);
                Debug.Log("BlackScreen state" + BlackScreen.GetInteger("ScreenState")); //при телепортации затемняется экран
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
                    BlackScreen.SetInteger("ScreenState", 2); //при телепортации затемняется экран
                    Teleport_activated = true;
                    Anim_start = true;
                }
            }
            else
            {
                Debug.Log("setyui11111");
                BlackScreen.SetInteger("ScreenState", 2); //при телепортации затемняется экран
                Teleport_activated = true;
                Anim_start = true;
            }
        }

    }

    public void TeleportInBlack() //сама телепортация до пункта назначения происходит когда темный экран
    {
        Debug.Log(script_for_Events.blackscreen);
        if (script_for_Events.blackscreen && OnTheStreets)
        {
            To_Teleport_Distance_Inside();
            SpriteForSizes = Location_sprite;
            Teleport_activated = false;
            BlackScreen.SetInteger("ScreenState", 1);
            Anim_start = false;
            Player_teleported = true;
        }
        if(script_for_Events.blackscreen && !OnTheStreets)
        {
            IGotoRoom = true;
            To_Teleport_Distance_Inside();
            SpriteForSizes = Location_sprite;
            BlackScreen.SetInteger("ScreenState", 1);
            Teleport_activated = false;
            Anim_start = false;
            Player_teleported = true;
            
        }
    }

    void Start()
    {
        IGotoRoom = false;
        
    }

    public void StartTeleport()
    {
        Debug.Log("BlackScreen peredacha " + BlackScreen.GetInteger("ScreenState"));
        if (intrigger && !Teleport_activated) //проверка на нахождение в триггере и активацию телепорта
        {
            Debug.Log("sdfgg");
            Teleportation();
        }
        if (Teleport_activated)
        {
            Debug.Log("Teleport");
            TeleportInBlack();
        }
        if (Player_teleported && !script_for_Events.blackscreen)
        {
            UseItemCommented = false;
            moving.CantMove = false;
            Player_teleported = false;
        }
    }

    public void Update()
    {
        if(Isdoor)
        {

            if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Teleport_activated || Player_teleported)
            {
                if (string.IsNullOrEmpty(NeedableItem) && NumberofEventsblocking.Length == 0)
                {
                    //usial rejim
                    StartTeleport();
                }
                else
                {
                    //режим того или другого

                    if (intrigger && NumberofEventsblocking.Length > 0)
                    {
                        for (int i = 0; i < NumberofEventsblocking.Length; i++)
                        {
                            if (script_for_Events.ScriptNumber == NumberofEventsblocking[i])
                            {
                                //esli est' veshi to otkaz
                                BadEvent = true;
                                break;
                            }

                        }
                        if (BadEvent)
                        {
                            //sam otkaz
                            ThinkingReplics.Call_Cutscene_Dialog(Path_ToFailure, NameOfPlace);
                            if (!FirstTimeFrame)
                            {
                                FirstTimeFrame = true;
                                return;
                            }
                            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                            {
                                FirstTimeFrame = false;
                            }
                            if (script_for_Events.ThinkEnd)
                            {
                                Debug.Log("Chototam");
                                moving.CantMove = false;
                                script_for_Events.ThinkEnd = false;
                                BadEvent = false;
                                return;
                            }
                        }

                    }
                    if (intrigger && NeedableItem != null)
                    {
                        //режим "нужна вещь"
                        Debug.Log(Cheats.WRITEInventory());
                        Debug.Log(Cheats.CheckInventoryOnThisItem(NeedableItem));
                        if(UseItemCommented)
                        {
                            StartTeleport();
                        }
                        if (Cheats.CheckInventoryOnThisItem(NeedableItem))
                        {
                            if (!FirstTimeFrame)
                            {
                                
                                script_for_Events.ThinkStart = true;
                                script_for_Events.ThinkGoing = true;
                                FirstTimeFrame = true;
                                ThinkingReplics.Call_Cutscene_Dialog(Path_ToSuccess, NameOfPlace);
                            }
                            Debug.Log(script_for_Events.ThinkStart);
                            
                            
                            if (script_for_Events.ThinkEnd)
                            {
                                script_for_Events.ThinkEnd = false;
                                UseItemCommented = true;
                                Debug.Log("Chototam");
                                
                                return;
                            }
                        }
                        else
                        {
                            //fail
                            if(!FirstTimeFrame)
                            {
                                FirstTimeFrame = true;
                                return;
                            }
                            ThinkingReplics.Call_Cutscene_Dialog(Path_ToFailure, NameOfPlace);
                            if (script_for_Events.ThinkEnd)
                            {
                                script_for_Events.ThinkEnd = false;
                                FirstTimeFrame = false;
                                Debug.Log("Chototam");
                                return;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (string.IsNullOrEmpty(NeedableItem) && NumberofEventsblocking.Length == 0)
            {
                //обычный режим

                StartTeleport();
                return;
            }
            else
            {
                //режим того или другого

                if (intrigger && NumberofEventsblocking.Length > 0)
                {
                    for (int i = 0; i < NumberofEventsblocking.Length; i++)
                    {
                        if (script_for_Events.ScriptNumber == NumberofEventsblocking[i])
                        {
                            BadEvent = true;
                            break;
                        }

                    }
                    if (BadEvent)
                    {
                        ThinkingReplics.Call_Cutscene_Dialog(Path_ToFailure, NameOfPlace);
                        if (script_for_Events.ThinkEnd)
                        {
                            script_for_Events.ThinkEnd = false;
                            To_Teleport_Distance_Back();
                            BadEvent = false;
                            return;
                        }
                    }

                }
                if (intrigger && NeedableItem != null)
                {
                    //режим "нужна вещь"

                    if (Cheats.CheckInventoryOnThisItem(NeedableItem))
                    {
                        Debug.Log("Нужна вещь");
                        if (!FirstTimeFrame)
                        {
                            script_for_Events.ThinkStart = true;
                            Debug.Log("синк старт");
                            FirstTimeFrame = true;
                            return;
                        }
                        ThinkingReplics.Call_Cutscene_Dialog(Path_ToSuccess, NameOfPlace);
                        if (script_for_Events.ThinkEnd)
                        {
                            Debug.Log("синк энд");
                            script_for_Events.ThinkEnd = false;
                            StartTeleport();
                            return;
                        }
                    }
                    else
                    {
                        if (!FirstTimeFrame)
                        {
                            script_for_Events.ThinkStart = true;
                            FirstTimeFrame = true;
                            return;
                        }
                        ThinkingReplics.Call_Cutscene_Dialog(Path_ToFailure, NameOfPlace);
                        if (script_for_Events.ThinkEnd)
                        {
                            script_for_Events.ThinkEnd = false;
                            FirstTimeFrame = false;
                            To_Teleport_Distance_Back();
                            return;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hans")
        {
            if (!Isdoor)
            {
                moving.CantMove = true;
            }else
            {
                
            }
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
        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && collision.gameObject.name == "Hans")
        {
            moving.CantMove = true;
        }
    }
}
