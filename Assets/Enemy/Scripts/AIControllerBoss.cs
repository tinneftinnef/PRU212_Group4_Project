using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AIControllerBoss : MonoBehaviour
{
    public Transform player;
    public bool flip;
    [SerializeField] public float speed;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Start()
    {
        speed = 5f * PauseGame.increaseEnemyStats();
    }
    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 scale = transform.localScale;
        if(scale.x > 0)
        {
            if (player.transform.position.x -4f > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime * -1, 0, 0);
            }
            transform.localScale = scale;
        } else if(scale.x < 0)
        {
            if (player.transform.position.x + 4f > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime * -1, 0, 0);
            }
            transform.localScale = scale;
        }
        
        if (BossCheckFollow.canMove == true)
        {
            speed = 0;
            animator.SetBool("canmove", true);
        }
        else
        {
            speed = 2;
            animator.SetBool("canmove", false);
        }
    }
}
