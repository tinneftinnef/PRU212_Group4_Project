using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] public Text pointText;
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "Score : " + PlayerPrefs.GetInt("Coin") + " Point";
    }

    public void ClickReplay()
    {
        SceneManager.LoadScene("SceneWaiting");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
