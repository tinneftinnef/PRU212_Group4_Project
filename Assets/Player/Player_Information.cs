using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Information : MonoBehaviour
{
    [SerializeField] internal int currentHP;
    [SerializeField] internal int MaxHP;
    [SerializeField] internal int currentEP;
    [SerializeField] internal int MaxEP;
    [SerializeField] internal int currentATK;
    [SerializeField] internal int maxATK;
    void Start()
    {
        currentHP = MaxHP = 100;
        currentEP = MaxEP = 100;
        currentATK = 10;
        maxATK = Int32.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
