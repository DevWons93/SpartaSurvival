using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPad : Pad
{    
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<MovingPoint> mpList;
    private Queue<MovingPoint> moveQueue;

    private BoxCollider collider;
    
    private Vector3 destinationPos;
    private Vector3 direction;
    private bool isPlayerOnPad;
    private Transform child;
    
    
    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        
        moveQueue = new Queue<MovingPoint>();
        foreach(MovingPoint mp in mpList)
        {
            moveQueue.Enqueue(mp);
        }

        UpdateNextDestination();
    }

    private void Update()
    {
        CheckPlayerOnPad();
        if (transform.position == destinationPos)
        {
            UpdateNextDestination();
        }
        transform.position = Vector3.MoveTowards(transform.position, destinationPos, moveSpeed * Time.deltaTime);
    }    

    private void UpdateNextDestination()
    {
        MovingPoint mp = moveQueue.Dequeue();
        destinationPos = mp.nextPos;
        direction = (mp.nextPos - mp.startPos).normalized;
        moveQueue.Enqueue(mp);
    }

    private bool CheckPlayerOnPad()
    {
        float size = collider.bounds.size.x;
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, new Vector3(size / 2, 0f, size / 2), Vector3.up, out hit, Quaternion.identity, 5f, LayerMask.GetMask("Player")))
        {
            if(!isPlayerOnPad)
            {
                isPlayerOnPad = true;
                child = hit.collider.gameObject.transform;
                child.SetParent(transform);
            }            
            return true;
        }

        if (isPlayerOnPad) child.transform.SetParent(null);
        isPlayerOnPad = false;
        return false;
    }
}
