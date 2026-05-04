using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public List<GameObject> letterPrefabs;
    public GameObject GetLetterPrefab(char letter)
    {
        
        foreach (GameObject prefab in letterPrefabs)
        {
            int batuAwan = Random.Range(0,3);
            if (batuAwan == 1)
            {
                if (prefab.name == letter + "_batu1")
                {
                    return prefab;
                }
            } else if (batuAwan == 0)
            {
                if (prefab.name == letter + "_batu2")
                {
                    return prefab;
                }
            } else
            {
                if ( prefab.name == letter + "_awan")
                {
                    return prefab;
                }
            }
        }
        return null;
    }
}
