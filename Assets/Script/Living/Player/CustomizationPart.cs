using UnityEngine;

public class CustomizationPart : MonoBehaviour
{
    protected SpriteRenderer  spriteRenderer;
    [SerializeField]
    protected Sprite[]        sprites;

    private void Awake()
    {
        var rand =              new System.Random();
        spriteRenderer =        GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[ rand.Next( sprites.Length - 1 ) ];
    }
}
