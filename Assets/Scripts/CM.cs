using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CM : MonoBehaviour
{
    public Rigidbody rb;
    public WheelCollider lfW, rfW, lbW, rbW;
    public float driveSpeed, steerSpeed;
    float hInput, vInput;
    float mult;


    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        ForwardMovement(vInput);

        lfW.steerAngle = steerSpeed * hInput;
        rfW.steerAngle = steerSpeed * hInput;

    }
    private void ForwardMovement(float vInput)
    {
        float motor = vInput * driveSpeed;

        if (vInput != 0) // Aplica motor torque si hay entrada vertical
        {
            lfW.motorTorque = motor * Time.timeScale;
            rfW.motorTorque = motor * Time.timeScale;
            lbW.motorTorque = motor * Time.timeScale;
            rbW.motorTorque = motor * Time.timeScale;

            // Desactiva el frenado mientras hay movimiento
            lfW.brakeTorque = 0;
            rfW.brakeTorque = 0;
            lbW.brakeTorque = 0;
            rbW.brakeTorque = 0;
        }
        else // Si no hay entrada vertical, aplica frenado
        {
            float brakeTorque = Mathf.Abs(motor);
            lfW.brakeTorque = brakeTorque;
            rfW.brakeTorque = brakeTorque;
            lbW.brakeTorque = brakeTorque;
            rbW.brakeTorque = brakeTorque;

            // Detén el motor torque para evitar conflictos
            lfW.motorTorque = 0;
            rfW.motorTorque = 0;
            lbW.motorTorque = 0;
            rbW.motorTorque = 0;
        }
    }
}