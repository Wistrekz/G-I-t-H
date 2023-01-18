using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_animated : MonoBehaviour
{

    
    public Vector2 endposition;
    public float step;
    public float iteration_pos_x;

    private float progress = 0;
    private Vector2 iterator_position;
    private bool left;
    private bool first_end;
    private Vector2 startposition;
    private void Start()
    {
        startposition = transform.position;
        endposition.y = gameObject.transform.position.y;
        iterator_position.x = iteration_pos_x;
        iterator_position.y = gameObject.transform.position.y;
    }

    void FixedUpdate()
    {
        if(!first_end)
        {
            transform.position = Vector2.Lerp(startposition, endposition, progress);
            progress += step;
        }
        if(gameObject.transform.position.x == endposition.x)
        {
            transform.position = new Vector2(iteration_pos_x, gameObject.transform.position.y);
            first_end = true;
            left = false;
            progress = 0;
        }
        if(gameObject.transform.position.x == iteration_pos_x)
        {
            left = true;
        }
        if(left)
        {       
            transform.position = Vector2.Lerp(iterator_position, endposition, progress);
            progress += step;
        }
    }


}
