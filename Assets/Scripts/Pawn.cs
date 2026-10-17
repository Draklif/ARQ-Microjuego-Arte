using UnityEngine;

// Pawn: el "cuerpo" que existe en el mundo. No sabe nada de teclados ni gamepads;
// solo obedece a quien lo posea (un PlayerController, o en el futuro un AIController).
[RequireComponent(typeof(Rigidbody2D))]
public class Pawn : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody2D body;
    Vector2 moveDirection;

    public PlayerController Controller { get; private set; }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void OnPossessed(PlayerController controller)
    {
        Controller = controller;
    }

    public void OnUnpossessed()
    {
        Controller = null;
        moveDirection = Vector2.zero;
    }

    public void Move(Vector2 direction)
    {
        moveDirection = direction;
    }

    // La física se actualiza en FixedUpdate, no en Update.
    void FixedUpdate()
    {
        body.linearVelocity = moveDirection * speed;
    }
}
