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
    [SerializeField] public bool canMove;
    [SerializeField] public bool canFLip;
    [SerializeField] float speed;
    [SerializeField] float currentMovement;
    [SerializeField] bool isFacingRight;
    [SerializeField] public bool canJump;
    [SerializeField] float jumpPower;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpTimeCounter;
    [SerializeField] public int jumpRemaining;
    [SerializeField] public int jumpCheck;
    [SerializeField] int maxJump = 1;
    [SerializeField] float maxFallSpeed = 15f;
    [SerializeField] Shuriken_Scripts Shuriken_Scripts;
    [Header("UseAbility")]
    [SerializeField] public bool isCanUseQ;
    [SerializeField] public bool isCanUseChargeL;
    [SerializeField] public int selectedSkill;
    [Header("DealDamgeToEnemy")]
    [SerializeField] EnemyTestTakeHit takeHit;
    Audio_Manager audioManager;
    [SerializeField] LightningStrike_Spawn lightningSpawn;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }

    void Start()
    {
        isCanUseQ = true;
        selectedSkill = 0;
        speed = 10f;
        jumpPower = 10f;
        jumpTime = 0.3f;
        canMove = true;
        isFacingRight = true;
        canJump = true;
        canFLip = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        this.selectedSkill = PlayerPrefs.GetInt("SelectedSkillQ");
    }

    // Update is called once per frame
    void Update()
    {
        this.Running();
        Jump();
        Flip();
        animator.SetBool("IsGround", IsGrounded());
        BasicAttack();
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
        if (canFLip)
        {
            if (isFacingRight && currentMovement < 0f || !isFacingRight && currentMovement > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }
    protected void Jump()
    {
        if(canJump == true)
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
                    audioManager.PlaySFX(audioManager.jump);

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
                audioManager.PlaySFX(audioManager.slashNoHit);
            }
        }
    }
    protected void Release()
    {
        StartCoroutine(ReleaseMultipleTimes(3, 0.09f));
    }
    IEnumerator ReleaseMultipleTimes(int times, float interval)
    {
        switch (selectedSkill)
        {
            case 1:
                for (int i = 0; i < times; i++)
                {
                    Shuriken_Scripts.ReleaseSkillFlame();
                    canFLip = false;
                    canJump = false;
                    canMove = false;
                    yield return new WaitForSeconds(interval);
                }
                break;
            case 2:
                for (int i = 0; i < times; i++)
                {
                    Shuriken_Scripts.ReleaseSkill();
                    canFLip = false;
                    canJump = false;
                    canMove = false;
                    yield return new WaitForSeconds(interval);
                };
                break;
            case 3:
                lightningSpawn.UseSkill();
                canFLip = false;
                canJump = false;
                canMove = false;
                break;

        }
        canFLip = true;
        canJump = true;
        canMove = true;
    }

}
