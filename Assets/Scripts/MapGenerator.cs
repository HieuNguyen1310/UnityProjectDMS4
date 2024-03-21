using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class MapGenerator : MonoBehaviour
// {
//     // Start is called before the first frame update
  
//     public GameObject[] Spawnables;
//     public Vector2 BottomLeft, TopRight;
//     public int SpawnablesCount;


//     void Start()
//     {
//         for (int i = 0; i < SpawnablesCount; i++) 
//         {
//             int SpawnablesArrayIndex = Random.Range(0, Spawnables.Length);
//             Vector2 pos = new Vector2(x:Random.Range(BottomLeft.x,TopRight.x),y:Random.Range(BottomLeft.y,TopRight.y));
//             GameObject g = Instantiate(Spawnables[SpawnablesArrayIndex], (Vector3)pos, Quaternion.identity);
//             g.transform.parent = transform;
//         }
//     }
// }

public class MapGenerator : MonoBehaviour
{
    public GameObject[] Spawnables;
    public Vector2 BottomLeft, TopRight;
    public int SpawnablesCount;
    public float MinDistance; // Minimum distance between objects
    
    void Start()
    {
        List<GameObject> spawnedObjects = new List<GameObject>(); // Keep track of spawned objects

        for (int i = 0; i < SpawnablesCount; i++)
        {
            bool validPosition = false;
            Vector2 pos = Vector2.zero;


            while (!validPosition)
            {
                pos = new Vector2(Random.Range(BottomLeft.x, TopRight.x), Random.Range(BottomLeft.y, TopRight.y));
                validPosition = true; // Assume valid initially

                // Check distance against all spawned objects
                foreach (GameObject spawnedObject in spawnedObjects)
                {
                    float distance = Vector2.Distance(pos, spawnedObject.transform.position);
                    if (distance < MinDistance)
                    {
                        validPosition = false; // Position too close, try again
                        break;
                    }
                }
            }

            GameObject g = Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], (Vector3)pos, Quaternion.identity);
            g.transform.parent = transform;
            spawnedObjects.Add(g); // Add spawned object to the list
        }
    }
}


