using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appearance : MonoBehaviour
{
    public Animator Anim;

    public void SetValue(int value)
    {
        if(value == 2)
        {
            script_for_Events.blackscreen = true;
            Anim.SetInteger("ScreenState", 0);
            return;
        }
        if(value == 1)
        {
            script_for_Events.blackscreen = false;
            Anim.SetInteger("ScreenState", 0);
            return;
        }

    }

    public void SetStatus(int Value)
    {
        if(Value == 0)
        {
            script_for_Events.blackscreen = false;
            Debug.Log("white");
        }
        if (Value == 1)
        {
            script_for_Events.blackscreen = true;
        }
    }

}
