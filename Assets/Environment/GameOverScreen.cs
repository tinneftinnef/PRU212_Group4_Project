using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] public Text pointText;
    [SerializeField] Player_Movement player_Movement;
    [SerializeField] Player_Information player_Information;
    [SerializeField] Text totalSurvivalTime;
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "Score : " + PlayerPrefs.GetInt("CoinEarn") + " Coin";
        totalSurvivalTime.text = $"Total Survival Time: {PlayerPrefs.GetString("minutes")} : {PlayerPrefs.GetString("second")}";
    }

    public void ClickReplay()
    {
        player_Information.player_coin = PlayerPrefs.GetInt("CoinEarn");
        SceneManager.LoadScene("SceneWaiting");   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
