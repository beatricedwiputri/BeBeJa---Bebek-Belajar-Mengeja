using System.Collections.Generic;
using UnityEngine;

public class LetterSpawnerHard : MonoBehaviour
{
    public float spawnRate = 3f;
    private float nextSpawnTime;
    public PrefabManager prefabManager; 
    public string word;
    private List<char> shuffledLetters = new List<char>();
    private int currentLetterIndex = 0;
    public int randomLetterInterval = 2; 

    void Start()
    {
        if (!WordManager.isWordSet())
        {
            GameManager.instance.GameOver();
        }
        word = WordManager.getWord(); 
        ShuffleLetters();
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

    void SpawnLetterEasy()
    {
        char requiredLetter = shuffledLetters[currentLetterIndex];
        SpawnLetterPrefab(requiredLetter);
    }

    void SpawnReqLetter(){
        char letter = word[currentLetterIndex];
        SpawnLetterPrefab(letter);
    }

    void SpawnLetter()
    {
        int random = Random.Range(0,10);
        if (random > 6)
        {
            char randomLetter = GetRandomLetter();
            SpawnLetterPrefab(randomLetter);
        } else if (random < 6) {
            SpawnLetterEasy();
        } else {
            SpawnReqLetter(); 
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

    char GetRandomLetter()
    {
        return (char)('A' + Random.Range(0, 26));
    }
}
