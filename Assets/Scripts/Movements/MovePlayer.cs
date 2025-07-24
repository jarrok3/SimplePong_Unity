using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 0.0f;

    Vector2 moveDirection = Vector2.zero;
    
    [SerializeField]
    InputAction playerMovement;
    [SerializeField]
    Rigidbody2D rb;

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.linearVelocityY = moveDirection.y * moveSpeed;
    }
}
