using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip musicClip; // Assign the music clip through the Inspector

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.Play();
    }
}
