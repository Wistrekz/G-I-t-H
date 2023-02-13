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
            Debug.Log("sdff");
            script_for_Events.blackscreen = true;
            return;
        }
        if(value == 1)
        {
            Debug.Log("sdff1");
            script_for_Events.blackscreen = false;
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
