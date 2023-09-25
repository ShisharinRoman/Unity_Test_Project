using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class SpawnerBullet : MonoBehaviour
{
    [SerializeField]
    private int maxBulletAtOnce;

    [SerializeField]
    private float speedBullet;

    [SerializeField]
    GameObject      player;

    [SerializeField]
    private GameObject prefabBullet;

    private float   angle;
    public float    Angle
    {
        set => angle = value;
    }

    ObjectPool              bullet;

    private void Awake()
    {
        bullet = new ObjectPool( prefabBullet, maxBulletAtOnce );
    }

    public void fire()
    {
        GameObject  nowBullet =         bullet.getObjectFromPool();

        if ( nowBullet.IsUnityNull())
        {
            return;
        }

        Bullet      actionBullet =          nowBullet.GetComponent<Bullet>();
        nowBullet.transform.position =      transform.position;
        nowBullet.transform.rotation =      transform.rotation;
        actionBullet.Direction =            nowBullet.transform.right;
        /*actionBullet.Direction =            new Vector2
            (
            Mathf.Cos( angle  ),
            Mathf.Sin( angle  ) 
            );*/
        actionBullet.Speed =                speedBullet;

        if ( player.transform.localScale.x == 1 )
        {
            actionBullet.MultSpeed = 1;
        }
        else
        {
            actionBullet.MultSpeed = -1;
        }
    }
}
