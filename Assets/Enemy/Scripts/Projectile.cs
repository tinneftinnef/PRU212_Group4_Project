using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float resetTime;
    private float lifetime;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivateProjectile()
    {

        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

   
}
