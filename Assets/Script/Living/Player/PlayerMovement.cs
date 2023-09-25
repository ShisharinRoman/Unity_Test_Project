using UnityEngine;

public class PlayerMovement : BaseMovement
{
    [SerializeField]
    private GameObject      joystick;
    private Joystick        actionJoystick;

    private new void Awake()
    {
        base.Awake();
        actionJoystick =    joystick.GetComponent<Joystick>();
    }

    private void Update()
    {
        direction = actionJoystick.Direction;
        multSpeed = actionJoystick.Force;
    }

}
