using UnityEngine;

public class BebekGerakMenu : MonoBehaviour
{
    private float rightEdge;
    private Vector3 direction;

    private void Start()
    {
        
        rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x + 2f;
    }
    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        transform.position += Vector3.right * 3f * Time.deltaTime;

        if (transform.position.x > rightEdge)
        {
            Destroy(gameObject);
        }
    }
}
