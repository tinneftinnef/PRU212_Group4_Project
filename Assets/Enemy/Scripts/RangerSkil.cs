using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerSkil : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private Transform spellpoint;
    [SerializeField] private GameObject[] spell;




    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playLayer;

    private float CooldownTimer = Mathf.Infinity;
    private Health playrHealth;
    private Animator animator;
    private AIControllerBoss controller;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<AIControllerBoss>();
    }
    // Start is called before the first frame update
    void Start()
    {
        damage = 50f * PauseGame.increaseEnemyStats();
    }

    // Update is called once per frame
    void Update()
    {
        CooldownTimer += Time.deltaTime;
        if (checkInAttackRange.isInSpellRange)
        {
            if (CooldownTimer >= attackCooldown)
            {
                //atk
                CooldownTimer = 0;
                animator.SetTrigger("ranger");
                rangeratk();

            }
        }
    }
    private void rangeratk()
    {
        CooldownTimer = 0;
        GameObject newSpell = Instantiate(spell[FindSpell()], spellpoint.position, Quaternion.identity);
        newSpell.SetActive(true);
        newSpell.GetComponent<ProjectileMove>().ActivateProjectile();
    }
    private int FindSpell()
    {
        for (int i = 0; i < spell.Length; i++)
        {
            if (!spell[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
