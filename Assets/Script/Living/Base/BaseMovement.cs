using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{

    IMovementData       data;
    private Rigidbody2D rb;
    protected Vector2 direction
    {
        get => data.Direction;
        set => data.Direction = value;
    }
    protected float multSpeed
    {
        get => data.MultSpeed;
        set => data.MultSpeed = value;
    }
    protected float speed
    {
        get => data.Speed;
    }

    protected void Awake()
    {
        data =  GetComponent<IMovementData>();
        rb =    GetComponent<Rigidbody2D>(); 
    }

    private void move()
    {
        rb.transform.Translate( direction * multSpeed * speed );
    }

    protected void FixedUpdate()
    {
        move();
    }
}
