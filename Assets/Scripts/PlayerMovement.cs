/*
 * GameObject: Player
 * Component: PlayerMovement
 * 
 * Description:
 * Controls the horizontal movement of the Player GameObject within defined boundary limits.
 * Reads direction input from the Player Input component, updates character position along 
 * the x-axis while keeping y and z constrained, and updates Animator parameters to reflect 
 * IDLE and MOVING states.
 */

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private float centerToEdge = 22.0f;
    private Vector2 movementDirection;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    // Called by: Player Input
    public void OnMovementInput(InputAction.CallbackContext ctx)
    {
        movementDirection = ctx.ReadValue<Vector2>();
    }

    private void Move()
    {
        if (movementDirection != Vector2.zero)
        {
            if (animator != null)
            {
                animator.SetBool("IsRunning", true);
            }

            Vector3 currentPosition = transform.position;
            float targetX = currentPosition.x + movementDirection.x * playerSpeed * Time.deltaTime;
            targetX = Mathf.Clamp(targetX, -centerToEdge, centerToEdge);

            transform.position = new Vector3(targetX, currentPosition.y, currentPosition.z);
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("IsRunning", false);
            }
        }
    }
}