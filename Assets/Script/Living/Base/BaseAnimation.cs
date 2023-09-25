using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimation : MonoBehaviour
{

    protected Animator      animator;
    protected IMovementData data;
    protected Vector2       direction
    {
        get => data.Direction;
    }
    private void Awake()
    {
        animator =  GetComponent<Animator>();
        data =      GetComponent<IMovementData>();
    }

    virtual protected void flip()
    {
        Vector3 newScale = transform.localScale;

        if ( direction.x > 0 )
        {
            newScale.x = 1;
        }
        if ( direction.x < 0 )
        {
            newScale.x = -1;
        }

        transform.localScale = newScale;
    }

    protected void Update()
    {
        flip();
        animator.SetBool( "IsWalking", direction != Vector2.zero );
    }
}
