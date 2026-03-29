using UnityEngine;

// Allow player to fling the object based on their facing direction

public class DirectionalFling : MonoBehaviour
{
    public float horizontalForce = 300f;
    public float verticalForce = 400f;

    public SpriteRenderer playerSprite;
    private PhysicsObjectManipulator manipulator;

    void Awake()
    {
        manipulator = GetComponent<PhysicsObjectManipulator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float direction = playerSprite.flipX ? -1f : 1f;
        manipulator.forceToAdd = new Vector3(horizontalForce * direction, verticalForce, 0f);
    }
}
