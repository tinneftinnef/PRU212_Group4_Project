using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float resetTime;
    [SerializeField] Player_Information player;
    public float attackDamage;

    private float lifetime;
    Animator animator;
    private void Awake()
    {
        attackDamage = 50f * PauseGame.increaseEnemyStats();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Information>();
    }

    public void ActivateProjectile()
    {

        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
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
