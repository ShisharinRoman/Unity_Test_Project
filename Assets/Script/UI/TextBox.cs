using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{

    private TMP_Text    tmpText;
    private Transform   target;
    public Transform    Target
    {
        get => target;
        set => target = value;
    }
    public string Text
    {
        set => tmpText.text = value;
        get => tmpText.text;
    }
    private void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        transform.position = target.position;
    }
}
