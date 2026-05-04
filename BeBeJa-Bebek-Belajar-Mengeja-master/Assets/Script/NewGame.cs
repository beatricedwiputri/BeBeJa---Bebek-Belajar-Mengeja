using UnityEngine;
using UnityEngine.SceneManagement;

public static class NewGame
{
    public static void Easy()
    {
        if (WordManager.isWordSet())
        {    
            Debug.Log("Button clicked! Attempting to load scene.");
            SceneLoader.LoadScene("GameEasy");
        }
    }

    public static void Hard()
    {
        if (WordManager.isWordSet())
        {    
            Debug.Log("Button clicked! Attempting to load scene.");
            SceneLoader.LoadScene("GameHard");
        }
    }

    public static void quitGame()
    {
        Application.Quit();
    }
}
