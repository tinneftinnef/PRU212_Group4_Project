using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Scripts : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;
    public string[] dialog;
    private int index;

    public GameObject continueButton;
    public float wordSpeed;
    public bool playerIsClose;
    public GameObject InteractPanel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialogPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if (dialogText.text == dialog[index])
        {
            continueButton.SetActive(true);
        }
        InteractTextInRange();
    }
    public void zeroText()
    {
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);

    }
    public void NextLine()
    {
        Debug.Log("Clicked");
        continueButton.SetActive(false);
        if (index < dialog.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    IEnumerator Typing()
    {
        foreach (var letter in dialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
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
            zeroText();
        }
    }

    public void InteractTextInRange()
    {
        if (playerIsClose)
        {
            InteractPanel.SetActive(true);
        }
        else if (!playerIsClose)
        {
            InteractPanel.SetActive(false);
        }
    }
}
