using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title_animated : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites = new Sprite[2];
    
    public int end_num;

    private int counter;
    private int switcher = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        counter++;
        if(counter == end_num)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[switcher];
            counter = 0;
            if(switcher == 0)
            {
                switcher = 1;
            }
            else
            {
                switcher = 0;
            }
        }
        
    }
}
