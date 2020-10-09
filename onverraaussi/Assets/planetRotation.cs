using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetRotation : MonoBehaviour
{
    public Transform Sun;
    public Transform Planet;

    float radius;
    float angle;
    float x;
    float y;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //radius = Math.Abs(Planet.position.x) - Math.Abs(Sun.position.x);
        radius = 120;
        Debug.Log(radius);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(x, y, 0, Sun);
        transform.RotateAround(Sun.position, Vector3.up, Time.deltaTime * speed);
        
        //transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }
}
