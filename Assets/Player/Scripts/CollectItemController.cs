using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectItemController : MonoBehaviour
{
    [SerializeField] Player_Information player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Information>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {

            int randomCoin = Random.Range(30, 100);
            player.takeCoin(randomCoin);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Mana"))
        {
            float increaseMana = player.maxEP * 5f / 100f;
            if (player.currentEP < player.maxEP)
            {
                player.RegenMana(increaseMana);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Blood"))
        {
            Debug.Log(collision.name);
            float increaseHealth = player.maxHealth * 5f / 100f;
            if (player.currentHealth < player.maxHealth)
            {
                player.RegenHealth(increaseHealth);
                Destroy(collision.gameObject);
            }
        }
    }
}
