using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public float gameSpeed = 5f; // Adjust this value as needed

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
