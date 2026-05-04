using UnityEngine;
using UnityEngine.UI;

public class Level4UIHandler : MonoBehaviour
{
    public Button button; 

    private void Start()
    {
        button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        Level4.Instance.MulaiMudah();
    }
}
