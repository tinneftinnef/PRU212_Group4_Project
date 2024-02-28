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
        if(playerIsClose && Input.GetKeyDown(KeyCode.E)){
            beginPanel.SetActive(true);
        }
    }
    public void YesBtn(string ScenceName)
    {

        SceneManager.LoadScene(ScenceName);
        beginPanel.SetActive(false);
    }
    public void NoBtn()
    {
        beginPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
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
