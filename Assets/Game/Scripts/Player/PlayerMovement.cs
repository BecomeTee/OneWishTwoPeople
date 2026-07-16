using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerMovement : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerInputReader inputReader;

    [Header("Movement Settings")]
    [SerializeField, Min(0f)] private float movementSpeed = 4f;

    private Rigidbody2D body;

    public Vector2 MovementDirection { get; private set; }
    public bool IsMoving => body.linearVelocity.sqrMagnitude > 0.001f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovementDirection = inputReader.MovementInput;
    }

    private void FixedUpdate()
    {
        body.linearVelocity = MovementDirection * movementSpeed;
    }

    private void OnDisable()
    {
        StopImmediately();
    }

    public void StopImmediately()
    {
        MovementDirection = Vector2.zero;

        if (body != null)
        {
            body.linearVelocity = Vector2.zero;
        }
    }
}