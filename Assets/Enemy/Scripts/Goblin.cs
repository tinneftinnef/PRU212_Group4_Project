using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public Animator animator;
    public DetectionZone attackZone;
    public bool _target = false;
    private bool dead;
    public float attackDamage;
    public float attackRate = 1.0f;
    private float cooldown;
    [SerializeField] Player_Information player;
    [SerializeField] Transform Zone;
    [SerializeField] LayerMask playerLayer;
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

 

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Information>();
    }

    // Update is called once per frame
    void Update()
    {
        target = attackZone.detectedColliders.Count > 0;

        if (target && cooldown <= 0)
        {
            //Attack();
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
                Debug.Log("Hit");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.KBCounter = player.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                player.knockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                player.knockFromRight = false;
            }
            player.TakeDamage(attackDamage);
        }
    }
}
