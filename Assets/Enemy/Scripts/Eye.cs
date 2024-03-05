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

        // Stop the attack animation from playing continuously when the enemy dies
        if (dead)
        {
            animator.SetTrigger("atk2");
        }
    }

    private void Attack()
    {
        // Your attack logic here
    }
}