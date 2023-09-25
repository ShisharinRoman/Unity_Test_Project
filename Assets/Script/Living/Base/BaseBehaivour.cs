using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaivour : MonoBehaviour
{
    protected IHealthData data;

    private float health
    {
        get => data.Health;
    }
    protected void Awake()
    {
        data = GetComponent<IHealthData>();
    }

    virtual protected void dead()
    {
        transform.gameObject.SetActive( false );
    }

    protected void Update()
    {
        if ( health  <= 0 )
        {
            dead();
        }
    }
}
