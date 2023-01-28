using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private string SpecTag;

    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(SpecTag);

        if(obj != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.tag = SpecTag;
        }
    }
}
