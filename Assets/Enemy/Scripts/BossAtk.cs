using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtk : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private float CooldownTimer = Mathf.Infinity;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CooldownTimer += Time.deltaTime;
        if (BossCheckFollow.inMeleeRange)
        {
            if (CooldownTimer >= attackCooldown)
            {
                //atk
                CooldownTimer = 0;
                animator.SetTrigger("mele");

            }

        }
    }
}
