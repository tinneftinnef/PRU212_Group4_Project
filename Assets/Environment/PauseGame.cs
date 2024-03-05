using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameISPaused = false;
    [SerializeField]
    public GameObject pauseMenuUi;
    void Start()
    {
        pauseMenuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("Quiting Game");
    }
}
