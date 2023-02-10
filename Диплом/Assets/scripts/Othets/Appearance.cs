using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Appearance : MonoBehaviour
{
    public Image black_screen;
    public float step;

    public static bool disappear, appear;

    private void Update()
    {
        if(disappear)
        {
            black_screen.color = new Color(black_screen.color.r, black_screen.color.g, black_screen.color.b, black_screen.color.a - step);
            if(black_screen.color.a == 0)
            {
                disappear = false;
            }
        }
        if(appear)
        {
            black_screen.color = new Color(black_screen.color.r, black_screen.color.g, black_screen.color.b, black_screen.color.a + step);
            if (black_screen.color.a == 0)
            {
                disappear = false;
            }
        }
    }

    public IEnumerator Tars(float Times)
    {
        yield return new WaitForSeconds(Times);
    }
}
