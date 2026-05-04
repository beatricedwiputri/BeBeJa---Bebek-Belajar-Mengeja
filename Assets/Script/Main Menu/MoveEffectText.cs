using UnityEngine;

public class MoveEffectText : MonoBehaviour
{
    public float scaleSpeed = 1f; // Speed of the breathing effect
    public float maxScale = 1.2f; // Maximum scale of the object during breathing

    private Vector3 initialScale;
    private bool isBreathingIn = true;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        // Calculate the target scale based on whether breathing in or out
        float targetScale = isBreathingIn ? maxScale : 1f;

        // Smoothly lerp towards the target scale
        float newScale = Mathf.Lerp(transform.localScale.x, targetScale, Time.deltaTime * scaleSpeed);
        transform.localScale = new Vector3(newScale, newScale, newScale);

        // Check if almost at the target scale
        if (Mathf.Abs(transform.localScale.x - targetScale) < 0.01f)
        {
            // Toggle breathing direction
            isBreathingIn = !isBreathingIn;
        }
    }
}
