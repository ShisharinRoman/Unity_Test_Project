using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private const float     OFFSET_Y = 1.5F;
    private Image           imageFill;

    private GameObject  target;
    public GameObject   Target
    {
        set => target = value;
    }
    private IHealthData targetInfo;
    public IHealthData  TargetInfo
    {
        set => targetInfo = value;
    }

    private void Awake()
    {
        transform.SetParent( FindObjectOfType<Canvas>().transform );
        imageFill = transform.GetChild(0).GetComponent<Image>();
    }

    private void updateHealth()
    {
        imageFill.fillAmount = targetInfo.Health / targetInfo.MaxHealth;
    }

    private void positionOffset()
    {
        transform.position = target.transform.position + new Vector3( 0, OFFSET_Y, 0 );
    }

    private void Update()
    {
        updateHealth();
    }

    private void FixedUpdate()
    {
        positionOffset();
    }
}
