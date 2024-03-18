using UnityEngine;
using System.Collections;

public class TriggerObjectDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy; // The object to be destroyed on trigger
    [SerializeField] private float minDuration = 5.0f; // Minimum time before destroying (seconds)
    [SerializeField] private float maxDuration = 10.0f; // Maximum time before destroying (seconds)

    

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player") // Replace "Player" with your actual trigger tag
            {
                StartCoroutine(DestroyObject());
                Debug.Log("TOUCH");
            }
        }

        IEnumerator DestroyObject()
        {
            // Determine random delay for object destruction
            float delay = Random.Range(minDuration, maxDuration);

            // Log the chosen delay (optional)
            Debug.Log("Object destruction delayed by: " + delay + " seconds");

            // Wait for the random delay using WaitForSeconds
            yield return new WaitForSeconds(delay);

            // Destroy the target object
            Destroy(objectToDestroy);

            // Optional debug message indicating destruction after the delay
            Debug.Log("Object destroyed!");
        }
    
}
