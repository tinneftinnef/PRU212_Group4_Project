using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Stats_Interact : MonoBehaviour
{
    public GameObject statsPanel;
    public GameObject plusHPButton;
    public GameObject plusATKButton;
    public GameObject plusEPButton;
    public GameObject closeButton;
    public bool playerIsClose;
    [SerializeField] Player_Information player_Information;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (statsPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                statsPanel.SetActive(true);
            }
        }
    }
    public void ClosedButton()
    {
        statsPanel.SetActive(false);
    }
    public void zeroText()
    {
        statsPanel.SetActive(false);

    }
    public void AddHP()
    {
        player_Information.maxHealth += 50;
    }
    public void AddATK()
    {
        player_Information.ATK += 20;
    }
    public void AddEP()
    {
        player_Information.maxEP += 50;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
