using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject Camera;
    public Transform objToFollow;
    public bool IsInHouse;

    private Vector3 deltaPos;
    private Vector3 oldPosition;
    [SerializeField]
    float leftLimit, rightLimit, UpLimit, DownLimit;

    void Awake()
    {
        if(!IsInHouse)
        {
            leftLimit += (float)6.7;
            rightLimit -= (float)6.7;
            UpLimit -= (float)5.05;
            DownLimit += (float)5.05;
        }
    }

    void Start()
    {
        transform.position = new Vector3(objToFollow.transform.position.x, objToFollow.transform.position.y, transform.position.z);
        deltaPos = transform.position - objToFollow.position;
    }
    void Update()
    {
        transform.position = objToFollow.position + deltaPos;
        oldPosition = transform.position;
        if(!IsInHouse)
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, DownLimit, UpLimit), transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, UpLimit), new Vector2(rightLimit, UpLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, DownLimit), new Vector2(rightLimit, DownLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, UpLimit), new Vector2(leftLimit, DownLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, UpLimit), new Vector2(rightLimit, DownLimit));
    }
}
