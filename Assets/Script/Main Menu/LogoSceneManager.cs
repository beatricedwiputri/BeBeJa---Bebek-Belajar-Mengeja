using UnityEngine;
using System.Collections;

public class LogoSceneManager : MonoBehaviour
{
    public float displayTime = 3.0f;
    public string nextSceneName ; 

    private void Start()
    {
        StartCoroutine(LogoSequence());
    }

    private IEnumerator LogoSequence()
    {
        yield return new WaitForSeconds(displayTime);
        SceneLoader.LoadScene(nextSceneName);
    }
}
