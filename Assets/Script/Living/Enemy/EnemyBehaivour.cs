using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyBehaivor : BaseBehaivour
{
    [SerializeField]
    private float       radius;


    private GameObject  itemManager;
    private ItemManager actionItemManager;

    private GameObject  player;

    private float lastAttackTime;

    private IState.Id state
    {
        get => (( IState )data ).State;
        set => (( IState )data ).State = value;
    }

    private float attackDelay
    {
        get => (( IBehaivour )data ).AttackDelay;
    }

    private Vector2 direction
    {
        get => (( IMovementData )data ).Direction; 
        set => (( IMovementData )data ).Direction = value;
    }

    new private void Awake()
    {
        base.Awake();
        itemManager =       GameObject.FindGameObjectWithTag( "ItemManager" );
        actionItemManager = itemManager.GetComponent<ItemManager>();
    }

    protected override void dead()
    {
        actionItemManager.dropItem( transform.position );
        base.dead();
    }
    private void detectPlayer()
    {
        if ( state == IState.Id.startAttack || state == IState.Id.delayAttack )
        {
            return;
        }

        player =                    null;
        Collider2D[] colliders =    Physics2D.OverlapCircleAll( transform.position, radius );

        foreach( var collider in colliders )
        {
            if ( collider.gameObject.CompareTag( "Player" ))
            {
                player =    collider.gameObject;
                state =     IState.Id.Aggresive;
                break;
            }
        }
        if  ( player.IsUnityNull() ) 
        {
            state = IState.Id.Idle;
        }
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        detectPlayer();
        setDirection();

        switch ( state )
        {
            case IState.Id.startAttack:
                state =             IState.Id.delayAttack;
                break;
            case IState.Id.delayAttack:
                if ( Time.unscaledTime - lastAttackTime > attackDelay  )
                {
                    lastAttackTime =    Time.unscaledTime;
                    state =             IState.Id.Idle;
                }
                break;
        }

        if ( state == IState.Id.startAttack )
        {

        }

        if ( state == IState.Id.delayAttack )
        {

        }
    }

    private void setDirection()
    {
        if ( state != IState.Id.Aggresive )
        {
            direction = Vector2.zero;
            return;
        }

        direction = ( player.transform.position - transform.position ).normalized;
    }

}
