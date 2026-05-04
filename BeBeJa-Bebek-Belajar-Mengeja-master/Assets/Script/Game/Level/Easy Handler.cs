using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyHandler : MonoBehaviour
{
    public Button easyButton;
    private void Start()
    {
        easyButton.onClick.AddListener(playEasy);   
    }

    private void playEasy()
    {
        NewGame.Easy();
    }
}
