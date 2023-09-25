using UnityEngine;

public class PlayerAnimation : BaseAnimation
{
    [SerializeField]
    GameObject      arm;

    private float angleArm
    {
        get => (( IFireData )data ).AngleFire;
    }

    protected override void flip()
    {
        Vector3 newScale = transform.localScale;

        if ((angleArm > 90F || angleArm < 90F && angleArm != 0) || (direction.x < 0 && angleArm == 0))
        {
            newScale.x = -1;
        }
        if ((angleArm < 90F && angleArm > -90F && angleArm != 0) || (direction.x > 0 && angleArm == 0))
        {
            newScale.x = 1;
        }

        transform.localScale = newScale;
    }

    private void rotateArm()
    {
        float newAngleArm = angleArm;

        if ( transform.localScale.x == -1 && newAngleArm != 0 )
            newAngleArm += 180F;
        arm.transform.eulerAngles = new Vector3( 0, 0, newAngleArm );
    }

    new void Update()
    {
        rotateArm();
        base.Update();
    }
}
