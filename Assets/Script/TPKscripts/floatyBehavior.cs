﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatyBehavior : MonoBehaviour
{
    private float tiltAngle = 0;
    public float turnSpeed = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiltAngle += turnSpeed;
        transform.rotation = Quaternion.Euler(0, transform.rotation.x + tiltAngle, 0);
    }
}
