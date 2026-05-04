using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!GameManager.instance.isPause())
        {
            float speed = GameManager.instance.gameSpeed/transform.localScale.x;
            meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
        }
    }
}
