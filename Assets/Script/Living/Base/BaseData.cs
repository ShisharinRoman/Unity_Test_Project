using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthData
{
    public float Health { get; set; }
    public float MaxHealth { get; set; }

}
public interface IMovementData
{
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }
    public float MultSpeed { get; set; }

}

public class BaseData : MonoBehaviour, IMovementData, IHealthData
{
    protected float health;
    public float    Health
    {
        get => health;
        set => health = value;
    }
    [SerializeField]
    protected float maxHealth;
    public float    MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    [SerializeField]
    protected float speed;
    public float    Speed
    {
        get => speed;
        set => speed = value;
    }
    protected Vector2   direction;
    public Vector2      Direction
    {
        get => direction;
        set => direction = value;
    }
    protected float multSpeed;
    public float MultSpeed
    {
        get => multSpeed;
        set => multSpeed = value;
    }

    protected void Awake()
    {
        direction = new Vector2();
        health =    MaxHealth;
    }
}
