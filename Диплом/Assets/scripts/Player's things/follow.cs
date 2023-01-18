using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform objToFollow; // объект, за которым следует

    private Vector3 deltaPos;
    private Vector3 oldPosition;// разница расстояния по у z между двумя объектами


    void Start()
    {
        transform.position = new Vector3(objToFollow.transform.position.x, objToFollow.transform.position.y, transform.position.z);
        deltaPos = transform.position - objToFollow.position;
    }
    void Update()
    {
        transform.position = objToFollow.position + deltaPos;
        oldPosition = transform.position;
    }
}
