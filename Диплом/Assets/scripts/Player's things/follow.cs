using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public bool JustFollow;
    public GameObject Camera;
    public Transform objToFollow;
    public GameObject[] Special_triggers_for_camera;
    public GameObject[] SpritesInTriggers;

    public static bool Player_inTrigger;

    private Vector3 deltaPos;
    private Vector3 oldPosition;
    private Vector2 Location;
    public static Transform Gameobject;

    private float Map_size_x, Map_size_y;
    [SerializeField]
    float leftLimit, rightLimit, UpLimit, DownLimit;

    void Awake()
    {
        Gameobject = gameObject.transform;
        OnStartLocation();
        Dictionary_files.Default_lang_settings();
    }

    void OnStartLocation()
    {
        leftLimit += (float)6.7;
        rightLimit -= (float)6.7;
        UpLimit -= (float)5.05;
        DownLimit += (float)5.05;
    }

    void Set_Loc_borders()
    {
        for(int i = 0; i < Special_triggers_for_camera.Length; i++)
        {
            if (Special_triggers_for_camera[i].GetComponent<BoxCollider2D>().gameObject.transform.position == new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, DownLimit, UpLimit), transform.position.z))
            {
                Debug.Log("sdfefwe");
                Location = SpritesInTriggers[i].transform.position;
                var bounds = SpritesInTriggers[i].GetComponent<SpriteRenderer>().bounds;
                Map_size_x = bounds.size.x;
                Map_size_y = bounds.size.y;
                leftLimit = Location.x - (Map_size_x / 2);
                rightLimit = Location.x + (Map_size_x / 2);
                UpLimit = Location.y + (Map_size_y / 2);
                DownLimit = Location.y - (Map_size_y / 2);
            }
        }

        OnStartLocation();
        //Камера ограничевается границами спрайта
    }

    void Start()
    {
        transform.position = new Vector3(objToFollow.transform.position.x, objToFollow.transform.position.y, transform.position.z);
        deltaPos = transform.position - objToFollow.position;
    }
    void Update()
    {
        if(JustFollow)
        {
            transform.position = objToFollow.position + deltaPos;
            oldPosition = transform.position;
        }
        else
        {
            if (Room_traveler.TravelToLocation)
            {
                Set_Loc_borders();
                Room_traveler.TravelToLocation = false;    //Путь в комнату. В комнате камера не ограничена
                Room_traveler.IGotoRoom = false;
            }
            transform.position = objToFollow.position + deltaPos;
            oldPosition = transform.position;
            if (!Room_traveler.IGotoRoom)
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, DownLimit, UpLimit), transform.position.z);

            if (!Player_inTrigger)
            {
                Room_traveler.IGotoRoom = true;
            }
            if (Player_inTrigger)
            {
                Room_traveler.IGotoRoom = false;
            }
        }
    }

    public static void MoveCameraTo(Transform NextPosition)
    {
        var nextPosition = Vector3.Lerp(Gameobject.position, new Vector3(NextPosition.position.x, NextPosition.position.y), Time.deltaTime);
        Gameobject.position = nextPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, UpLimit), new Vector2(rightLimit, UpLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, DownLimit), new Vector2(rightLimit, DownLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, UpLimit), new Vector2(leftLimit, DownLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, UpLimit), new Vector2(rightLimit, DownLimit));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            Player_inTrigger = true;
        }
        if (collision.gameObject.name != "Hans" && collision.gameObject.name != "MainCamera")
        {
            Player_inTrigger = false;
        }
    }
}
