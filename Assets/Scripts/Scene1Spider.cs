using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Spider : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed at which the object spins in a circle

    // Update is called once per frame
    void Update()
    {
        // Rotate the object in a circle slowly
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
