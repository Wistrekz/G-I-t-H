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

    private Vector3 deltaPos;
    private Vector2 Location;
    public static Transform Gameobject;

    private float Map_size_x, Map_size_y;
    [SerializeField]
    float leftLimit, rightLimit, UpLimit, DownLimit;

    private bool IsHaveBorders;
    private int Notnormalsize;

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
        Location = Room_traveler.SpriteForSizes.transform.position;
        var bounds = Room_traveler.SpriteForSizes.GetComponent<SpriteRenderer>().bounds;
        if(bounds.size.x <= 11.4 || bounds.size.y <= 9.7)
        {
            if (bounds.size.x <= 13.4)
            {
                Notnormalsize += 1;
            }
            if(bounds.size.y <= 11.7)
            {
                Notnormalsize += 2;
                    
            }
            switch(Notnormalsize)
            {
                case 1: Map_size_x = (float)0.0001;
                    break;
                case 2:
                    Map_size_y = (float)0.0001;
                    break;
                case 3:
                    Map_size_x = (float)0.0001;
                    Map_size_y = (float)0.0001;
                    break;
            }
            leftLimit = Location.x - Map_size_x;
            rightLimit = Location.x + Map_size_x;
            UpLimit = Location.y + Map_size_y;
            DownLimit = Location.y - Map_size_y;
            IsHaveBorders = true;
            Notnormalsize = 0;
        }
        else
        {
            Map_size_x = bounds.size.x;
            Map_size_y = bounds.size.y;
            leftLimit = Location.x - (Map_size_x / 2);
            rightLimit = Location.x + (Map_size_x / 2);
            UpLimit = Location.y + (Map_size_y / 2);
            DownLimit = Location.y - (Map_size_y / 2);
            IsHaveBorders = true;
            OnStartLocation();
        }
        //Камера ограничевается границами спрайта
    }



    void Start()
    {
        transform.position = new Vector3(objToFollow.transform.position.x, objToFollow.transform.position.y, transform.position.z); //Передвижение идёт строго за персонажем если он на территории разрешённой камере
        deltaPos = transform.position - objToFollow.position;
    }
    void Update()
    {
        if(JustFollow)
        {
            if (!script_for_Events.NeedFreeCamera)
            {
                transform.position = objToFollow.position + deltaPos; //передвижение камеры в простом режиме без границ
            }
            
        }
        else
        {
            if (!script_for_Events.NeedFreeCamera)
            {
                transform.position = objToFollow.position + deltaPos;
            }
            else
            {
                IsHaveBorders = true;
            }
            Set_Loc_borders();


            /*if (Room_traveler.TravelToLocation)
            {
                Set_Loc_borders();
                Room_traveler.TravelToLocation = false;    //Путь в комнату. В комнате камера не ограничена
                Room_traveler.IGotoRoom = false;
            }
            if(!script_for_Events.NeedFreeCamera)
            {
                transform.position = objToFollow.position + deltaPos;
                oldPosition = transform.position;
            }
            if (!Room_traveler.IGotoRoom)
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, DownLimit, UpLimit), transform.position.z);

            if (!Player_inTrigger)
            {
                Room_traveler.IGotoRoom = true;
            }
            if (Player_inTrigger)
            {
                Room_traveler.IGotoRoom = false;
            }*/
        }
        if (IsHaveBorders)
        {
            gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, DownLimit, UpLimit), transform.position.z);
        }
    }

    public static void MoveCameraTo(Transform NextPosition)
    {
        var nextPosition = Vector3.Lerp(Gameobject.position, new Vector3(NextPosition.position.x, NextPosition.position.y), Time.deltaTime); //движение только в границах камеры
        Gameobject.position = nextPosition;
    }

    private void OnDrawGizmos() //для проверки границ каеры
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, UpLimit), new Vector2(rightLimit, UpLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, DownLimit), new Vector2(rightLimit, DownLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, UpLimit), new Vector2(leftLimit, DownLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, UpLimit), new Vector2(rightLimit, DownLimit));
    }
}
