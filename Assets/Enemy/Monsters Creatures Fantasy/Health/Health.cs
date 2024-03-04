using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    private bool dead;
    public GameObject Coin;
    public int coinDropChance ;
    private void Awake()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);

    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0,startingHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth > 0) {
            //player hurt
            animator.SetTrigger("hurt");

        }
        else
        {
            if (!dead)
            {
                //player die
                animator.SetTrigger("die");
                GetComponent<Skeleton>().enabled = false;
                dead = true;
                if (Random.Range(0, 101) <= coinDropChance)
                {
                    GameObject coin = Instantiate(Coin, transform.position, Quaternion.identity);
                    coin.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
}
