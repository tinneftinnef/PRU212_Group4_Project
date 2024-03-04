using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMana : MonoBehaviour
{
    public int value = 1; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            Destroy(gameObject);
        }
    }
}
