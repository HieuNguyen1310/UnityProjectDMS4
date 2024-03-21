using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;  // Maximum health points
    public float currentHealth;  // Current health points

    // public Color defaultColor; // Player's default color
    // public Color damageColor; // Color to change to when taking damage

    // public Color deadColor; // Color to change to when player dead

    // public spri

    // public Color HealingColor; // Color to change to when player is healing

    public Sprite defaultSprite;

    public Sprite damageSprite;

    public Sprite deadSprite;

    public Sprite healSprite;

    public Slider HP;

    public SpriteRenderer spriteRenderer; // Reference to the player's sprite renderer

    public Rigidbody2D myRigidBody;
    public float DPS;  // Damage per second (outside the trigger zone)

    public float HealPS; // Heal per Sec (Inside the Heal Zone)
    [SerializeField]private bool isInTriggerZone;  // Flag to track player's location
    [SerializeField] private bool isInHealZone = false; // Falg to track player if in Heal Zone

    // public DayNight dayCheck;
    // [SerializeField] private float dayNightValue;

    void Start()
    {
        currentHealth = maxHealth;  // Initialize health at start
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer component
        isInTriggerZone = false;  // Initially, player is not in the trigger zone
        spriteRenderer.sprite = defaultSprite;

        // dayCheck = GetComponent<DayNight>();
    }

    void Update()
    {
        // dayNightValue = dayCheck.ppv.weight;
        // Handle damage based on isInTriggerZone flag
        if (!isInTriggerZone)
        {   
            
            TakeDamage(DPS * Time.deltaTime); // Apply damage outside the trigger zone
            
        }

        if (currentHealth > 0 && currentHealth < maxHealth && isInHealZone == true)
        {
            healPlayer(HealPS * Time.deltaTime);
        }

         // Handle health related logic here (e.g., death checks, visual/sound effects)
        if (currentHealth <= 0)
        {
            // Player is dead!
            currentHealth = 0;
            myRigidBody.velocity = Vector2.zero; //Stop player movement

            spriteRenderer.sprite = deadSprite; //Change player dead color

            Debug.Log("Player is dead!");
            // Implement your death logic here (e.g., disable movement, play death animation)
        }

        if (currentHealth <= maxHealth /4 && currentHealth > 0) 
        {
            spriteRenderer.sprite = damageSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Safe Zone") // Replace with your trigger zone tag
        {
            isInTriggerZone = true;  // Set flag when entering the trigger zone
        }

        if (other.gameObject.tag == "Heal Zone") 
        {
            isInHealZone = true;
            spriteRenderer.sprite = healSprite;
        }
    }

    

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Safe Zone") // Replace with your trigger zone tag
        {
            isInTriggerZone = false;  // Reset flag when leaving the trigger zone
        }

        if (other.gameObject.tag == "Heal Zone") // Replace with your trigger zone tag
        {
            isInHealZone = false;  // Reset flag when leaving the trigger zone
            spriteRenderer.sprite = defaultSprite;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

    }

    public void healPlayer(float heal) {
        currentHealth += heal;
    }
}
