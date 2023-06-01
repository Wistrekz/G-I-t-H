using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseObj;

    private void Update()
    {
        Debug.Log("sadasda");
        if(Input.GetButtonDown("Cancel") && !PauseObj.activeSelf)
        {
            PauseObj.SetActive(true);
            Time.timeScale = 0;
            Debug.LogError("sadasda1");
        }
        else if (Input.GetButtonDown("Cancel") && PauseObj.activeSelf)
        {
            Time.timeScale = 1;
            PauseObj.SetActive(false);
            Debug.LogError("sadasda2");
        }
    }

    public void Exit()
    {
        Debug.LogError("sadasda2");
        Application.Quit();
        Debug.LogError("sadasda3");
    }
}
