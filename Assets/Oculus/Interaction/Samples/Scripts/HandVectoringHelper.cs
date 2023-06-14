using Oculus.Interaction.HandGrab;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HandVectoringHelper: MonoBehaviour
{
    [SerializeField] private HandGrabInteractor leftHand;
    [SerializeField] protected HandGrabInteractor rightHand;

    private int leftHandIdentifier;
    private int rightHandIdentifier;

    private float velocity;
    private Vector3 direction;

    public int LeftHandIdentifer { get { return leftHandIdentifier; } }
    public int RightHandIdentifer { get { return rightHandIdentifier; } }

    private void Start()
    {
        leftHandIdentifier = leftHand.Identifier;
        rightHandIdentifier = rightHand.Identifier;
    }

    public Tuple<float, Vector3> GetVelocityDirection(int handID, Transform objectTransform)
    {

        if (handID == leftHandIdentifier)
        {
           velocity = leftHand.VelocityCalculator.CalculateThrowVelocity(objectTransform).LinearVelocity.magnitude;
           direction = leftHand.VelocityCalculator.CalculateThrowVelocity(objectTransform).LinearVelocity.normalized;

        }
        else
        {
            velocity = rightHand.VelocityCalculator.CalculateThrowVelocity(objectTransform).LinearVelocity.magnitude;
            direction = rightHand.VelocityCalculator.CalculateThrowVelocity(objectTransform).LinearVelocity.normalized;
        }

        return new Tuple<float, Vector3> (velocity, direction);
    }
    
}
