﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}

    /*public HingeJoint[] rWheels;
    public HingeJoint[] lWheels;

    float hp;
    float turn;

    private void Update()
    {
        hp = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");

        foreach(HingeJoint wheel in rWheels)
        {
            JointMotor motor = new JointMotor();
            motor.targetVelocity = hp * 2000 + turn * -300;
            motor.force = 2000;
            wheel.motor = motor;
        }

        foreach(HingeJoint wheel in lWheels)
        {
            JointMotor motor = new JointMotor();
            motor.targetVelocity = hp * 2000 + turn * 300;
            motor.force = 2000;
            wheel.motor = motor;
        }
    }*/

