using UnityEngine;

// Allow player to release grabbed objects and place them at foot position, based on facing direction

public class GrabReleaser : MonoBehaviour
{
    public Transform playerTransform;
    public SpriteRenderer playerSprite;
    public float sideOffset = 1f;

    public void ReleaseAndPlaceObject()
    {
        foreach (Transform child in transform)
        {
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();

            // Zero out all velocity
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }

            // Place at player's foot, left or right depending on facing
            float direction = playerSprite.flipX ? -1f : 1f;
            child.position = new Vector3(
                playerTransform.position.x + (sideOffset * direction),
                playerTransform.position.y,
                0f
            );

            // Detach
            child.parent = null;
        }
    }
}