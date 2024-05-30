using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPad : Pad
{    
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<MovingPoint> mpList;
    private Queue<MovingPoint> moveQueue;

    private Rigidbody rigidbody;
    
    private Vector3 destinationPos;
    private Vector3 direction;
    
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
        moveQueue = new Queue<MovingPoint>();
        foreach(MovingPoint mp in mpList)
        {
            moveQueue.Enqueue(mp);
        }

        UpdateNextDestination();
    }

    private void Update()
    {        
        if(transform.position == destinationPos)
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
}
