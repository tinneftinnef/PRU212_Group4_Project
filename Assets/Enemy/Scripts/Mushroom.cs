using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Animator animator;
    public DetectionZone attackZone;
    public bool _target = false;
    private bool dead;
    public float attackDamage;
    public float attackRate = 1.0f;
    private float cooldown;
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

    public Health health; // Add this field

    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>(); // Assign the Health component here

    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        target = attackZone.detectedColliders.Count > 0;


        if (target && cooldown <= 0)
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