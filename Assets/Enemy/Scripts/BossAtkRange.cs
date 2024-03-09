using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtkRange : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private Transform spellpoint;
    [SerializeField] private GameObject [] spell;




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
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CooldownTimer += Time.deltaTime;
        if (PlayInSight())
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
    private bool PlayInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playLayer);
        if (hit.collider != null)
        {
            AIControllerBoss.speed = 0;
            animator.SetBool("canmove", true);
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
   
}
