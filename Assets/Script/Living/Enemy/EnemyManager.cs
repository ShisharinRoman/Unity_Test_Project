using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private int         maxEnemy;

    [SerializeField]
    private Vector2[]           positionSpawn;
    private HashSet<Vector2>    freePositionSpawn;

    [SerializeField]
    private GameObject          prefabEnemy;

    private List<GameObject>    existEnemy;
    private ObjectPool          enemy;

    private void Awake()
    {
        enemy =             new ObjectPool( prefabEnemy, maxEnemy );
        existEnemy =        new List<GameObject>(); 
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        System.Random rand = new System.Random();

        for (int i = 0; i < maxEnemy; i++)
        {
            var nowEmeny = enemy.getObjectFromPool();
            nowEmeny.SetActive( true );
            existEnemy.Add( nowEmeny );
            var randomPosition = positionSpawn[ rand.Next( positionSpawn.Length )];

            while ( IsPointOccupied( randomPosition ))
            {
                randomPosition = positionSpawn[ rand.Next( positionSpawn.Length )];
            }
            nowEmeny.transform.position = randomPosition;
        }
    }

    private bool IsPointOccupied( Vector2 position )
    {
        foreach ( var enemy in existEnemy ) 
        {
            if ( position == ( Vector2 )enemy.transform.position )
            {
                return true;
            }
        }
        return false;
    }
}
