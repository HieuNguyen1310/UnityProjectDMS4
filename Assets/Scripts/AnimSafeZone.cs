using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneAnim : MonoBehaviour
{
    public float speed = 2.0f; // Adjust movement speed
    public float moveDistance = 5.0f; // Adjust movement distance (distance per axis)

    public bool left;

    private Vector3 startPosition;
    private bool moveUp = true; // Flag to control movement direction

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (left == true) 
        {
            float targetX = startPosition.x + -1*Mathf.PingPong(Time.time * speed, moveDistance);
            float targetY = startPosition.y + (moveUp ? Mathf.PingPong(Time.time * speed, moveDistance) : -Mathf.PingPong(Time.time * speed, moveDistance));

            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
        else
        {
            float targetX = startPosition.x + Mathf.PingPong(Time.time * speed, moveDistance);
            float targetY = startPosition.y + (moveUp ? Mathf.PingPong(Time.time * speed, moveDistance) : -Mathf.PingPong(Time.time * speed, moveDistance));

            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }

        // Change direction at movement boundaries
        if (Mathf.Abs(transform.position.x - startPosition.x) >= moveDistance)
        {
            moveUp = !moveUp;
        }
    }
}
