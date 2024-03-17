 using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the character
    

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
