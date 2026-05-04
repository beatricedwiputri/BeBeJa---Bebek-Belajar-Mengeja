using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TogglePause);
    }

    private void TogglePause()
    {
        GameManager.instance.PauseGame();
    }
}
