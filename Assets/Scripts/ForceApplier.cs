using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForceApplier : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 direction = transform.forward;
            _rigidBody.AddForce(direction * _force);
        }
    }
}
