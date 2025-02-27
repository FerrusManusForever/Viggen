using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruct : MonoBehaviour
{
    public float LifeTime = 10f;

    private float age = 0f;
    void Update()
    {
        age += Time.deltaTime;
        if (age >= LifeTime)
        {
            Destroy(gameObject);
        }
    }
}
