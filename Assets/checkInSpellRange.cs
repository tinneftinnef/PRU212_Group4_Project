using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkInAttackRange : MonoBehaviour
{
    public static bool isInSpellRange;
    public BossCheckFollow bossMove;
    private void Start()
    {
        //bossMove = GameObject.FindGameObjectWithTag("CheckMove").GetComponent<BossCheckFollow>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInSpellRange = true;
            bossMove.setMove(true);
            //Debug.Log("Inside");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInSpellRange = false;
            bossMove.setMove(false);
            //sDebug.Log("Outside");
        }
    }
}
