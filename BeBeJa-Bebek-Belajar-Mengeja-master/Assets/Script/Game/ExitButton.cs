using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TogglePlay);
    }

    private void TogglePlay()
    {
        GameManager.instance.GameOver();
    }
}
