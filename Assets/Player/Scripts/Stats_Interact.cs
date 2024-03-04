using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject dropdownKButton;
    public GameObject dropdownQButton;
    public GameObject[] KSkillList;
    public GameObject[] QSkillList;
    [SerializeField] Player_Information player_Information;
    [SerializeField] Player_Movement player_Movement;
    int previous = 0;
    int next = 0;
    int actived = 1;
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
    public void SelectedSkillK()
    {
        if (player_Information.isCanUseSkillK)
        {
            next++;
            if (next >= 0 && next <= KSkillList.Length - 1)
            {
                previous = next - 1;
                KSkillList[next].SetActive(true); 
                player_Information.listKSkill[next].SetActive(true);
                KSkillList[previous].SetActive(false);
                player_Information.listKSkill[previous].SetActive(false);
            }
            if (next > KSkillList.Length - 1)
            {
                previous = next - 1;
                next = actived;
                KSkillList[next].SetActive(true);
                KSkillList[previous].SetActive(false);
                player_Information.listKSkill[next].SetActive(true);
                player_Information.listKSkill[previous].SetActive(false);
            }
            
        }
    }
    public void SelectSkillQ()
    {
        if (player_Movement.isCanUseQ == true)
        {
            next++;
            if(next >= 0 && next <= QSkillList.Length - 1)
            {
                previous = next - 1;
                QSkillList[next].SetActive(true);
                player_Movement.selectedSkill = next;
                QSkillList[previous].SetActive(false);
            }
            if(next > QSkillList.Length - 1)
            {
                previous = next - 1;
                next = actived;
                QSkillList[next].SetActive(true);
                QSkillList[previous].SetActive(false);
                player_Movement.selectedSkill = next;
            }
        }
    }
}

