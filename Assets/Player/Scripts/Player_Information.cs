using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_Information : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] internal float currentHealth;
    [SerializeField] Image healthBar;
    [SerializeField] internal float maxHealth;
    [SerializeField] internal float currentEP;
    [SerializeField] Image epBar;
    [SerializeField] internal float maxEP;
    [SerializeField] internal float ATK;
    [SerializeField] Animator animator;
    [SerializeField] Player_Movement player_Movement;
    [Header("NockBack")]
    [SerializeField] internal float KBForce = 2f;
    [SerializeField] internal float KBCounter = 0.1f;
    [SerializeField] internal float KBTotalTime = 0.7f;
    [SerializeField] internal bool knockFromRight = false;
    [SerializeField] internal bool isCanUseSkillK;
    public GameObject[] listKSkill;
    Rigidbody2D rb;
    //Enemy List
    [SerializeField] EnemyTestTakeHit takeHit;
    void Start()
    {
        isCanUseSkillK = true;
        currentHealth = maxHealth = 100f;
        currentEP = maxEP = 500f;
        ATK = 10;
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        KnockBack();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
        }
    }
    public void useAbility(float mana)
    {
        currentEP -= mana;
        epBar.fillAmount = currentEP / maxEP;
    }
    protected void KnockBack()
    {
        if (KBCounter <= 0.2f)
        {
            player_Movement.canMove = true;
            player_Movement.canJump = true;
            animator.SetBool("IsHurt", false);
        }
        else
        {
            player_Movement.canMove = false;
            player_Movement.canJump = false;
            animator.SetBool("IsHurt", true);
            if (knockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (knockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
    }

}
