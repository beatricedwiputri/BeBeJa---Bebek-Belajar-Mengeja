using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BebekMenuSpawn : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefabs;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;

    public float minSpawnChance = 1f;
    public float maxSpawnChance = 2f;
    private float maxEdge, minEdge;

    private void Start()
    {
        maxEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).y + 10f;
        minEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).y + 7f;
    }

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnChance, maxSpawnChance));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;
        float yPos = Random.Range(minEdge, maxEdge);

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefabs);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnChance, maxSpawnChance));
    }
}
