using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viggen : MonoBehaviour
{
    public float MaxSpeed = 10f;
    public float RotateSpeed = 10f;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);

    }

    private void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");

        //transform.Translate(transform.forward * MaxSpeed * vert * Time.deltaTime, Space.Self);

        Vector3 pos = transform.position;
        Vector3 move = transform.forward * MaxSpeed * vert * Time.deltaTime;

        pos += move;
        transform.position = pos;


        transform.Rotate(transform.up, RotateSpeed * horiz * Time.deltaTime, Space.Self);

          
    }

}
