using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public TMP_InputField inputField; 
    public Button submitButton1, submitButton2;      
    void Start()
    {
        // Ensure the button has an onClick listener to handle the submission
        submitButton1.onClick.AddListener(HandleSubmitEasy);
        submitButton2.onClick.AddListener(HandleSubmitHard);
    }

    void HandleSubmitEasy()
    {
        string inputText = inputField.text.ToUpper();
        WordManager.setWord(inputText);
        NewGame.Easy();
    }

    void HandleSubmitHard()
    {
        string inputText = inputField.text.ToUpper();
        WordManager.setWord(inputText);
        NewGame.Hard();
    }
}
