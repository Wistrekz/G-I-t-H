using System.Collections;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogStart : MonoBehaviour
{
    public DialogManager dm;
    public moving IsMove;

    private bool IsIntrigger = false;

    private void Update()
    {
        if(IsIntrigger)
        {
            DialogArea();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Hans")
        {
            IsIntrigger = true;
        }
        else
        {
            IsIntrigger = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsIntrigger = false;
    }
    private void DialogArea()
    {
        Debug.Log("dsafas");
        
        if ((Input.GetButtonDown("Fire1") && !dm.inscript) || (Input.GetButtonDown("Fire2") && !dm.inscript))
        {
            Debug.Log("ddddddd");
            IsMove.StopMoving();
            dm.StartDialog();
        }
    }

}
