using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject  player;

    [SerializeField]
    private float       distanceFromCenter;
    private Vector3     offset;
    [SerializeField]
    private Rect        borders;

    private float       halfHeight;
    private float       halfWidth;

    void Awake()
    {
        transform.position =    player.transform.position + new Vector3( 0, 0, -10 );
        halfHeight =            Camera.main.orthographicSize;
        halfWidth =             Camera.main.aspect * halfHeight;    
    }

    private void clampToBounds()
    {
        var cameraPosition = transform.position;

        if ( cameraPosition.x - halfWidth < borders.x )
        {
            cameraPosition.x = borders.x + halfWidth;
        }
        if ( cameraPosition.x + halfWidth > borders.x + borders.width )
        {
            cameraPosition.x = borders.x + borders.width - halfWidth;
        }
        if ( cameraPosition.y - halfHeight < borders.y )
        {
            cameraPosition.y = borders.y + halfHeight;
        }
        if ( cameraPosition.y + halfHeight > borders.y + borders.height )
        {
            cameraPosition.y = borders.y + borders.height - halfHeight;
        }

        transform.position = cameraPosition;
    }

    private void positionRelativeToPlayer()
    {
        var playerPosition =    player.transform.position;
        var nowOffset =         transform.position - playerPosition;

        if ((( Vector2 )nowOffset ).sqrMagnitude > Mathf.Pow( distanceFromCenter, 2 ))
        {
            transform.position = playerPosition + offset;
        }
        else
        {
            offset = transform.position - playerPosition;
        }
    }

    private void LateUpdate()
    {
        positionRelativeToPlayer();
        clampToBounds();
    }
}
