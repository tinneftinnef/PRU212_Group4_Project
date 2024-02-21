using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Component")]
    protected Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [Header("Movement")]
    [SerializeField] internal bool canMove;
    [SerializeField] float speed;
    [SerializeField] float currentMovement;
    [SerializeField] bool isFacingRight;
    [SerializeField] bool canJump;
    [SerializeField] float jumpPower;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpTimeCounter;
    [SerializeField] internal int jumpRemaining;
    [SerializeField] internal int jumpCheck;
    [SerializeField] int maxJump = 1;
    [SerializeField] float maxFallSpeed = 15f;
    [SerializeField] Shuriken_Scripts Shuriken_Scripts;
    [Header("UseAbility")]
    [SerializeField] internal bool isCanUseQ;
    [SerializeField] internal bool isCanUseChargeL;
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
        this.Running();
        Jump();
        Flip();
        animator.SetBool("IsGround", IsGrounded());
        BasicAttack();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < -maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxFallSpeed);
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
    internal bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }
    protected void Jump()
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
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
            {
                canJump = true;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jumpTimeCounter = jumpTime;
                jumpCheck--;

            }
            if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && canJump == true)
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
    protected void Release()
    {
        StartCoroutine(ReleaseMultipleTimes(3, 0.09f));
    }
    IEnumerator ReleaseMultipleTimes(int times, float interval)
    {
        for (int i = 0; i < times; i++)
        {
            Shuriken_Scripts.ReleaseSkill();
            canMove = false;
            yield return new WaitForSeconds(interval);
        }
        canMove = true;
    }
}
