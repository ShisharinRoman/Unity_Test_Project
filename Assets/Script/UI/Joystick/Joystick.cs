using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    const float         MAX_STICK_DISTANCE = 1.5F;

    [SerializeField]
    private GameObject  stick;
    private Stick       actionStick;

    private Vector2     direction;
    public Vector2      Direction
    {
        get => direction;
    }
    private float       distance;
    public float        Force
    {
        get => distance / MAX_STICK_DISTANCE;
    }
    private bool isPressed;

    private void Awake()
    {
        direction =     new Vector2();
        actionStick =   transform.GetChild(0).GetComponent<Stick>();
    }
    private void Update()
    {
        direction = actionStick.Direction;
        distance =  actionStick.Distance;
    }
}
