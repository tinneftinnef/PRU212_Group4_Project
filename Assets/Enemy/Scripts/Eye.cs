using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Animator animator;
    public DetectionZone attackZone;
    public bool _target = false;
    private bool dead;
    [SerializeField] Player_Information player;
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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Information>();
        attackDamage = 50f * PauseGame.increaseEnemyStats();
    }

    // Update is called once per frame
    void Update()
    {
        //target = attackZone.detectedColliders.Count > 0;
        target = attackZone.IsDetected();
        if (target &&  cooldown <= 0)
        {
            cooldown = attackRate;
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.KBCounter = player.KBTotalTime;
            if (player.transform.position.x <= transform.position.x)
            {
                player.knockFromRight = true;
            }
            if (player.transform.position.x >= transform.position.x)
            {
                player.knockFromRight = false;
            }
            player.TakeDamage(attackDamage);
        }
    }
}