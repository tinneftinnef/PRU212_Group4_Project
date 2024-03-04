using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEffect : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Player_Movement player_Movement;
    [SerializeField] Shuriken_Scripts shuriken_Scripts;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        activeCharging();
    }
    private void activeCharging()
    {
        //if (shuriken_Scripts.chargeTime >= 1.8f)
        //{
        //    animator.SetBool("IsCharging", true);
        //}
        //else
        //{
        //    animator.SetBool("IsCharging", false);
        //}
    }
}
