using UnityEngine;
using TMPro;

public class TMPExample : MonoBehaviour
{
    public TMP_Text tmpText; // Reference to the TMP component

    void Start()
    {
        // Set the text
        if (tmpText != null)
        {
            tmpText.text = WordManager.getWord();
        }
        else
        {
            Debug.LogError("TMP_Text component is not assigned.");
        }
    }

    // Example method to update text
    public void UpdateText(string newText)
    {
        if (tmpText != null)
        {
            tmpText.text = newText;
        }
        else
        {
            Debug.LogError("TMP_Text component is not assigned.");
        }
    }
}
