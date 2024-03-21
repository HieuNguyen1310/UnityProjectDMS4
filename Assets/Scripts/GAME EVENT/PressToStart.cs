using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene loading (optional)

public class PressAnyKeyToStart : MonoBehaviour
{
    // public string nextSceneName; // Name of the scene to load after pressing a key (optional)

    public GameObject StartUI;

    void Update()
    {
        if (Input.anyKey) // Check for any key press
        {
            // if (nextSceneName != "") // If a scene name is provided
            // {
            //     SceneManager.LoadScene(nextSceneName); // Load the next scene
            // }
            // else // If no scene name is provided, assume restarting the current scene
            // {
            //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // }


            StartUI.SetActive(false);

        }
    }
}
