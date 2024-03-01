using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Player_Movement player_Movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_Movement.jumpCheck == 1)
        {
            animator.SetTrigger("DoubleJump");
        }
        animator.SetBool("DoneDoubleJump", true);
        if (player_Movement.IsGrounded())
        {
            animator.SetBool("DoneDoubleJump", false);
        }
    }
}
