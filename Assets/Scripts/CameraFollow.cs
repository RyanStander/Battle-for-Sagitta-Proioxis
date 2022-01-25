using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset;
    Quaternion startRotation;
    void Start()
    {
        offset = transform.position - target.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        //euler angles
        Quaternion targetYRotation = Quaternion.Euler(0, target.rotation.eulerAngles.y, 0);
        transform.position = target.position + targetYRotation * offset;
        //rotations applied to left and right
        transform.rotation = targetYRotation * startRotation;
    }
}
