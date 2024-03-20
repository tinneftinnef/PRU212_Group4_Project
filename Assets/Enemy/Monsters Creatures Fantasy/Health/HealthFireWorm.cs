using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthFireWorm : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;


    public HealthBar healthBar;
    public Animator animator;
    private bool dead;
    public GameObject Coin;
    public GameObject Blood;
    public GameObject Mana;


    public GameObject healthPanel;
    public Image bossHealth;
    public Text bossHealthText;
    public int bloodManaDropChance = 2;
    private void Awake()
    {
        currentHealth = startingHealth;
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
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
        bossHealth.fillAmount = currentHealth / startingHealth * PauseGame.increaseEnemyStats();
        bossHealthText.text = currentHealth.ToString();
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
                healthPanel.SetActive(false);
                PauseGame.hasSpawnedBoss = false;
                animator.SetTrigger("die");
                StartCoroutine(DestroyAfterDelay(1f));
                dead = true;
                int random = Random.Range(5, 20);
                for (int i = 0; i < random; i++)
                {
                    GameObject coin = Instantiate(Coin, transform.position, Quaternion.identity);
                    coin.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
                    GameObject blood = Instantiate(Blood, transform.position, Quaternion.identity);
                    blood.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
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
        bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<Image>();
        healthPanel = GameObject.FindGameObjectWithTag("BossPanel");
        bossHealthText = GameObject.FindGameObjectWithTag("BossText").GetComponent<Text>();
        bossHealth.fillAmount = currentHealth / startingHealth;
        bossHealthText.text = currentHealth.ToString();
    }

    // Update is called once per frame
}
