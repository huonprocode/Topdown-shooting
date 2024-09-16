using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] float folowSpeed;
    [SerializeField] float setY;
    public Transform target;
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + setY, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, folowSpeed);
    }
}
