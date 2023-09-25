using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IState
{
    public enum Id
    {
        Idle,
        Aggresive,
        startAttack,
        delayAttack
    }
    public Id State { get; set; }
}

public interface IBehaivour
{
    public float AttackDelay { get; set; }
}

public class EnemyData : BaseData, IState, IBehaivour
{
    private IState.Id   state;
    public IState.Id    State
    {
        get => state;
        set => state = value; 
    }

    [SerializeField]
    private float   attackDelay;
    public float    AttackDelay
    {
        get => attackDelay;
        set => attackDelay = value;
    }

    new void Awake()
    {
        base.Awake();
        state =     IState.Id.Idle;
        multSpeed = 1;
    }
}