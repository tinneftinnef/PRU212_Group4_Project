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
        skillShurikenDamage = 100f;
        skillFlameShurikenDamage = 200f;
        chargeFlameDamage = 200f;
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
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "Goblin(Clone)":
                        Debug.Log("Goblin");
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(shurikenDamage);
                        break;
                    case "Mushroom(Clone)":
                        Debug.Log("Mushroom");
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(shurikenDamage);
                        break;
                    case "Skeleton(Clone)":
                        Debug.Log("Skeleton");
                        collision.gameObject.GetComponent<Health>().TakeDamage(shurikenDamage);
                        break;
                    case "Eye(Clone)":
                        Debug.Log("Eye");
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(shurikenDamage);
                        break;
                }
            }
            if (gameObject.tag == "Skill")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "Goblin(Clone)":
                        Debug.Log("Goblin");
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(shurikenDamage);
                        break;
                    case "Mushroom(Clone)":
                        Debug.Log("Mushroom");
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(shurikenDamage);
                        break;
                    case "Skeleton(Clone)":
                        Debug.Log("Skeleton");
                        collision.gameObject.GetComponent<Health>().TakeDamage(shurikenDamage);
                        break;
                    case "Eye(Clone)":
                        Debug.Log("Eye");
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(shurikenDamage);
                        break;
                }
            }
            if (gameObject.tag == "Charge")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "Goblin(Clone)":
                        Debug.Log("Goblin");
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(chargeFlameDamage);
                        break;
                    case "Mushroom(Clone)":
                        Debug.Log("Mushroom");
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(chargeFlameDamage);
                        break;
                    case "Skeleton(Clone)":
                        Debug.Log("Skeleton");
                        collision.gameObject.GetComponent<Health>().TakeDamage(chargeFlameDamage);
                        break;
                    case "Eye(Clone)":
                        Debug.Log("Eye");
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(chargeFlameDamage);
                        break;
                }
            }
            if (gameObject.tag == "SkillFlame")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "Goblin(Clone)":
                        Debug.Log("Goblin");
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "Mushroom(Clone)":
                        Debug.Log("Mushroom");
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "Skeleton(Clone)":
                        Debug.Log("Skeleton");
                        collision.gameObject.GetComponent<Health>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "Eye(Clone)":
                        Debug.Log("Eye");
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(skillFlameShurikenDamage);
                        break;
                }
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
