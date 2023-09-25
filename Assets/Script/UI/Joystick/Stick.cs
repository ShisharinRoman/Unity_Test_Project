using UnityEngine;
using UnityEngine.EventSystems;

public class Stick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    private const float MAX_STICK_DISTANCE =    1.5F;
    private const float LIMIT_TOUCH_DISTANCE =  3F;

    private Vector2         startPosition;
    private float           distance;
    public float Distance
    {
        get => distance;
    }
    private Vector2         direction;
    public Vector2 Direction
    {
        get => direction;
    }

    private void Awake()
    {
        startPosition = transform.parent.position;
    }

    public void OnBeginDrag( PointerEventData eventData )
    {
    }

    public void OnEndDrag( PointerEventData eventData )
    {
        direction = Vector2.zero;
        distance =  0;
    }

    public void OnDrag( PointerEventData eventData )
    {   
        Vector2 touchPosition =     eventData.pointerCurrentRaycast.worldPosition;
        Vector2 delta =             touchPosition - startPosition;

        if ( delta.magnitude >= LIMIT_TOUCH_DISTANCE )
        {
            direction = Vector2.zero;
            distance =  0;
            return;
        }

        Vector2 clampedDelta =      Vector2.ClampMagnitude( delta, MAX_STICK_DISTANCE );
        direction =                 clampedDelta.normalized;
        distance =                  clampedDelta.magnitude;
    }

    public void OnPointerUp( PointerEventData eventData )
    {
        direction = Vector2.zero;
        distance =  0;
    }

    public void Update()
    {
        startPosition =         transform.parent.position;
        transform.position =    startPosition + direction * distance;
    }
}
