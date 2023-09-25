using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int MAX_SLOT_IN_ROW =     7;
    private const int LINE_WIDTH =          2;
    private const int SIZE_ITEM_ICON =      26;
    private const int START_OFFSET_X =      -84;
    private const int START_OFFSET_Y =      28;

    [SerializeField]
    private int maxSlots;

    [SerializeField]
    private ItemDatabase    itemDatabase;

    [SerializeField]
    private GameObject      prefabItemIcon;

    [SerializeField]
    private GameObject      joystick;

    [SerializeField]
    private GameObject      fireButton;

    [SerializeField]
    private GameObject      deleteButton;

    private GameObject      player;
    private IInventoryData  dataPlayer;
    private int             deleteType;

    private ObjectPool      slots;

    private bool            isInventoryShowed;

    private void Awake()
    {
        player =        GameObject.FindGameObjectWithTag( "Player" );
        dataPlayer =    player.GetComponent<IInventoryData>();
        slots =         new ObjectPool( prefabItemIcon, maxSlots );
        slots.setParent( transform );
    }

    private void show()
    {
        int numbSlots = 0;

        foreach( var item in dataPlayer.Items )
        {
            if ( item.Value == 0 )
            {
                continue;
            }

            var nowSlot =               slots.getObjectFromPool();
            Vector2 positionNowSlot =   new Vector2
                (
                START_OFFSET_X + ( SIZE_ITEM_ICON + LINE_WIDTH ) * ( numbSlots % MAX_SLOT_IN_ROW ),
                START_OFFSET_Y + ( SIZE_ITEM_ICON + LINE_WIDTH ) * ( numbSlots / MAX_SLOT_IN_ROW )
                );
            nowSlot.transform.localPosition =   positionNowSlot;
            nowSlot.transform.localScale =      Vector3.one;

            var actionNowSlot =         nowSlot.GetComponent<InventoryIcon>();
            actionNowSlot.Icon =        itemDatabase.itemData[item.Key].icon;
            actionNowSlot.Quantity =    item.Value;
            actionNowSlot.Type =        item.Key;
            numbSlots++;
        }
    }

    private void OnEnable()
    {
        deleteButton.SetActive( false );
        joystick.SetActive( false );
        fireButton.SetActive( false );
        isInventoryShowed = false;
    }

    private void OnDisable()
    {
        joystick.SetActive( true );
        fireButton.SetActive( true );
        slots?.clear();
    }

    private void Update()
    {
        if ( !isInventoryShowed )
        {
            show();
            isInventoryShowed = true;
        }
    }

    public void selectRemoveItem( int type )
    {
        deleteType = type;
        deleteButton.SetActive( true );
    }

    public void deleteItem()
    {
        dataPlayer.Items.Remove( deleteType );
        deleteButton.SetActive ( false );
        slots.clear();
        isInventoryShowed = false;
    }
}
