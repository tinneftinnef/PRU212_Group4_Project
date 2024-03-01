using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] public Text pointText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 10;
        pointText.text = "Score : " + score + " Point";
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
