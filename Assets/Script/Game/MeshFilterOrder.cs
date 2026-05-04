using UnityEngine;

public class SetMeshOrderInLayer : MonoBehaviour
{
    public int orderInLayer = -1; // Desired order in layer

    void Start()
    {
        // Get the MeshRenderer component attached to the GameObject
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            // Set the sorting order
            meshRenderer.sortingOrder = orderInLayer;

            // Optionally, set the sorting layer name if needed
            // meshRenderer.sortingLayerName = "YourSortingLayer"; // Uncomment and set your sorting layer name if needed
        }
        else
        {
            Debug.LogError("MeshRenderer component not found on this GameObject.");
        }
    }
}
