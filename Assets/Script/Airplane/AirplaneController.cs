using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float speedPlane = 10;
    public float speedSteer = 5;
    private Transform theTransform;
    private float yaw, pitch, roll;
    private void Start()
    {
        theTransform = GetComponent<Transform>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        theTransform.position += transform.forward * (speedPlane * Time.deltaTime);
        yaw += speedSteer * x * Time.deltaTime;
        pitch = Mathf.Lerp(0, 30, Mathf.Abs(y)) * Mathf.Sign(y);
        roll = Mathf.Lerp(0, 30, Mathf.Abs(x)) * -Mathf.Sign(x);
        theTransform.localRotation = Quaternion.Euler(Vector3.up*yaw + Vector3.right * pitch + 
                                                      Vector3.forward * roll); 
    }
}
