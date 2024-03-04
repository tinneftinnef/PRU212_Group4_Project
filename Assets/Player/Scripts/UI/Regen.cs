using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Regen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player_Information player;
    public bool playerisNear;
    [SerializeField] Image health;
    [SerializeField] Image EP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerisNear && Input.GetKeyDown(KeyCode.E))
        {
            player.currentEP = player.maxEP;
            player.currentHealth = player.maxHealth;
            health.fillAmount = player.currentHealth / player.maxHealth;
            EP.fillAmount = player.currentEP / player.maxEP;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerisNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerisNear = false;
        }
    }
}
