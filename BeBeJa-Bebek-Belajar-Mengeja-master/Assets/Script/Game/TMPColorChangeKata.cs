using UnityEngine;
using TMPro;

public class TMPColorChange : MonoBehaviour
{
    public TMP_Text tmpText;
    private string dynamicWord;
    private string characterHexColor = "EFB634";
    private string defaultCharacterHexColor = "FFFFFF";
    private string currentCharacterHexColor = "070707";
    private int currentLetterIndex;

    private Player player; // Assuming Player class or script exists and manages current letter index

    void Start()
    {
        dynamicWord = WordManager.getWord(); // Assuming this function retrieves a word dynamically
        player = FindObjectOfType<Player>(); // Assuming Player script is found in scene
        UpdateText(); // Initial update of text
    }

    void Update()
    {
        // Check if player or dynamic word has changed
        int newIndex = player.getCurrentLetterIndex();
        if (newIndex != currentLetterIndex || dynamicWord != WordManager.getWord())
        {
            currentLetterIndex = newIndex;
            dynamicWord = WordManager.getWord(); // Update dynamic word
            UpdateText(); // Update text with new data
        }
    }

    void UpdateText()
    {
        if (tmpText != null)
        {
            string coloredText = "";

            for (int i = 0; i < dynamicWord.Length; i++)
            {
                if (i < currentLetterIndex)
                {
                    coloredText += $"<color=#{characterHexColor}>{dynamicWord[i]}</color>";
                } else if (i == currentLetterIndex)
                {
                    coloredText += $"<color=#{currentCharacterHexColor}>{dynamicWord[i]}</color>";
                } else
                {
                    coloredText += $"<color=#{defaultCharacterHexColor}>{dynamicWord[i]}</color>";
                }
            }

            tmpText.text = coloredText;
        }
        else
        {
            Debug.LogError("TMP_Text component is not assigned.");
        }
    }
}
