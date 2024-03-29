using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike_Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    float damage ;
    void Start()
    {
        damage = 150f + Player_Information.ATK;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            string enemyName = collision.name;
            switch (enemyName)
            {
                case "Goblin(Clone)":
                    collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(damage);
                    break;
                case "Mushroom(Clone)":
                    collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(damage);
                    break;
                case "Skeleton(Clone)":
                    collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                    break;
                case "Eye(Clone)":
                    collision.gameObject.GetComponent<HealthEye>().TakeDamage(damage);
                    break;
                case "Boss_Bring(Clone)":
                    collision.gameObject.GetComponent<HealthBoss1>().TakeDamage(damage);
                    break;
                case "FireWorm(Clone)":
                    collision.gameObject.GetComponent<HealthFireWorm>().TakeDamage(damage);
                    break;
            }
        }
        if (collision.CompareTag("GruzMother"))
        {
            collision.gameObject.GetComponent<HealthGruz>().TakeDamage(damage);
        }
    }
}
