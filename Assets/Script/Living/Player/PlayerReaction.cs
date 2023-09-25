using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerReaction : BaseReaction
{
    const float ENEMY_DAMAGE = 10F;

    private IHealthData     data;
    private PlayerInventory  inventory;
    private float health
    {
        get =>  data.Health;
        set =>  data.Health = value;
    }

    private void Awake()
    {
        data =      GetComponent<IHealthData>();
        inventory = GetComponent<PlayerInventory>();
    }

    protected override void reactionToItem( GameObject item )
    {
        var actionItem = item.GetComponent<Item>();
        inventory.addItem( actionItem.Data.type, actionItem.Qantity );
        item.SetActive( false );
    }
    protected override void reactionToEnemy( GameObject enemy )
    {
        health -= ENEMY_DAMAGE;
    }
}
