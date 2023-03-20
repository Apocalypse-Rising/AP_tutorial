using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceText : MonoBehaviour
{
    public GameObject targetObject; // the object to check for proximity
    public float proximityDistance = 2f; // the distance at which to trigger the position change
    public float newPositionZ = 5f; // the new z position for the object
    
    void Update()
    {
        // calculate the distance between this object and the target object
        float distance_b = targetObject.transform.position.y;
        float distance_a = transform.position.y-proximityDistance;

        // if the distance is less than or equal to the proximity distance, change the object's position
        if (distance_b >=  distance_a)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
        }
    }
}
