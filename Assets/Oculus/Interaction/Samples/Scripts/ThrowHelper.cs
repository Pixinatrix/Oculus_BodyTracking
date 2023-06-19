using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Input;
using Oculus.Interaction.Throw;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHelper : MonoBehaviour
{
    private bool inAir = false;
    private Rigidbody ballRigidBody;

    [SerializeField] private float speed;
    [SerializeField] private HandVectoringHelper handVectorHelper;
    
    private Grabbable grabbable;
    private int handIdentifier;

    private void Awake()
    {
        this.ballRigidBody = GetComponent<Rigidbody>();
        this.inAir = false;
        this.ballRigidBody.interpolation = RigidbodyInterpolation.Interpolate;
        grabbable = GetComponent<Grabbable>();
        grabbable.WhenPointerEventRaised += Grabbable_WhenPointerEventRaised;
    }

    private void Grabbable_WhenPointerEventRaised(PointerEvent obj)
    {
        if (obj.Type == PointerEventType.Select)
            handIdentifier = obj.Identifier; 
    }

    private void SetPhysics(bool usePhysics)
    {
        this.ballRigidBody.useGravity = usePhysics;
        this.ballRigidBody.isKinematic = !usePhysics;
    }

    public void ReleaseBall()
    {
        this.inAir = true;
        SetPhysics(true);
        MaskAndRelease(handVectorHelper.GetVelocityDirection(handIdentifier, this.transform).Item1);
        StartCoroutine(RotateWithVelocity());
    }

    private void MaskAndRelease(float power)
    {
        Collider arrowCollider = GetComponentInChildren<Collider>();
        this.ballRigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        Vector3 force = handVectorHelper.GetVelocityDirection(handIdentifier, this.transform).Item2 * power * speed;
        this.ballRigidBody.AddForce(force, ForceMode.Impulse);
    }

    private IEnumerator RotateWithVelocity()
    {
        yield return new WaitForFixedUpdate();
        while (this.inAir)
        {
            Quaternion newRotation = Quaternion.LookRotation(ballRigidBody.velocity);
            this.transform.rotation = newRotation;
            yield return null;
        }
    }
}
