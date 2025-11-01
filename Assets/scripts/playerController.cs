using UnityEngine;
using UnityEngine.InputSystem;
public class playerController : MonoBehaviour
{

    private Vector2 movement;
    private Rigidbody2D body;
    private Animator animator;
    [SerializeField] private int speed;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
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
    private void FixedUpdate()
    {
        body.linearVelocity = movement * speed;
    }
}
