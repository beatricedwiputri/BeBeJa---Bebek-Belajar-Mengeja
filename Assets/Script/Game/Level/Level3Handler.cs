using UnityEngine;
using UnityEngine.UI;

public class Level3UIHandler : MonoBehaviour
{
    public Button button; 

    private void Start()
    {
        button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        Level3.Instance.MulaiMudah();
    }
}
