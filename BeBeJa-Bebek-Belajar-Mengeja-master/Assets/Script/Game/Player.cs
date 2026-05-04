using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float GRAVITY = 9.81f * 2f;
    public float JUMP = 8f;
    public float DIVE_FORCE = 20f;
    public string ComparedTag = "LetterObs";

    public string word;
    private int currentLetterIndex = 0;
    public int score = 0;
    public int targetScore = 3;
    private bool isGrounded = true;

    private AudioSource[] audioSources;

    public GameObject winner, loser, song; 

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        word = WordManager.getWord();
        audioSources = GetComponents<AudioSource>(); // Initialize audioSources array
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (!GameManager.instance.isPause()){
            direction += Vector3.down * GRAVITY * Time.deltaTime;
            if (character.isGrounded)
            {
                direction = Vector3.down;

                if (!isGrounded)
                {
                    PlaySound(2);
                    isGrounded = true;
                }

                if (Input.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow))
                {
                    direction = Vector3.up * JUMP;
                    isGrounded = false;
                    PlaySound(1);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    direction = Vector3.down * DIVE_FORCE;
                }
            }

            // Move the character
            character.Move(direction * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(ComparedTag))
        {
            char collidedLetter = collision.gameObject.GetComponentInChildren<TextMeshPro>().text[0]; // Get the letter from TMP text
            if (collidedLetter == word[currentLetterIndex])
            {
                // Handle correct letter collision
                Debug.Log("Correct letter: " + collidedLetter);
                Destroy(collision.gameObject);
                
                currentLetterIndex++;
                PlaySound(0);
                if (currentLetterIndex >= word.Length)
                {
                    Debug.Log("Word completed!");
                    score++;
                    currentLetterIndex = 0;
                    if (score == targetScore){
                        if (winner != null)
                        {
                            winner.SetActive(!winner.activeSelf);
                            GameManager.instance.PauseGame();
                            muteSong();
                            PlaySound(3);
                            
                            
                        }
                    } 
                }
            }
            else
            {
                // Handle incorrect letter collision (e.g., game over logic)
                Debug.Log("Incorrect letter: " + collidedLetter);
                if (loser != null)
                {
                    loser.SetActive(!loser.activeSelf);
                    GameManager.instance.PauseGame();
                    muteSong();
                    PlaySound(4);
                    
                }
            }
        }
    }

    public int getCurrentLetterIndex()
    {
        return currentLetterIndex;
    }

    public int getScore(){
        return score;
    }

    public int getTargetScore(){
        return targetScore;
    }

    public void PlaySound(int index)
    {
        if (audioSources != null && index >= 0 && index < audioSources.Length)
        {
            audioSources[index].Play();
        }
        else
        {
            Debug.LogWarning("Invalid audio source index: " + index);
        }
    }

    public void muteSong(){
        AudioSource audioSource = song.GetComponent<AudioSource>();
        audioSource.mute = true;
    }
}
