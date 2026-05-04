using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject targetObject; 
    public Button button;

    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Toggle);
    }

    public void Toggle()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
