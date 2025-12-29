using UnityEngine;
using UnityEngine.InputSystem;
public class playerController : MonoBehaviour
{
    private Vector2 movement; // The movement vector keeps tack of the current direction of the player character. 
    private Rigidbody2D body; // The body Rigidbody2D stores a reference to the Rigidbody2D component placed on the player character.
    private Animator animator; // The animator Animator stores a reference to the animator component placed on the player character.
    [SerializeField] private int speed;
    /// <summary>
    /// Called when the script is being loaded.
    /// Initializes the rigidbody and animator. 
    /// </summary>
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// Called by Unity's input system.
    /// Updates the movement vector and animator.
    /// </summary>
    /// <param name="value"></param>
    private void OnMovement(InputValue value)
    {
        // Sets the movement vector corresponding to the input pressed. 
        // Ergo if w was pressed the movement will be set to (0, 1)
        movement = value.Get<Vector2>();
        // This if statement checks if the player is currently moving, if yes then the animator gets the new x and y, then walking is set to true.
        // If the player is not moving the walking is set to false. 
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("x", movement.x);
            animator.SetFloat("y", movement.y);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
    /// <summary>
    /// Updates the linearVelocity of the player rigidbody, using the movement vector and speed.
    /// </summary>
    private void FixedUpdate()
    {
        body.linearVelocity = movement * speed;
    }
}
