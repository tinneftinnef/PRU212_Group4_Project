using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtk : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;


    [SerializeField] private float damage;
    [SerializeField]private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playLayer;

     private float CooldownTimer=Mathf.Infinity;
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
                animator.SetTrigger("mele");
               
            }

        }
    }
    private bool PlayInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right*range*transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left,0,playLayer);
        if(hit.collider != null)
        {
playrHealth = hit.transform.GetComponent<Health>();
            AIControllerBoss.speed = 0;
            animator.SetBool("canmove", true);
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range*transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void Damage()
    {
        if (PlayInSight())
        {
            playrHealth.TakeDamage(damage);
        }
    }

}
