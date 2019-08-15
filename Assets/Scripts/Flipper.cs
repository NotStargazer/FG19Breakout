using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Flipper : MonoBehaviour
{
    //Public
    public float flipperSpeed = 1000;
    public float reverseMod = 1f;
    [NonSerialized] public bool isFlipped = false;

    //Private
    HingeJoint2D flipperHinge;
    
    void Awake()
    {
        flipperHinge = GetComponent<HingeJoint2D>();
        Assert.IsNotNull(flipperHinge, "Couldn't find the hinge component on " + gameObject.name);
    }
    private void FixedUpdate()
    {
        if (isFlipped)
        {
            JointMotor2D flipperMotor = flipperHinge.motor;
            flipperMotor.motorSpeed = flipperSpeed;

            flipperHinge.motor = flipperMotor;
        }
        else
        {
            //TODO: Add reverse mod
            JointMotor2D flipperMotor = flipperHinge.motor;
            flipperMotor.motorSpeed = -flipperSpeed;

            flipperHinge.motor = flipperMotor;
        }
    }
}
