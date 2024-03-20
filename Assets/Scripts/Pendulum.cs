using UnityEngine;

public class SwingingObject : MonoBehaviour
{
  [SerializeField] private float swingSpeed = 2.0f;
  [SerializeField] private float maxSwingAngle = 30.0f;  // Optional: Limit swing

  public float currentAngle = 0.0f;

  void Update()
  {
    currentAngle = Mathf.Sin(Time.time * swingSpeed) * maxSwingAngle;
    Debug.Log(currentAngle);
    transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
  }
}
