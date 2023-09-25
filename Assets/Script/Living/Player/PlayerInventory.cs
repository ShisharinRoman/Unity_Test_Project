using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<int, int> items
    {
        get => data.Items; 
        set => data.Items = value;
    }

    private IInventoryData data; 

    private void Awake()
    {
        data = GetComponent<IInventoryData>();
    }


    public void addItem( int type, int quantity )
    {
        if ( items.ContainsKey( type ))
        {
            items[type] += quantity;
        }
        else
        {
            items.Add( type, quantity );
        }
    }

    public void removeItem( int type )
    {
        items[type] = 0;
    }
}
