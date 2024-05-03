using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float runThreshold = 0.5f; 
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * speed * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            bool isRunning = Mathf.Abs(horizontalInput) > runThreshold;

            if (isRunning)
            {
                animator.Play("Locomotion");
            }
            else
            {
                if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
                {
                    if (horizontalInput > 0)
                    {
                        animator.Play("TurnOnSpotRightA");
                    }
                    else
                    {
                        animator.Play("TurnOnSpotLeftA");
                    }
                }
                else
                {
                    animator.Play("Locomotion");
                }
            }

            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.Play("Idle");
            animator.SetBool("IsMoving", false);
        }
    }
}
