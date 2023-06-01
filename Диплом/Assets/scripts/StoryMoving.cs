using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMoving : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("Start"))
        {
            script_for_Events.Triggername = collision.gameObject.name;
        }
    }

    public static void ShowPicture(GameObject Picture, string spriteName, float opacity)
    {
        if(Picture.GetComponent<SpriteRenderer>().sprite.name == spriteName)
        {
            Debug.LogError("Меняющийся спрайт тот же самый");
        }
        else
        {

        }
    }
}
