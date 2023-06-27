using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDropRespawn : MonoBehaviour
{
    [SerializeField]
    private float _yThresholdForRespawn;


    // cached starting transform
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private Vector3 _initialScale;

    private Rigidbody _rigidBody;

    protected virtual void OnEnable()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _initialScale = transform.localScale;
        _rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        if (transform.position.y < _yThresholdForRespawn)
        {
            transform.position = _initialPosition;
            transform.rotation = _initialRotation;
            transform.localScale = _initialScale;

            if (_rigidBody)
            {
                _rigidBody.velocity = Vector3.zero;
                _rigidBody.angularVelocity = Vector3.zero;
            }


        }
    }
}

