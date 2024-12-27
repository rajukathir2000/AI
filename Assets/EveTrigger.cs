using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveTrigger : MonoBehaviour
{
    public float detectionRadius = 10f; // Detection range
    public LayerMask detectionLayer;    // Layer to filter detected objects (e.g., Player layer)

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        // Use Physics.OverlapSphere to detect objects within the detection radius
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        // Check if any objects are detected
        if (detectedObjects.Length > 0)
        {
            Debug.Log("Player detected!");
            foreach (Collider obj in detectedObjects)
            {
                Debug.Log("Detected Object: " + obj.name);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the detection radius in the scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}