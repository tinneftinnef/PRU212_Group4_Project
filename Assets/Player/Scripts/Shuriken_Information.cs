using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken_Information : MonoBehaviour
{
    [SerializeField] private float shurikenSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float shurikenDamage;
    [SerializeField] float skillShurikenDamage;
    [SerializeField] float chargeFlameDamage;
    [SerializeField] EnemyTestTakeHit takeHit;
    void Start()
    {
        shurikenSpeed = 25f;
        shurikenDamage = 10f;
        skillShurikenDamage = 40f;
        chargeFlameDamage = 30f;
        takeHit = GameObject.FindWithTag("Enemy").GetComponent<EnemyTestTakeHit>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * shurikenSpeed;
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(gameObject.tag == "Shuriken")
            {
                takeHit.TakeDamage(shurikenDamage);
            }
            if(gameObject.tag == "Skill")
            {
                takeHit.TakeDamage(skillShurikenDamage);
            }
            if(gameObject.tag == "Charge")
            {
                takeHit.TakeDamage(chargeFlameDamage);
            }
        }
    }
}
