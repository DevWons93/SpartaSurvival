using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    [SerializeField] private int damage = 50;
    [SerializeField] Vector3 startPos;

    private void Start()
    {
        startPos = transform.position + Vector3.up * 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<IDamagable>()?.TakePhysicalDamage(damage);        
           
        gameObject.SetActive(false);
    }

    public void ResetPos()
    {
        gameObject.transform.position = startPos;
    }
}
