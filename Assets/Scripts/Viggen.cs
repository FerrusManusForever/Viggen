using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viggen : MonoBehaviour
{
    public float MinSpeed = 0.1f;
    public float MaxSpeed = 10f;
    public float RotateSpeed = 10f;
    public float FireInterval = 0.1f;
    public GameObject BulletRef;
    public float RocketSpeed = 1f;
        

    private bool isFiring = false;
    private float fireTimer = 0f;



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);

    }

    private void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");
        bool isFiring = Input.GetButton("Fire1");

        HandleMovement(vert, horiz);
        HandleFiring(isFiring);
        


        transform.Rotate(transform.up, RotateSpeed * horiz * Time.deltaTime, Space.Self);

          
    }

    private void HandleMovement(float vert, float horiz)
    {
        Vector3 pos = transform.position;
        Vector3 move = transform.forward * MaxSpeed * vert * Time.deltaTime;

        pos += move;
        transform.position = pos;
    }

    private void HandleFiring(bool isFiring)
    {
        if (isFiring)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= FireInterval)
            {
                Fire();
                fireTimer = 0f;
            }
        } else
        {
            fireTimer = 0f;
        }
    }

    private void Fire()
    {
        var bullet = Instantiate(BulletRef, transform.position, Quaternion.identity);
        var rb = bullet.GetComponent<Rigidbody>();

        var velocity = transform.forward * RocketSpeed;
        rb.velocity = velocity;

    }

    public void Afterburn(bool on)
    {

    }

}
