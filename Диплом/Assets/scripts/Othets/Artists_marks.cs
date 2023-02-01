using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Artists_marks
{
    public static string Namemark_Symbol = "*{KL::'}";
    private static Vector2 coordinates;
    public static Vector2 Player_coordinates
    {
        get
        {
            return coordinates;
        }
        set
        {
            coordinates = value;
        }
    }

}
