using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(PrefabManager))]
public class PrefabManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PrefabManager prefabManager = (PrefabManager)target;

        if (GUILayout.Button("Auto Assign Prefabs"))
        {
            AutoAssignPrefabs(prefabManager);
        }
    }

    private void AutoAssignPrefabs(PrefabManager prefabManager)
    {
        string[] guids = AssetDatabase.FindAssets("t:Prefab", new[] { "Assets/Prefabs/Game/LetterObstacle" });
        prefabManager.letterPrefabs = new List<GameObject>();

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            prefabManager.letterPrefabs.Add(prefab);
        }

        EditorUtility.SetDirty(prefabManager);
    }
}
