using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moving : MonoBehaviour
{
    public int speed;
    private int speed1;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public Sprite[] sprites = new Sprite[12];
    public float timing_frames;
    private int status = 0;

    public static bool CantMove;

    private float counter = 1;
    private bool plus_minus = true;
    private float counter2 = 1;
    private bool plus_minus2 = true;
    private float counter3 = 1;
    private bool plus_minus3 = true;
    private float counter4 = 1;
    private bool plus_minus4 = true;

    private float x_coordiate;
    private float y_coordiate;


    private void Awake()
    {
        speed1 = speed;
        rb = GetComponent<Rigidbody2D>();
        x_coordiate = gameObject.transform.position.x;
        y_coordiate = gameObject.transform.position.y;
    }

    public void Update()
    {
        Vector2 moveInput = new Vector2(transform.position.x, transform.position.y);
        if (!CantMove)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
        }
        else
        {
            speed = 0;
            moveVelocity = new Vector2();
        }
        Debug.Log(CantMove);
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        if (gameObject.transform.position.y < y_coordiate)
        {
            if (counter <= timing_frames && plus_minus)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                status = 1;
                counter++;
                if (counter == timing_frames)
                    plus_minus = !plus_minus;
            }
            else if (counter >= 0 && !plus_minus)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                status = 2;
                counter--;
                if (counter == 0)
                    plus_minus = !plus_minus;
            }
        }

        if (gameObject.transform.position.y > y_coordiate)
        {
            if (counter2 <= timing_frames && plus_minus2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
                status = 4;
                counter2++;
                if (counter2 == timing_frames)
                    plus_minus2 = !plus_minus2;
            }
            else if (counter3 >= 0 && !plus_minus3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
                status = 5;
                counter2--;
                if (counter2 == 0)
                    plus_minus2 = !plus_minus2;
            }
        }

        if (gameObject.transform.position.x < x_coordiate)
        {
            if (counter3 <= timing_frames && plus_minus3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
                status = 7;
                counter3++;
                if (counter3 == timing_frames)
                    plus_minus3 = !plus_minus3;
            }
            else if (counter3 >= 0 && !plus_minus3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[8];
                status = 8;
                counter3--;
                if (counter3 == 0)
                    plus_minus3 = !plus_minus3;
            }
        }

        if (gameObject.transform.position.x > x_coordiate)
        {
            if (counter4 <= timing_frames && plus_minus4)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[10];
                status = 10;
                counter4++;
                if (counter4 == timing_frames)
                    plus_minus4 = !plus_minus4;
            }
            else if (counter4 >= 0 && !plus_minus4)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[11];
                status = 11;
                counter4--;
                if (counter4 == 0)
                    plus_minus4 = !plus_minus4;
            }
        }

        if (gameObject.transform.position.x == x_coordiate && gameObject.transform.position.y == y_coordiate)
        {
            if (status == 1 || status == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
            if (status == 4 || status == 5)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
            }
            if (status == 7 || status == 8)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
            }
            if (status == 10 || status == 11)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[9];
            }
        }
        x_coordiate = gameObject.transform.position.x;
        y_coordiate = gameObject.transform.position.y;
    }

}
