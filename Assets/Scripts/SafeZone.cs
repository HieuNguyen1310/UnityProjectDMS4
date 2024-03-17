using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;  // Maximum health points
    public float currentHealth;  // Current health points

    public float DPS;  // Damage per second (outside the trigger zone)
    private bool isInTriggerZone;  // Flag to track player's location

    void Start()
    {
        currentHealth = maxHealth;  // Initialize health at start
        isInTriggerZone = false;  // Initially, player is not in the trigger zone
    }

    void Update()
    {
        // Handle damage based on isInTriggerZone flag
        if (!isInTriggerZone)
        {
            TakeDamage(DPS * Time.deltaTime); // Apply damage outside the trigger zone
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Safe Zone") // Replace with your trigger zone tag
        {
            isInTriggerZone = true;  // Set flag when entering the trigger zone
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Safe Zone") // Replace with your trigger zone tag
        {
            isInTriggerZone = false;  // Reset flag when leaving the trigger zone
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log(currentHealth);

        // Handle health related logic here (e.g., death checks, visual/sound effects)
        if (currentHealth <= 0)
        {
            // Player is dead!
            currentHealth = 0;
            Debug.Log("Player is dead!");
            // Implement your death logic here (e.g., disable movement, play death animation)
        }
    }
}
