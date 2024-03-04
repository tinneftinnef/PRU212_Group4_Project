using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickupCoin : MonoBehaviour
{
    public int pickupQuantity;
     void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Play
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
