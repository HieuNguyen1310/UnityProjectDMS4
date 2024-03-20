using UnityEngine;

public class ZoneOpacity : MonoBehaviour
{
    public SpriteRenderer zoneRenderer; // Assign the SpriteRenderer of the zone in Inspector
    public float enterOpacity = 0.4f; // Opacity when player enters (40%)
    public float normalOpacity = 1.0f; // Normal opacity (100%)

    private Collider2D zoneCollider; // Store the zone's collider for efficiency

    void Start()
    {
        zoneCollider = GetComponent<Collider2D>(); // Get the zone's collider
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Check if colliding object is the player
        {
            zoneRenderer.color = new Color(zoneRenderer.color.r, zoneRenderer.color.g, zoneRenderer.color.b, enterOpacity);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Check if exiting object is the player
        {
            zoneRenderer.color = new Color(zoneRenderer.color.r, zoneRenderer.color.g, zoneRenderer.color.b, normalOpacity);
        }
    }
}
