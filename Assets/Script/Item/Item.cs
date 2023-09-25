using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]    
    private GameObject      prefabTextBoxCounter;
    private GameObject      textBoxCounter;
    private TextBox         actionTextBoxCounter;

    private SpriteRenderer  spriteRenderer;
    private ItemData        data;
    public ItemData         Data
    {
        get => data;
        set
        {
            data =                  value;
            spriteRenderer.sprite = value.icon;
        }
    }    

    private int quantity;
    public int Qantity
    {
        set
        {
            quantity = value;
            if ( value < 2 )
            {
                actionTextBoxCounter.Text = "";
            }
            else
            {
                actionTextBoxCounter.Text = quantity.ToString();
            }
        }
        get => quantity;
    }

    private void Awake()
    {
        spriteRenderer =                GetComponent<SpriteRenderer>();
        textBoxCounter =                Instantiate( prefabTextBoxCounter );
        actionTextBoxCounter =          textBoxCounter.GetComponent<TextBox>();
        actionTextBoxCounter.transform.SetParent( FindObjectOfType<Canvas>().transform );
        actionTextBoxCounter.Target =   transform;
    }

    private void OnDisable()
    {
        if ( textBoxCounter.IsUnityNull() )
        {
            return;
        }
        textBoxCounter.SetActive( false );
    }

    private void OnEnable()
    {
        if ( textBoxCounter.IsUnityNull() )
        {
            return;
        }
        textBoxCounter.SetActive( true );
    }
}
