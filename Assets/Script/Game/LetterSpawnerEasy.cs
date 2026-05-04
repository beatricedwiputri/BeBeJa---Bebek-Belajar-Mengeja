using System.Collections.Generic;
using UnityEngine;

public class LetterSpawnerEasy : MonoBehaviour
{
    public float spawnRate = 3f;
    private float nextSpawnTime;
    public string word;
    private List<char> shuffledLetters = new List<char>();
    private int currentLetterIndex = 0;
    public int randomLetterInterval = 0; 
    public PrefabManager prefabManager; 

    private Player player; 
    
    
    void Start()
    {
        if (!WordManager.isWordSet())
        {
            GameManager.instance.GameOver();
        }
        word = WordManager.getWord(); 
        ShuffleLetters();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (!GameManager.instance.isPause())
        {
            if (Time.time > nextSpawnTime)
            {
                SpawnLetter();
                nextSpawnTime = Time.time + spawnRate;
            }

            if (spawnRate >= 1){
                spawnRate -= GameManager.instance.gameSpeedIncrement * Time.deltaTime;
            }

            int newIndex = player.getCurrentLetterIndex();

            if (newIndex != currentLetterIndex)
            {
                currentLetterIndex = newIndex;
            }
        }
    }

    void ShuffleLetters()
    {
        List<char> letters = new List<char>(word.ToCharArray());
        while (letters.Count > 0)
        {
            int index = Random.Range(0, letters.Count);
            shuffledLetters.Add(letters[index]);
            letters.RemoveAt(index);
        }
    }

    void SpawnLetter()
    {
        if (randomLetterInterval < shuffledLetters.Count)
        {
            char requiredLetter = shuffledLetters[randomLetterInterval];
            SpawnLetterPrefab(requiredLetter);
            randomLetterInterval++;
        }

        if (randomLetterInterval >= shuffledLetters.Count)
        {
            randomLetterInterval = 0;
            ShuffleLetters();
        }
        
    }

    void SpawnLetterPrefab(char letter)
    {
        GameObject letterPrefab = prefabManager.GetLetterPrefab(letter); 
        if (letterPrefab != null)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, letterPrefab.transform.position.y); 
            Instantiate(letterPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
