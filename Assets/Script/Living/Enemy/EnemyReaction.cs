using UnityEngine;

public class EnemyReaction : BaseReaction
{
    const float MULT_BOUNCE =   0.2F;
    const float BULLET_DAMAGE = 10F;

    EnemyData   data;
    Rigidbody2D rb;

    private float health
    {
        get => (( IHealthData )data ).Health;
        set => (( IHealthData )data ).Health = value;
    }

    private IState.Id state
    {
        get => (( IState )data ).State;
        set => (( IState )data ).State = value;
    }

    private void Awake()
    {
        rb =    GetComponent<Rigidbody2D>();
        data =  GetComponent<EnemyData>();
    }
    override protected void reactionToPlayer( GameObject player )
    {
        if ( state == IState.Id.startAttack || state == IState.Id.delayAttack )
        {
            return;
        }

        Vector2 direction = ( transform.position - player.transform.position ).normalized;
        rb.transform.Translate( direction * MULT_BOUNCE );
        state = IState.Id.startAttack;
    }

    override protected void reactionToBullet( GameObject bullet )
    {
        bullet.SetActive( false );
        health -= BULLET_DAMAGE;
    }
}
