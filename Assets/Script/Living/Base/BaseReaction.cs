using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseReaction : MonoBehaviour
{
    virtual protected void reactionToItem( GameObject item )
    {

    }
    virtual protected void reactionToPlayer( GameObject player )
    {

    }
    virtual protected void reactionToEnemy( GameObject enemy )
    {

    }

    virtual protected void reactionToBullet( GameObject bullet )
    {

    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        switch( collision.gameObject.tag )
        {
            case "Player":
                reactionToPlayer( collision.gameObject );
                break;
            case "Enemy":
                reactionToEnemy( collision.gameObject );
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch( collision.gameObject.tag ) 
        {
            case "Bullet":
                reactionToBullet( collision.gameObject );
                break;
            case "Item":
                reactionToItem( collision.gameObject );
                break;
        }
    }
}
