using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : MonoBehaviour
{
    const int MAX_ITEM_AT_ONCE = 5;

    [SerializeField]
    private ItemDatabase itemDatabase;

    [SerializeField]
    private GameObject  prefabItem;
    System.Random       rand;
    private ObjectPool  itemPool;
    private void Awake()
    {
        itemPool =  new ObjectPool( prefabItem, MAX_ITEM_AT_ONCE );
        rand =      new System.Random();
    }

    public void dropItem( Vector2 position )
    {
        var item =                  itemPool.getObjectFromPool();
        var actionItem =            item.GetComponent<Item>();
        item.transform.position =   position;
        var itemData =              itemDatabase.itemData;
        actionItem.Data =           itemData[ rand.Next( itemData.Length )];
        actionItem.Qantity =        rand.Next( 11 ) + 1;
    }
}
