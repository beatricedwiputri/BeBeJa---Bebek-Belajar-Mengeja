using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public Sprite[] normalSprites;
    public Sprite[] duckingSprites;
    private SpriteRenderer spriteRenderer;
    private int frame;
    private bool isDucking = false;
    private bool isPaused = false;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        if (isPaused) return;

        frame++;

        Sprite[] currentSprites = isDucking ? duckingSprites : normalSprites;

        if (frame >= currentSprites.Length)
        {
            frame = 0;
        }

        if (frame >= 0 && frame < currentSprites.Length)
        {
            spriteRenderer.sprite = currentSprites[frame];
        }

        Invoke(nameof(Animate), 1f / GameManager.instance.gameSpeed);
    }

    public void Duck()
    {
        isDucking = true;
        frame = 0; // Reset frame for smooth transition to ducking sprites
        CancelInvoke(nameof(Animate));
        Invoke(nameof(Animate), 0f); // Start animation immediately with ducking sprites
    }

    public void StandUp()
    {
        isDucking = false;
        frame = 0; // Reset frame for smooth transition to normal sprites
        CancelInvoke(nameof(Animate));
        Invoke(nameof(Animate), 0f); // Start animation immediately with normal sprites
    }

    public void PauseAnimation()
    {
        isPaused = true;
    }

    public void ResumeAnimation()
    {
        isPaused = false;
        Invoke(nameof(Animate), 0f); // Resume animation immediately
    }
}
