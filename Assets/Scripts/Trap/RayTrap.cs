using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTrap : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject fallObject;

    private Ray ray = new Ray();
    private float rayDistance;

    private void Start()
    {
        ray.origin = startPoint.position + Vector3.up;
        ray.direction = endPoint.position + Vector3.up - ray.origin;
        rayDistance = (endPoint.position - startPoint.position).magnitude;
    }

    private void Update()
    {
        if (CheckRayCatch() && !fallObject.activeInHierarchy)
        {
            fallObject.GetComponent<FallingTrap>().ResetPos();
            fallObject.SetActive(true);
        }
    }

    private bool CheckRayCatch()
    {
        Debug.DrawRay(startPoint.position + Vector3.up, ray.direction * rayDistance, Color.red);
        return Physics.Raycast(ray, rayDistance, LayerMask.GetMask("Player"));        
    }
}
