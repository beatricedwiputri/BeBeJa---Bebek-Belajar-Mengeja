using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{

    private Button button;
    private UnityEngine.SceneManagement.Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        button = GetComponent<Button>();
        button.onClick.AddListener(TogglePlay);
    }

    private void TogglePlay()
    {
        GameManager.instance.Restart(scene.name);
    }
}
