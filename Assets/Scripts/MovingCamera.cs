using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public Transform FollowTarget;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - FollowTarget.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = FollowTarget.position + offset;
    }
}
