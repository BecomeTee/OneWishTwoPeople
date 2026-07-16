using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerInputReader : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveAction;

    public Vector2 MovementInput { get; private set; }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        MovementInput = Vector2.zero;
    }

    private void Update()
    {
        MovementInput = moveAction.action.ReadValue<Vector2>();

        if (MovementInput.sqrMagnitude > 1f)
        {
            MovementInput = MovementInput.normalized;
        }
    }
}