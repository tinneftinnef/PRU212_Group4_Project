using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGoblin : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    int hurtTriggerCount = 0;

    public HealthBar healthBar;
    public Animator animator;
    private bool dead;
    public GameObject Coin;
    public GameObject Blood;
    public GameObject Mana;

    public int bloodManaDropChance = 2;
    private void Awake()
    {
        
        healthBar.SetMaxHealth(startingHealth);
        animator = GetComponent<Animator>();

    }
    public IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth > 0)
        {
            if (hurtTriggerCount < 3)
            {
                animator.SetTrigger("hurt");
                hurtTriggerCount++;
            }
            if (hurtTriggerCount > 3)
            {
                animator.SetBool("canCast", true);
                animator.SetBool("canHit", true);
            }
        }
        else
        {
            if (!dead)
            {
                //player die
                animator.SetTrigger("die");
                StartCoroutine(DestroyAfterDelay(2f));
                dead = true;
                AIController aIController = GetComponent<AIController>();
                aIController.enabled = false;
                GameObject coin = Instantiate(Coin, transform.position, Quaternion.identity);
                coin.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;

                // Drop a blood or mana with 1 in 2 chance
                if (Random.Range(0, 3) == 0)
                {
                    GameObject blood = Instantiate(Blood, transform.position, Quaternion.identity);
                    blood.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
                }
                else
                {
                    GameObject mana = Instantiate(Mana, transform.position, Quaternion.identity);
                    mana.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
                }

            }


        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth * PauseGame.increaseEnemyStats();
    }

    // Update is called once per frame
}
