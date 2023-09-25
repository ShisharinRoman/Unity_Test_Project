using UnityEngine;
using Unity.VisualScripting;

public class BaseUI : MonoBehaviour
{
    [SerializeField]
    private     GameObject  prefabHealthBar;
    protected   GameObject  healthBar;
    protected   HealthBar   actionHealthBar;
    protected   IHealthData data;

    protected void Awake()
    {
        healthBar =                     Instantiate( prefabHealthBar );
        actionHealthBar =               healthBar.GetComponent<HealthBar>();
        data =                          GetComponent<IHealthData>();
        actionHealthBar.Target =        transform.gameObject;
        actionHealthBar.TargetInfo =    data;
    }

    private void OnDisable()
    {
        if ( healthBar.IsUnityNull() )
        {
            return;
        }
        healthBar.SetActive(false);
    }
    private void OnEnable()
    {
        if (healthBar.IsUnityNull())
        {
            return;
        }
        healthBar.SetActive(true);
    }
}
