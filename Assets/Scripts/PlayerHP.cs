// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using Unity.VisualScripting;

// public class PlayerHealth : MonoBehaviour
// {
//     public int maxHealth;  // Maximum health points
//     public int currentHealth;  // Current health points

//     public float DPS;
//     private float timer;
//     void Start()
//     {
//         currentHealth = maxHealth;  // Initialize health at start
//     }

//     public void TakeDamage(float damage)
//     {
//         currentHealth -= Mathf.FloorToInt(damage);
        
//         Debug.Log(currentHealth);
//         // Convert damage to integer and subtract

//         // Handle health related logic here (e.g., death checks, visual/sound effects)
//         if (currentHealth <= 0)
//         {
//             // Player is dead!
//             currentHealth = 0;
//             Debug.Log("Player is dead!");
//             // Implement your death logic here (e.g., disable movement, play death animation)
//         }
//     }

//     void OnTriggerStay2D(Collider2D collider)
//     {
//         Debug.Log("Here");
        

//         // if (currentHealth <= maxHealth)
//         // {
//         //     TakeDamage(DPS);
//         //     Debug.Log(currentHealth);
//         // }
//     }

//     void Update()
//     {
        
//     }
// }

