using UnityEngine;
using UnityEngine.UI;

public class Level5UIHandler : MonoBehaviour
{
    public Button button; 

    private void Start()
    {
        button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        Level5.Instance.MulaiMudah();
    }
}
