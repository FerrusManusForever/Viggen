using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public float RotateSpeed = 1f;
    public Transform FollowTarget;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - FollowTarget.transform.position;
        
    }

    private void Update()
    {
        float rotateCam = Input.GetAxis("RotateCam");
        transform.Rotate(transform.up, rotateCam * RotateSpeed * Time.deltaTime, Space.Self);
    }

    void LateUpdate()
    {
        transform.position = FollowTarget.position + offset;
    }
}
