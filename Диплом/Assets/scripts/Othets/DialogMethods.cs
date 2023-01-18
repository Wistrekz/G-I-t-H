using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DialogMethods : MonoBehaviour
{
    public async Task Waiting()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
            {
                
                break;
            }
        }
        await Task.Yield();
    }
}
