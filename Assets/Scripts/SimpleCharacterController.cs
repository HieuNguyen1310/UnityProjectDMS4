 using UnityEngine;
using UnityEngine.LowLevel;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the character

    public PlayerHealth playerSystem;

    public AudioSource footstepSource; // Reference to the AudioSource
    public float footstepInterval = 0.3f; // Time between footstep sounds (seconds)
    private float nextFootstepTime = 0f; // Tracks time for next sound

    // private float HealthPoint;
    
    // void Start()
    // {
    //     float HealthPoint = playerSystem.currentHealth;
    // }

    // Update is called once per frame
    void Update()
    {
        // Get input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        // Apply the movement to the character's position
        transform.position += movement * speed * Time.deltaTime;

        

        if ( playerSystem.currentHealth <= 0) 
        {
            // moveHorizontal = 0;
            // moveVertical = 0;
            speed = 0;
        }

        // Check if player is moving (consider using your movement script logic here)
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // Player is moving
            if (Time.time >= nextFootstepTime) // Check if enough time has passed
            {
                footstepSource.Play(); // Play the footstep sound
                nextFootstepTime = Time.time + footstepInterval; // Update next sound time
            }
        }
        
    }

    // private void OnTriggerEnter2D(Collider2D collider) 
    // {
    //     Debug.Log("Trigger!");
        
    // }

    // private void OnTriggerStay2D(Collider2D collider) {
    //     Debug.Log("You Still Here");
    //     playerHP -= Time.deltaTime*10;
    //     if (playerHP <= 0) {
    //         playerHP = 0;
    //     }
    //     Debug.Log("HP =" + playerHP);
    // }
 
}
