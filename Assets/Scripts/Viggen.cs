using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Altitude {
    Low,
    Med,
    High
}

public class Viggen : MonoBehaviour
{
    public float MinSpeed = 0.1f;
    public float MaxSpeed = 10f;
    public float RotateSpeed = 10f;
    public float FireInterval = 0.1f;
    public GameObject BulletRef;
    public float RocketSpeed = 1f;

    public float AltitudeLow = 0f;
    public float AltitudeMed = 2f;
    public float AltitudeHigh = 4f;
    public float ClimbDiveSpeed = 0.4f;
    public Altitude CurrentAltitude = Altitude.Low;

        

    private bool isFiring = false;
    private float fireTimer = 0f;
    private float climbDiveTimer = 0f;
    private float targetAltitude = 0f;

    



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
        HandleFlyUpDown();

        if (Input.GetButtonDown("BarrelRollLeft"))
        {
            BarrelRoll(-1);
        }
        if (Input.GetButtonDown("BarrelRollRight"))
        {
            BarrelRoll(1);
        }
        


        transform.Rotate(transform.up, RotateSpeed * horiz * Time.deltaTime, Space.Self);

          
    }

    private void HandleMovement(float vert, float horiz)
    {
        Vector3 pos = transform.position;
        Vector3 move = transform.forward * MaxSpeed * vert * Time.deltaTime;

        pos += move;
        transform.position = pos;
    }



    private void HandleFlyUpDown()
    {

        if (Input.GetButtonDown("FlyUp"))
        {
            if (CurrentAltitude == Altitude.Low)
            {
                CurrentAltitude = Altitude.Med;               
            }
            else if (CurrentAltitude == Altitude.Med)
            {
                CurrentAltitude = Altitude.High;
            }
                
        }

        if (Input.GetButtonDown("FlyDown"))
        {
            if (CurrentAltitude == Altitude.High)
            {
                CurrentAltitude = Altitude.Med;
            }
            else if (CurrentAltitude == Altitude.Med)
            {
                CurrentAltitude = Altitude.Low;
            }
        }

        Vector3 targetPos = transform.position;
        if (CurrentAltitude == Altitude.Low)
        {
            targetPos.y = AltitudeLow;
        }
        else if (CurrentAltitude == Altitude.Med)
        {
            targetPos.y = AltitudeMed;
        }
        else if (CurrentAltitude == Altitude.High)
        {
            targetPos.y = AltitudeHigh;
        }
        Vector3 pos = transform.position;
        pos = Vector3.MoveTowards(pos, targetPos, ClimbDiveSpeed * Time.deltaTime);

        transform.position = pos;

    }

    private void BarrelRoll(int direction)
    {

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
