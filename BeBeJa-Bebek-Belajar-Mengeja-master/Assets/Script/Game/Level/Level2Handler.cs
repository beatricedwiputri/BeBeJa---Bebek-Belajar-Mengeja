using UnityEngine;
using UnityEngine.UI;

public class Level2UIHandler : MonoBehaviour
{
    public Button button; 

    private void Start()
    {
        button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        Level2.Instance.MulaiMudah();
    }
}
