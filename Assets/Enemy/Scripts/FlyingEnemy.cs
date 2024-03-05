using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float Speed;
    private GameObject player;
    private Animator animator;

    public bool Target
    {
        get
        {
            return animator.GetBool("target");
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        Flip();
        if (Target)
        {
            Speed = 0;
            animator.SetBool("canmove", true);
        }
        else
        {
            animator.SetBool("canmove", false);

        }
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed*Time.deltaTime);
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0,180,0);
        else
            transform.rotation = Quaternion.Euler(0,0,0);
    }
}
