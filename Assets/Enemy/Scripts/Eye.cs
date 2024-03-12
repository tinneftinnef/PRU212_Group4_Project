using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Animator animator;
    public DetectionZone attackZone;
    public bool _target = false;
    private bool dead;
    public bool target
    {
        get { return _target; }
        private set
        {
            _target = value;
            animator.SetBool(AnimationStrings.target, _target);
        }
    }

    public bool isAlive;

    public float attackDamage;
    public float attackRate = 1.0f;
    private float cooldown;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cooldown = attackRate;
    }

    // Update is called once per frame
    void Update()
    {
        target = attackZone.detectedColliders.Count > 0;

        if (target &&  cooldown <= 0)
        {
            Attack();
            cooldown = attackRate;
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

      
    }

    private void Attack()
    {
      
        Collider2D[] hitColliders = attackZone.GetComponents<Collider2D>();

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                Health playerHealth = hitCollider.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage);
                }
            }
        }
    }
}