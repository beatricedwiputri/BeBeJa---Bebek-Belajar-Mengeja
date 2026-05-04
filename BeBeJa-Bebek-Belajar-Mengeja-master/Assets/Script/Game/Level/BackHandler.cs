using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackHandler : MonoBehaviour
{
    public Button backButton;
    void Start()
    {
        backButton.onClick.AddListener(delWord);
    }

    private void delWord()
    {
        WordManager.delWord();
    }
}
