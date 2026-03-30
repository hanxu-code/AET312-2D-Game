using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [Space]
    [Header("Debug")]
    [Tooltip("Whether or not this script prints information to the debug console.")]
    public bool consoleLog = false;

    public void DestroyObject()
    {
        if (consoleLog) Debug.Log("Destroying object: " + gameObject.name);
        Destroy(gameObject);
    }

    public void DestroyOtherObject(GameObject aObject)
    {
        if (consoleLog) Debug.Log("Destroying object: " + aObject.name);
        PlayerController player = aObject.GetComponent<PlayerController>();
        if(player == null) Destroy(aObject);
        else player.Respawn();
    }

    public void RespawnPlayer()
    {
        PlayerController.instance.Respawn();
    }

    // Allow for destroying static objects
    public void DestroyNearbyStaticObjects()
    {
        // Get the circle collider on this object to know the explosion radius
        CircleCollider2D circle = GetComponent<CircleCollider2D>();
        if (circle == null) return;

        float radius = circle.radius * transform.lossyScale.x;
        Vector2 center = (Vector2)transform.position + circle.offset;

        // Find all colliders within the explosion radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(center, radius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("StaticObject"))
            {
                if (consoleLog) Debug.Log("Destroying static object: " + hit.gameObject.name);
                Destroy(hit.gameObject);
            }
        }
    }

    //
    public void RespawnPlayer2(GameObject aObject)
    {
        PlayerController player = aObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Respawn();
            if (consoleLog) Debug.Log("Respawning player");
        }
    }
}
