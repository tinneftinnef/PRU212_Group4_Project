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
    [SerializeField] float skillFlameShurikenDamage;
    Audio_Manager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    void Start()
    {
        shurikenSpeed = 25f;
        shurikenDamage = 10f;
        skillShurikenDamage = 40f;
        skillFlameShurikenDamage = 60f;
        chargeFlameDamage = 30f;
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

            if (gameObject.tag == "Shuriken")
            {
                collision.gameObject.GetComponent<EnemyTestTakeHit>().TakeDamage(shurikenDamage);
            }
            if (gameObject.tag == "Skill")
            {
                collision.gameObject.GetComponent<EnemyTestTakeHit>().TakeDamage(skillShurikenDamage);
            }
            if (gameObject.tag == "Charge")
            {
                collision.gameObject.GetComponent<EnemyTestTakeHit>().TakeDamage(chargeFlameDamage);
            }
            if (gameObject.tag == "SkillFlame")
            {
                collision.gameObject.GetComponent<EnemyTestTakeHit>().TakeDamage(skillFlameShurikenDamage);
            }
            int randomNumber = UnityEngine.Random.Range(1, 3);
            switch (randomNumber)
            {
                case 1:
                    audioManager.PlaySFX(audioManager.slashHitted1);
                    break;
                case 2:
                    audioManager.PlaySFX(audioManager.slashHitted2);
                    break;
                case 3:
                    audioManager.PlaySFX(audioManager.slashHitted3);
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
