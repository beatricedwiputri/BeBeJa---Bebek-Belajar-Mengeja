using UnityEngine;
using TMPro;

public class TMPColorChangeScore : MonoBehaviour
{
    public TMP_Text tmpText;
    private string characterHexColor = "EFB634";
    private string defaultCharacterHexColor = "FFFFFF";
    private string currentCharacterHexColor = "070707";
    private string score,newScore,targetScore;

    private Player player; 

    void Start()
    {
        player = FindObjectOfType<Player>(); 
        score = player.getScore().ToString();
        targetScore = player.getTargetScore().ToString();
        UpdateText(); 
    }

    void Update()
    {
        // Check if player or dynamic word has changed
        newScore= player.getScore().ToString();
        if (newScore != score)
        {
            score = newScore;
            UpdateText(); // Update text with new data
        }
    }

    void UpdateText()
    {
        if (tmpText != null)
        {
            string coloredText = "";

            if (score != targetScore)
                {
                for (int i = 0; i < score.Length; i++)
                {
                    coloredText += $"<color=#{defaultCharacterHexColor}>{score[i]}</color>";
                }
            } else {
                for (int i = 0; i < score.Length; i++)
                {
                    coloredText += $"<color=#{characterHexColor}>{score[i]}</color>";
                }
            }

            coloredText += $"<color=#{currentCharacterHexColor}>{"/"}</color>";

            for (int i = 0; i < targetScore.Length; i++)
            {
                coloredText += $"<color=#{characterHexColor}>{targetScore[i]}</color>";
            }

            tmpText.text = coloredText;
        }
        else
        {
            Debug.LogError("TMP_Text component is not assigned.");
        }
    }
}
