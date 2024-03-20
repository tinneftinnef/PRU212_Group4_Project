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
        shurikenDamage = 10f + Player_Information.ATK;
        skillShurikenDamage = 100f + Player_Information.ATK;
        skillFlameShurikenDamage = 100f + Player_Information.ATK;
        chargeFlameDamage = 100f + Player_Information.ATK;
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
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(shurikenDamage);
                        break;
                    case "Mushroom(Clone)":
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(shurikenDamage);
                        break;
                    case "Skeleton(Clone)":
                        collision.gameObject.GetComponent<Health>().TakeDamage(shurikenDamage);
                        break;
                    case "Eye(Clone)":
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(shurikenDamage);
                        break;
                    case "Boss_Bring(Clone)":
                        collision.gameObject.GetComponent<HealthBoss1>().TakeDamage(shurikenDamage);
                        break;
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(shurikenDamage);
                        break;
                    case "FireWorm(Clone)":
                        collision.gameObject.GetComponent<HealthFireWorm>().TakeDamage(shurikenDamage);
                        break;
                }
            }
            if (gameObject.tag == "Skill")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "Goblin(Clone)":
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(skillShurikenDamage);
                        break;
                    case "Mushroom(Clone)":
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(skillShurikenDamage);
                        break;
                    case "Skeleton(Clone)":
                        collision.gameObject.GetComponent<Health>().TakeDamage(skillShurikenDamage);
                        break;
                    case "Eye(Clone)":
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(skillShurikenDamage);
                        break;
                    case "Boss_Bring(Clone)":
                        collision.gameObject.GetComponent<HealthBoss1>().TakeDamage(skillShurikenDamage);
                        break;
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(skillShurikenDamage);
                        break;
                    case "FireWorm(Clone)":
                        collision.gameObject.GetComponent<HealthFireWorm>().TakeDamage(skillShurikenDamage);
                        break;
                }
            }
            if (gameObject.tag == "Charge")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "Goblin(Clone)":
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(chargeFlameDamage);
                        break;
                    case "Mushroom(Clone)":
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(chargeFlameDamage);
                        break;
                    case "Skeleton(Clone)":
                        collision.gameObject.GetComponent<Health>().TakeDamage(chargeFlameDamage);
                        break;
                    case "Eye(Clone)":
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(chargeFlameDamage);
                        break;
                    case "Boss_Bring(Clone)":
                        collision.gameObject.GetComponent<HealthBoss1>().TakeDamage(chargeFlameDamage);
                        break;
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(chargeFlameDamage);
                        break;
                    case "FireWorm(Clone)":
                        collision.gameObject.GetComponent<HealthFireWorm>().TakeDamage(chargeFlameDamage);
                        break;
                }
            }
            if (gameObject.tag == "SkillFlame")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "Goblin(Clone)":
                        collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "Mushroom(Clone)":
                        collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "Skeleton(Clone)":
                        collision.gameObject.GetComponent<Health>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "Eye(Clone)":
                        collision.gameObject.GetComponent<HealthEye>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "Boss_Bring(Clone)":
                        collision.gameObject.GetComponent<HealthBoss1>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(skillFlameShurikenDamage);
                        break;
                    case "FireWorm(Clone)":
                        collision.gameObject.GetComponent<HealthFireWorm>().TakeDamage(skillFlameShurikenDamage);
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
        if (collision.CompareTag("GruzMother"))
        {
            if (gameObject.tag == "Shuriken")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(shurikenDamage);
                        break;
                }
            }
            if (gameObject.tag == "Skill")
            {
                string enemyName = collision.name;
                switch (enemyName)
                { 
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(shurikenDamage);
                        break;
                }
            }
            if (gameObject.tag == "Charge")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(chargeFlameDamage);
                        break;
                }
            }
            if (gameObject.tag == "SkillFlame")
            {
                string enemyName = collision.name;
                switch (enemyName)
                {
                    case "GruzMother(Clone)":
                        collision.gameObject.GetComponent<HealthGruz>().TakeDamage(skillFlameShurikenDamage);
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
