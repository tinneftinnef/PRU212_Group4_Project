using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEye : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;


    public HealthBar healthBar;
    public Animator animator;
    private bool dead;
    public GameObject Coin;
    public GameObject Blood;
    public GameObject Mana;

    public int bloodManaDropChance = 2;
    private void Awake()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        animator = GetComponent<Animator>();

    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth > 0)
        {
            //player hurt
            animator.SetTrigger("hurt");

        }
        else
        {
            if (!dead)
            {
                //player die
                animator.SetTrigger("die");
                animator.SetBool("isAlive", true);
                GetComponent<Eye>().enabled = false;

                GetComponent<FlyingEnemy>().enabled = false;

                dead = true;
                GameObject coin = Instantiate(Coin, transform.position, Quaternion.identity);
                coin.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;

                // Drop a blood or mana with 1 in 2 chance
                if (Random.Range(0, 2) == 0)
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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
}
