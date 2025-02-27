using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public Transform FollowTarget;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - FollowTarget.transform.position;
        
    }

    void LateUpdate()
    {
        transform.position = FollowTarget.position + offset;
    }
}
