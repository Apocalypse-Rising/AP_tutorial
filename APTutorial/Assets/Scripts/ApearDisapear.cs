using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApearDisapear : MonoBehaviour
{
    public float moveDistance = 3.0f; // The distance the object will move
    public float moveDuration = 1.0f; // The time it takes for the object to move

    private int numMoves = 0; // The number of times the object has moved
    private Vector3 startPosition; // The object's starting position
    private Vector3 endPosition; // The object's ending position
    private float currentTime = 0.0f; // The current time elapsed since the last move

    void Start()
    {
        // Save the object's starting position
        startPosition = transform.position;

        // Calculate the object's first ending position
        endPosition = startPosition + new Vector3(0.0f, 0.0f, moveDistance);
    }

    void Update()
    {
        // Increment the current time elapsed
        currentTime += Time.deltaTime;

        // Check if it's time to move the object again
        if (currentTime >= moveDuration)
        {
            // Reset the current time elapsed
            currentTime = 0.0f;

            // Move the object to its next position
            transform.position = endPosition;

            // Increment the number of moves
            numMoves++;

            // Calculate the object's next ending position
            if (numMoves < 3)
            {
                endPosition += new Vector3(0.0f, 0.0f, moveDistance);
            }
        }
    }

}
