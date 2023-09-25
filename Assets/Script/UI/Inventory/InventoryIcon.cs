using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryIcon : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject  textBox;

    private TextBox     actionTextBox;
    private Image       image;
    public Sprite       Icon
    {
        set => image.sprite = value;
    }
    private int         quantity;
    public int          Quantity
    {
        set
        {
            quantity = value;
            if ( value < 2 )
            {
                actionTextBox.Text = "";
            }
            else
            {
                actionTextBox.Text = quantity.ToString();
            }
        }
        get => quantity;
    }
    private int         type;
    public int          Type
    {
        set => type = value;
    }
    private void Awake()
    {
        image =                 GetComponent<Image>();
        actionTextBox =         textBox.GetComponent<TextBox>();
        actionTextBox.Target =  transform;
    }

    public void OnPointerDown( PointerEventData eventData )
    {
        var inventory =         transform.parent.gameObject;
        var actionInventory =   inventory.GetComponent<Inventory>();
        actionInventory.selectRemoveItem( type );
    }
}
