using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    private GameObject      target;
    private IFireData       dataFire;
    private IInventoryData  dataInventory;

    [SerializeField]
    private GameObject      bulletSpawner;
    private SpawnerBullet   actionBulletSpawner;

    [SerializeField]
    private GameObject      arm;

    private float           radius
    {
        get => dataFire.RadiusFire;
    }
    private float           angle
    {
        set => dataFire.AngleFire = value;
        get => dataFire.AngleFire;
    }

    private void Awake()
    {
        target =                null;
        dataFire =              GetComponent<IFireData>();
        dataInventory =         GetComponent<IInventoryData>();
        actionBulletSpawner =   bulletSpawner.GetComponent<SpawnerBullet>();
    }

    private void detectEnemy()
    {
        Collider2D[]    collidersEnemy =    Physics2D.OverlapCircleAll( transform.position, radius );
        GameObject      closestEnemy =      null;
        float           minDistance =       float.MaxValue;

        foreach( var colliderEnemy in collidersEnemy ) 
        {
            if ( colliderEnemy.gameObject.CompareTag( "Enemy" ))
            {
                var positionEnemy =     colliderEnemy.transform.position;
                var distanceToEnemy =   Vector2.Distance( positionEnemy, transform.position );

                if ( distanceToEnemy < minDistance )
                {
                    closestEnemy =  colliderEnemy.gameObject;
                    minDistance =   distanceToEnemy;
                }
            }
        }
        target = closestEnemy;
    }

    private void calcAngle()
    {
        if ( target.IsUnityNull() )
        {
            angle = 0;
            return;
        }

        Vector2 newDirection =  ( target.transform.position - transform.position ).normalized;
        angle =                 Mathf.Atan2( newDirection.y, newDirection.x ) * Mathf.Rad2Deg;
    }

    public void Fire()   
    {
        if ( !dataInventory.Items.ContainsKey( 0 ))
        {
            return;
        }

        actionBulletSpawner.Angle = angle;
        actionBulletSpawner.fire();
        dataInventory.Items[0]--;
        if ( dataInventory.Items[0] == 0 )
        {
            dataInventory.Items.Remove( 0 );
        }
    }

    // Update is called once per frame
    void Update()
    {
        detectEnemy();
        calcAngle();
    }
}
