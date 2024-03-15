using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike_Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    float damage = 150f;
    void Start()
    {
        
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
                    Debug.Log("Goblin");
                    collision.gameObject.GetComponent<HealthGoblin>().TakeDamage(damage);
                    break;
                case "Mushroom(Clone)":
                    Debug.Log("Mushroom");
                    collision.gameObject.GetComponent<HealthMushroom>().TakeDamage(damage);
                    break;
                case "Skeleton(Clone)":
                    Debug.Log("Skeleton");
                    collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                    break;
                case "Eye(Clone)":
                    Debug.Log("Eye");
                    collision.gameObject.GetComponent<HealthEye>().TakeDamage(damage);
                    break;
            }
        }
    }
}
