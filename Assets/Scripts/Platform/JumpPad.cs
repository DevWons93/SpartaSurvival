using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : Pad
{
    [SerializeField] private float jumpPower;
    
    private void OnTriggerEnter(Collider other)
    {
        if ((1 << other.gameObject.layer & interactLayer) > 0)
        {
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }    
}
