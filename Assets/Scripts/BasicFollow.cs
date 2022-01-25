using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        if (target!=null)
        transform.position = target.position;
    }
}
