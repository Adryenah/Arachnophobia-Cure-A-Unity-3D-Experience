using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRemove : MonoBehaviour
{
    public GameObject prefabToSpawn; // Drag your prefab into this field in the Unity Editor

    private List<GameObject> spawnedObjects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        // Spawn object when pressing the space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }

        // Delete last spawned object when pressing the "x" button
        if (Input.GetKeyDown(KeyCode.X))
        {
            DeleteLastObject();
        }
    }

    void SpawnObject()
    {
        // Instantiate the prefab and store the reference to the spawned object
        GameObject newObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        spawnedObjects.Add(newObject);
    }

    void DeleteLastObject()
    {
        // Check if there are spawned objects
        if (spawnedObjects.Count > 0)
        {
            // Get the last spawned object
            GameObject lastObject = spawnedObjects[spawnedObjects.Count - 1];

            // Remove it from the list
            spawnedObjects.RemoveAt(spawnedObjects.Count - 1);

            // Destroy the last spawned object
            Destroy(lastObject);
        }
    }
}
