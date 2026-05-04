using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TogglePlay);
    }

    private void TogglePlay()
    {
        GameManager.instance.PlayGame();
    }
}
