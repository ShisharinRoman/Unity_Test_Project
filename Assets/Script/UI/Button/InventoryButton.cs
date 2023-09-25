using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    private const float   PRESS_DELAY = 0.5F;

    [SerializeField]
    private GameObject  inventory;

    private Button      button;
    private float       lastPress;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener( OnPressed );
    }

    private void OnPressed()
    {
        if ( lastPress + PRESS_DELAY > Time.unscaledTime )
        {
            return;
        }
        inventory.SetActive( !inventory.activeSelf );
        lastPress = Time.unscaledTime;
    }
}
