using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    [SerializeField] private float rotSpeed; // Rotation speed

    private void FixedUpdate()
    {
        transform.Rotate(transform.localPosition, rotSpeed); // Rotates the Propeller around its local positon
    }
}
