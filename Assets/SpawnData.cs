using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player_Information player_Infor;
    [SerializeField] Player_Movement Player_Movement;
    [SerializeField] GameObject[] buffK;
    void Start()
    {
        player_Infor.levelHP = PlayerPrefs.GetInt("LvHP");
        player_Infor.levelEP = PlayerPrefs.GetInt("LvEP");
        player_Infor.levelATK = PlayerPrefs.GetInt("LvATK");
        player_Infor.player_coin = PlayerPrefs.GetInt("Coin");
        Player_Movement.selectedSkill = PlayerPrefs.GetInt("SelectedSkillQ");
        player_Infor.currentHealth = player_Infor.maxHealth = PlayerPrefs.GetFloat("Health");
        player_Infor.currentEP = player_Infor.maxEP = PlayerPrefs.GetFloat("EP");
        player_Infor.ATK = PlayerPrefs.GetFloat("ATK");
        player_Infor.isCanUseSkillK = true;
        buffK[PlayerPrefs.GetInt("Active")].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
