using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckFollow : MonoBehaviour
{
    private AIControllerBoss controller;
    public static bool canMove;
    public static bool inMeleeRange;
    private void Awake()
    {
        controller = GetComponent<AIControllerBoss>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canMove = true;
            inMeleeRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canMove = false;
            inMeleeRange = false;
        }
    }
    public void setMove(bool move)
    {
        canMove = move;
    }
}
