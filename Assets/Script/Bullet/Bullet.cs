using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IMovementData
{
    private Vector2     direction;
    public Vector2      Direction
    {
        get => direction; 
        set => direction = value;
    }
    private float       speed;
    public float        Speed
    {
        get => speed;
        set => speed = value;
    }
    private float       multSpeed;
    public float        MultSpeed
    {
        get => multSpeed;
        set => multSpeed = value;
    }
    
    void move()
    {
        transform.position = ( Vector2 )transform.position + direction * speed * multSpeed;
    }

    private bool IsVisible()
    {
        bool res = true;

        Vector3 positionInWorld = Camera.main.WorldToViewportPoint( transform.position );

        if ( 
            positionInWorld.x < 0 ||
            positionInWorld.x > 1 ||
            positionInWorld.y < 0 ||
            positionInWorld.y > 1 
            ) 
        {
            res = false;
        }

        return res;
    }

    private void FixedUpdate()
    {
        move();

        if ( !IsVisible() )
        {
            transform.gameObject.SetActive( false );
        }
    }

}
