using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlood : MonoBehaviour
{
    public int value = 1; // The value of the coin

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the coin is the player
        if (other.gameObject.CompareTag("Player"))
        {
           
            Destroy(gameObject);
        }
    }
}
