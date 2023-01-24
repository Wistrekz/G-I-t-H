using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_traveler : MonoBehaviour
{
    public bool Isdoor;
    public string scene_name;

    private bool intrigger;

    public void Update()
    {
        if(intrigger)
        {
            Debug.Log("sdfgg");
            if (Isdoor)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                {
                    SceneManager.LoadScene(scene_name);
                }
            }
            else
            {
                SceneManager.LoadScene(scene_name);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        intrigger = true;
    }
}
