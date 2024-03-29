using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtkRange : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform spellpoint;
    [SerializeField] private GameObject [] spell;




    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playLayer;

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
        newSpell.GetComponent<Projectile>().ActivateProjectile();
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
