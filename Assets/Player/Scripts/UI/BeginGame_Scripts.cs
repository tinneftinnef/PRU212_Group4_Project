using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame_Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerIsClose;
    public GameObject beginPanel;
    public Player_Information Player_Information;
    public GameObject[] buffedSkill;
    public Player_Movement Player_Movement;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeMap();
    }
    private void ChangeMap()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            beginPanel.SetActive(true);
        }
    }
    public void YesBtn()
    {
        if (Player_Information.isCanUseSkillK)
        {
            PlayerPrefs.SetInt("KUnlock", 1);
            for (int i = 0; i < buffedSkill.Length; i++)
            {
                if (buffedSkill[i].activeSelf == true)
                {
                    PlayerPrefs.SetInt("Active", i);
                }
            }
        }
        if (Player_Movement.isCanUseQ)
        {
            PlayerPrefs.SetInt("QUnlock", 1);
        }
        PlayerPrefs.SetFloat("Health", Player_Information.maxHealth);
        PlayerPrefs.SetFloat("EP", Player_Information.maxEP);
        PlayerPrefs.SetFloat("ATK", Player_Information.ATK);
        PlayerPrefs.SetInt("LvHP", Player_Information.levelHP);
        PlayerPrefs.SetInt("LvEP", Player_Information.levelEP);
        PlayerPrefs.SetInt("LvATK", Player_Information.levelATK);
        PlayerPrefs.SetInt("SelectedSkillQ", Player_Movement.selectedSkill);
        
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber)
        {
            case 1:
                SceneManager.LoadScene("PlayScence");
                break;

            case 2:
                SceneManager.LoadScene("PlayScence1");
                break;
        }
        beginPanel.SetActive(false);
    }
    public void NoBtn()
    {
        beginPanel.SetActive(false);
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
