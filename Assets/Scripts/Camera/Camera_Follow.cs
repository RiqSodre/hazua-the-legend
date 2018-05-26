using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public Transform target;

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x + 20, target.position.y + 3, -30);
    }
}