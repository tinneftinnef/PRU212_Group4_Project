using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameISPaused = false;
    [SerializeField]
    public GameObject pauseMenuUi;
    public Text secondstxt;
    public Text minutestxt;
    public Text leveltxt;
    public static float currentLevel;
    public int count;
    public static float levelPercent;
    private double minutes, seconds;
    spawnBoss spawn;
    public static bool hasSpawnedBoss;


    //boss health
    public GameObject healthPanel;
    void Start()
    {
        hasSpawnedBoss = false;
        count = 0;
        currentLevel = 1;
        levelPercent = 1;
        pauseMenuUi.SetActive(false);
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<spawnBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTime();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameISPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        //Debug.Log(increaseEnemyStats());
       // increaseEnemyStats();
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1.0f;
        GameISPaused = false;
    }
    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameISPaused = true;
    }
    public void QuiteGame()
    {
        Application.Quit();
    }
    public void CalculateTime()
    {
        if(secondstxt != null && minutestxt != null && leveltxt != null)
        {
            seconds += Time.deltaTime;
            double integerSeconds = (int)Math.Floor(seconds);
            secondstxt.text = integerSeconds.ToString();
            minutestxt.text = minutes.ToString();
            leveltxt.text = "Level: " + currentLevel;
            if (integerSeconds > 30f)
            {
                int random = UnityEngine.Random.Range(0, 3);

                minutes += 1;
                seconds = 0;
                if (!hasSpawnedBoss)
                {
                    spawn.SpawnRandomBoss(1, random);
                    healthPanel.SetActive(true);
                }
                hasSpawnedBoss = true;
                currentLevel++;
                count++;
                if (count >= 30)
                {
                    count = 0;
                    levelPercent++;
                }
            }
            PlayerPrefs.SetString("minutes", minutestxt.text);
            PlayerPrefs.SetString("second", secondstxt.text);
        }

        
    }
    public static float increaseEnemyStats()
    {
        float healIncrease = currentLevel * 50 / 100;
        float percent = healIncrease + levelPercent;
        return percent;
    }
}
