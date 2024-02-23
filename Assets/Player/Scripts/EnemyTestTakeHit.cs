using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestTakeHit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] Animator animator;
    [SerializeField] Collider2D colliderSke;
    protected Rigidbody2D rb;
    private float deadTime;
    private bool isdead;
    void Start()
    {
        isdead = false;
        deadTime = 2f;
        currentHealth = maxHealth = 100f;
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isdead == true)
        {
            deadTime -= Time.deltaTime;
            if (deadTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void TakeDamage(float damage)
    {
        Collider2D[] childColliders = GetComponentsInChildren<Collider2D>();
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            isdead = true;
            animator.SetBool("IsDead", true);
        }
    }
}
