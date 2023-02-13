using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appearance : MonoBehaviour
{
    public Animator Anim;

    public void SetValue(int value)
    {
        if(Anim.GetInteger("screenState") == 1)
        {
            Event0.blackscreen = true;
        }
        if(Anim.GetInteger("screenState") == 2)
        {
            Event0.blackscreen = false;
        }
        Anim.SetInteger("screenState", value);

    }

    public void SetStatus(bool Status_blackScreen)
    {
        Event0.blackscreen = Status_blackScreen;
    }
}
