using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaShift : MonoBehaviour
{
    public float speed = 2.0f; // The speed at which the demon moves
    public float distance = 5.0f; // The distance the demon moves left and right
    private Vector2 startPos; // The starting position of the demon
    private bool movingRight = true; // Flag to determine whether the demon is moving right or left


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Store the starting position of the demon

    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = speed * Time.deltaTime;
        float newPos = transform.position.x + (movingRight ? moveAmount : -moveAmount);

        // Check if the demon has reached the edge of its movement range and needs to turn around
        if (Mathf.Abs(newPos - startPos.x) > distance)
        {
            movingRight = !movingRight;

            // Update the animator's boolean parameter based on the demon's movement direction
        }

        // Update the demon's position
        transform.position = new Vector2(newPos, transform.position.y);   
    }
}
