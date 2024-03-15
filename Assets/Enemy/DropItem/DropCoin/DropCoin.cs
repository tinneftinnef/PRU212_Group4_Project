using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoin : MonoBehaviour
{
    public int minValue = 0;
    public int maxValue = 100;
    private int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            //int coinValue = Random.Range(minValue, maxValue + 1);
            //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f); 
            //GetComponent<DropCoin>().value = coinValue;
            //Destroy(gameObject, 1.0f); 
            Debug.Log(other.name);
        }
    }
}