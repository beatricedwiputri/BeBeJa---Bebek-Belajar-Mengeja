using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{

    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            SceneLoader.LoadScene("MainMenu");
        }
    }
}
