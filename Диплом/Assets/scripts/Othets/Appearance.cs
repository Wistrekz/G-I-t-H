using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appearance : MonoBehaviour
{

    public static void Dissappear(Image image, float step, float interval)
    {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - step);
            Appearance.Tars(interval);
        Debug.Log(image.color.a);
            if (image.color.a <= 0)
            {
                script_for_Events.blackscreen = false;
                return;
            }
    }
    public static void Dissappear(Image image, float step, float interval, float opacity)
    {
        for (; true;)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - step);
            Appearance.Tars(interval);
            if (image.color.a == opacity)
            {
                script_for_Events.blackscreen = false;
                return;
            }
        }
    }
    public static void Appears(Image image, float step, float interval)
    {
        for (; true;)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - step);
            Appearance.Tars(interval);
            if (image.color.a == 1)
            {
                script_for_Events.blackscreen = true;
                return;
            }
        }
    }

    public static void Appears(Image image, float step, float interval, float opacity)
    {
        for (; true;)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - step);
            Appearance.Tars(interval);
            if (image.color.a == opacity)
            {
                
                return;
            }
        }
    }

    public static IEnumerator Tars(float Times)
    {
        yield return new WaitForSeconds(Times);
    }
}
