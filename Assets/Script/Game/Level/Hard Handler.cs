using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardHandler : MonoBehaviour
{
    public Button hardButton;

    void Start()
    {
        hardButton.onClick.AddListener(playHard);
    }


    private void playHard()
    {
        NewGame.Hard();
    }
}
