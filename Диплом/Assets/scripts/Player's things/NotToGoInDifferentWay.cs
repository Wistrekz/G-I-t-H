using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotToGoInDifferentWay : MonoBehaviour
{
    [SerializeField]
    private GameObject Player, ThoughtsPanel;

    [SerializeField]
    private string Path_ToReasonWhyDont, NameOfMessageForEv;
    public bool IfDoor, WithSomeone, EventStuff;

    public enum direction
    {
        left = 0,
        right = 1,
        Up = 2,
        Down = 3
    }

    
    public direction FinalDestination;
    public float Player_PercentOfTeleportation;
    public int[] NumbersOfClosedEvents;

    private bool StartDialog;



    private void Awake()
    {
        if(gameObject.GetComponent<Room_traveler>() != null && gameObject.GetComponent<Room_traveler>().enabled)
        {
            gameObject.GetComponent<Room_traveler>().enabled = false;
        }
    }

    private void Update()
    {
        if(ActivateShowingPanel)
        {
            if (IfDoor)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                {
                    for (int i = 0; i < NumbersOfClosedEvents.Length; i++)
                    {
                        if (script_for_Events.ScriptNumber == NumbersOfClosedEvents[i])
                        {
                            if(!StartDialog)
                            {
                                script_for_Events.ThinkStart = true;
                                StartDialog = true;
                            }
                            if(WithSomeone)
                            {
                                MIxed_dialog.Call_Cutscene_Dialog(Path_ToReasonWhyDont, NameOfMessageForEv);
                                if (script_for_Events.DialogEnd)
                                {
                                    moving.CantMove = false;
                                    script_for_Events.DialogEnd = false;
                                    script_for_Events.DialogStart = false;
                                    switch (FinalDestination)
                                    {
                                        case direction.left:
                                            Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                            break;
                                        case direction.right:
                                            Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                            break;
                                        case direction.Up:
                                            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                            break;
                                        case direction.Down:
                                            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                            break;

                                    }

                                }
                            }
                            else
                            {
                                ThinkingReplics.Call_Cutscene_Dialog(Path_ToReasonWhyDont, NameOfMessageForEv);
                                if (script_for_Events.ThinkEnd)
                                {
                                    moving.CantMove = false;
                                    script_for_Events.ThinkEnd = false;
                                    script_for_Events.ThinkStart = false;
                                    switch (FinalDestination)
                                    {
                                        case direction.left:
                                            Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                            break;
                                        case direction.right:
                                            Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                            break;
                                        case direction.Up:
                                            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                            break;
                                        case direction.Down:
                                            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                            break;

                                    }

                                }
                            }
                        }
                    }
                    if (WithSomeone && !EventStuff)
                    {
                        MIxed_dialog.Call_Cutscene_Dialog(Path_ToReasonWhyDont, NameOfMessageForEv);
                        if (script_for_Events.DialogEnd)
                        {
                            moving.CantMove = false;
                            script_for_Events.DialogEnd = false;
                            script_for_Events.DialogStart = false;
                            switch (FinalDestination)
                            {
                                case direction.left:
                                    Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                    break;
                                case direction.right:
                                    Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                    break;
                                case direction.Up:
                                    Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                    break;
                                case direction.Down:
                                    Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                    break;

                            }

                        }
                    }
                    else
                    {
                        ThinkingReplics.Call_Cutscene_Dialog(Path_ToReasonWhyDont, NameOfMessageForEv);
                        if (script_for_Events.ThinkEnd)
                        {
                            moving.CantMove = false;
                            script_for_Events.ThinkEnd = false;
                            script_for_Events.ThinkStart = false;
                            switch (FinalDestination)
                            {
                                case direction.left:
                                    Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                    break;
                                case direction.right:
                                    Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                    break;
                                case direction.Up:
                                    Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                    break;
                                case direction.Down:
                                    Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                    break;

                            }

                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < NumbersOfClosedEvents.Length; i++)
                {
                    Debug.Log(i + 1);
                    if (script_for_Events.ScriptNumber == NumbersOfClosedEvents[i])
                    {
                        moving.CantMove = true;
                        if (!StartDialog)
                        {
                            script_for_Events.ThinkStart = true;
                            StartDialog = true;
                        }
                        if (WithSomeone)
                        {
                            MIxed_dialog.Call_Cutscene_Dialog(Path_ToReasonWhyDont, NameOfMessageForEv);
                            if (script_for_Events.DialogEnd)
                            {
                                moving.CantMove = false;
                                script_for_Events.DialogEnd = false;
                                script_for_Events.DialogStart = false;
                                switch (FinalDestination)
                                {
                                    case direction.left:
                                        Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                        break;
                                    case direction.right:
                                        Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                        break;
                                    case direction.Up:
                                        Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                        break;
                                    case direction.Down:
                                        Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                        break;

                                }

                            }
                        }
                        else
                        {
                            ThinkingReplics.Call_Cutscene_Dialog(Path_ToReasonWhyDont, NameOfMessageForEv);
                            if (script_for_Events.ThinkEnd)
                            {
                                moving.CantMove = false;
                                script_for_Events.ThinkEnd = false;
                                script_for_Events.ThinkStart = false;
                                switch (FinalDestination)
                                {
                                    case direction.left:
                                        Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                        break;
                                    case direction.right:
                                        Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                        break;
                                    case direction.Up:
                                        Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                        break;
                                    case direction.Down:
                                        Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                        break;

                                }

                            }
                        }
                    }
                }
                if (WithSomeone && !EventStuff)
                {
                    MIxed_dialog.Call_Cutscene_Dialog(Path_ToReasonWhyDont, NameOfMessageForEv);
                    if (script_for_Events.DialogEnd)
                    {
                        moving.CantMove = false;
                        script_for_Events.DialogEnd = false;
                        script_for_Events.DialogStart = false;
                        switch (FinalDestination)
                        {
                            case direction.left:
                                Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                break;
                            case direction.right:
                                Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                break;
                            case direction.Up:
                                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                break;
                            case direction.Down:
                                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                break;

                        }

                    }
                }
                else
                {
                    ThinkingReplics.Call_Cutscene_Dialog(Path_ToReasonWhyDont, NameOfMessageForEv);
                    if (script_for_Events.ThinkEnd)
                    {
                        moving.CantMove = false;
                        script_for_Events.ThinkEnd = false;
                        script_for_Events.ThinkStart = false;
                        switch (FinalDestination)
                        {
                            case direction.left:
                                Player.transform.position = new Vector2(Player.transform.position.x - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                break;
                            case direction.right:
                                Player.transform.position = new Vector2(Player.transform.position.x + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation), Player.transform.position.y);
                                break;
                            case direction.Up:
                                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                break;
                            case direction.Down:
                                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - (Math.Abs(Player.transform.lossyScale.x) / 100 * Player_PercentOfTeleportation));
                                break;

                        }

                    }
                }
            }
        }
    }

    private bool ActivateShowingPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Hans")
        {
            ActivateShowingPanel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hans")
        {
            ActivateShowingPanel = false;
            StartDialog = false;
        }

    }
}
