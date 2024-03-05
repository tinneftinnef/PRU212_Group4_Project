using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_Information : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public float currentHealth;
    [SerializeField] Image healthBar;
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentEP;
    [SerializeField] Image epBar;
    [SerializeField] public float maxEP;
    [SerializeField] public float ATK;
    [SerializeField] public int player_coin;
    [SerializeField] Text currentCoin;
    [SerializeField] Animator animator;
    [SerializeField] Player_Movement player_Movement;
    [Header("NockBack")]
    [SerializeField] public float KBForce = 2f;
    [SerializeField] public float KBCounter = 0.1f;
    [SerializeField] public float KBTotalTime = 0.7f;
    [SerializeField] public bool knockFromRight = false;
    [SerializeField] public bool isCanUseSkillK;
    public GameObject[] listKSkill;
    Rigidbody2D rb;
    //Enemy List
    [SerializeField] EnemyTestTakeHit takeHit;
    //private static Player_Information instance;
    //public static Player_Information Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = new Player_Information();
    //        }
    //        return instance;
    //    }
    //}
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
        currentCoin.text = player_coin.ToString();
    }
    public void usingCoin(int coin)
    {
        player_coin -= coin; 
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        if(currentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
        }
    }
    public void useAbility(float mana)
    {
        currentEP -= mana;
        if(epBar != null)
        {
            epBar.fillAmount = currentEP / maxEP;
        }
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
