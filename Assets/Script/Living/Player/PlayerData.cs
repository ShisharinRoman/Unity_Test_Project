using System.Collections.Generic;
using UnityEngine;
public interface IFireData
{
    public float RadiusFire { get; set; }
    public float AngleFire { get; set; }
}

public interface IInventoryData
{
    public Dictionary<int, int> Items { get; set; }
}
public class PlayerData : BaseData, IFireData, IInventoryData
{
    [SerializeField]
    private GameObject  saveManager;

    [SerializeField]
    private float radiusFire;
    public float RadiusFire
    {
        get => radiusFire;
        set => radiusFire = value;
    }
    private float angleFire;
    public float AngleFire
    {
        get => angleFire;
        set => angleFire = value;
    }

    private Dictionary<int, int> items;
    public Dictionary<int, int> Items
    {
        get => items;
        set => items = value;
    }    

    new private void Awake()
    {
        base.Awake();
        items = new Dictionary<int, int>();
        items.Add(0, 20);
        saveManager.GetComponent<SaveManager>().loadDataFromFile();
    }
}
