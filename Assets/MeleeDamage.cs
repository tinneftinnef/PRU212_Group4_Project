using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float damage;
    [SerializeField] Player_Information player;
    void Start()
    {
        damage = 50 * PauseGame.increaseEnemyStats();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Information>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.KBCounter = player.KBTotalTime;
            if (player.transform.position.x <= transform.position.x)
            {
                player.knockFromRight = true;
            }
            if (player.transform.position.x >= transform.position.x)
            {
                player.knockFromRight = false;
            }
            player.TakeDamage(damage);
        }
    }
}
