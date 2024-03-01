using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MemoryForm_Scripts : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    protected Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] internal bool canMove;
    [SerializeField] float speed;
    [SerializeField] float currentMovement;
    [SerializeField] bool isFacingRight;
    [SerializeField] internal bool canJump;
    [SerializeField] float jumpPower;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpTimeCounter;
    [SerializeField] internal int jumpRemaining;
    [SerializeField] internal int jumpCheck;
    [SerializeField] int maxJump = 1;
    [SerializeField] float maxFallSpeed = 15f;
    void Start()
    {
        speed = 10f;
        jumpPower = 10f;
        jumpTime = 0.3f;
        canMove = true;
        isFacingRight = true;
        canJump = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        swapForm();
        Running();
        Flip();
        Tracking();
        Jump();
        animator.SetBool("IsGround", IsGrounded());
        BasicAttack();
    }
    internal bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }
    protected void swapForm()
    {
        if(gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.B))
        {
            gameObject.SetActive(false);
            player.SetActive(true);
        }
    }
    private void Tracking()
    {
        if(gameObject.activeSelf == true)
        {
            player.transform.position = gameObject.transform.position;
        }
    }
    protected void Running()
    {
        if (canMove)
        {
            currentMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            if (currentMovement != 0)
            {
                animator.SetBool("IsRunning", true);
            }
            else if (currentMovement == 0)
            {
                animator.SetBool("IsRunning", false);
            }
            transform.Translate(currentMovement, 0, 0);
        }
    }
    protected void Flip()
    {
        if (isFacingRight && currentMovement < 0f || !isFacingRight && currentMovement > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < -maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxFallSpeed);
        }
    }
    protected void Jump()
    {
        if (canJump == true)
        {
            if (rb.velocity.y > 0)
            {
                animator.SetBool("IsJump", true);
                animator.SetBool("IsFall", false);

            }
            else if (rb.velocity.y < 0)
            {
                animator.SetBool("IsJump", false);
                if (IsGrounded() == false)
                {
                    animator.SetBool("IsFall", true);
                }
            }
            if (IsGrounded() == true)
            {
                animator.SetBool("IsFall", false);
                animator.SetBool("IsJump", false);
                jumpRemaining = maxJump;
                jumpCheck = maxJump;
            }
            if (jumpRemaining > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    canJump = true;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    jumpTimeCounter = jumpTime;
                    jumpCheck--;

                }
                if (Input.GetKey(KeyCode.Space) && canJump == true)
                {
                    if (jumpRemaining >= 0)
                    {
                        if (jumpTimeCounter > 0)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, 0);
                            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                            jumpTimeCounter -= Time.deltaTime;
                        }
                    }
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (jumpRemaining <= 0)
                    {
                        canJump = false;
                    }
                    else
                    {
                        jumpTimeCounter = jumpTime;
                        jumpRemaining--;
                    }
                }
            }
        }
    }
    protected void BasicAttack()
    {
        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                animator.SetTrigger("BasicAttack");
            }
        }
    }
}
