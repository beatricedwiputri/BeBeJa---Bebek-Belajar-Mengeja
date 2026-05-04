using UnityEngine;
using UnityEngine.UI;

public class Level1UIHandler : MonoBehaviour
{
    public Button button; 

    private void Start()
    {
        button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        Level1.Instance.MulaiMudah();
    }
}
