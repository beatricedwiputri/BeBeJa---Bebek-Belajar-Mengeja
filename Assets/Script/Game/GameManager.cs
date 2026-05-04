using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrement = 0.01f;
    public float gameSpeed { get; private set; }
    private float currentGameSpeed;
    private bool isPaused = false;
    private Player player;
    private Spawner spawner;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        NewGame();
    }

    private void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        gameSpeed = initialGameSpeed;
    }

    private void Update()
    {
        if (!isPaused)
        {
            gameSpeed += gameSpeedIncrement * Time.deltaTime;
        }
    }

    public void GameOver()
    {
        WordManager.delWord();
        SceneLoader.LoadScene("MainMenu");
    }

    public void Restart(string sceneName)
    {
        SceneLoader.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            currentGameSpeed = gameSpeed;
            gameSpeed = 0;
            player.GetComponent<PlayerAnimate>().PauseAnimation();
        }
    }

    public void PlayGame()
    {
        if (isPaused)
        {
            isPaused = false;
            gameSpeed = currentGameSpeed;
            player.GetComponent<PlayerAnimate>().ResumeAnimation();
        }
    }

    public bool isPause(){
        return isPaused;
    }
}
