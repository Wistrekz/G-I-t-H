using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_regular : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Loadfiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Loadfiles()
    {
        PlayerPrefs.GetInt("Num_lang");
        PlayerPrefs.Save();
    }
}
