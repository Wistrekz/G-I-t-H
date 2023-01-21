using System.Threading.Tasks;
using UnityEngine;

public class tree_anim : MonoBehaviour
{

    public Sprite[] sprites = new Sprite[4];

    public int timing;

    private int switcher = 0;
    private bool reverse;


    void Start()
    {
        anim();
    }

    void looktime()
    {
        
    }
    void anim()
    {
        
        if (!reverse)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[switcher];
            switcher++;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[switcher];
            switcher--;
        }
        if (switcher == sprites.Length - 1)
        {
            reverse = true;
        }
        if (switcher == 0)
        {
            reverse = false;
        }
        Debug.Log(switcher);
        anim();
    }
}
