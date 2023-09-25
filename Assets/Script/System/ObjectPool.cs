using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObjectPool
{
    private List< GameObject >  objects;
    private int                 size;

    public ObjectPool( GameObject prefab, int sizePool )
    {
        objects =   new List<GameObject>();
        size =      sizePool;

        for ( int i = 0; i < size; i++ )
        {
            var newObject = MonoBehaviour.Instantiate( prefab );
            newObject.SetActive( false );
            objects.Add( newObject );
        }
    }

    public GameObject getObjectFromPool()
    {
        foreach ( var obj in objects )
        {
            if ( !obj.activeSelf )
            {
                obj.SetActive( true );
                return obj;
            }
        }
        return null; // Если все объекты активны
    }

    public void setParent( Transform parent )
    {
        foreach ( var obj in objects )
        {
            obj.transform.SetParent( parent );
        }
    }

    public void clear()
    {
        foreach( var obj in objects )
        {
            obj.SetActive ( false );
        }
    }
}
