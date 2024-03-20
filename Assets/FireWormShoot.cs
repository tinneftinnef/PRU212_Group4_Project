using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWormShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform shootingPoint;
    [SerializeField] private GameObject spell;
    [SerializeField] private float attackCooldown;
    private float CooldownTimer = Mathf.Infinity;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CooldownTimer += Time.deltaTime;
        if (!checkInAttackRange.isInSpellRange)
        {
            if (CooldownTimer >= attackCooldown)
            {
                //atk
                CooldownTimer = 0;
                animator.SetTrigger("ranger");
                Shoot();

            }
        }

    }
    void Shoot()
    {
        if (BossCheckFollow.inMeleeRange)
        {
            CooldownTimer = 0;
            GameObject newSpell = Instantiate(spell, shootingPoint.position, Quaternion.identity);
            newSpell.SetActive(true);
            newSpell.GetComponent<ProjectileMove>().ActivateProjectile();
        }
    }
}
