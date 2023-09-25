using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener( OnPressed );
    }

    private void OnPressed()
    {
        Application.Quit();
    }
}
