using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Animator animator;
    public DetectionZone attackZone;
    public bool _target = false;
    private bool dead;
    public bool target
    {
        get { return _target; }
        private set
        {
            _target = value;
            animator.SetBool(AnimationStrings.target, _target);
        }
    }

    public bool isAlive;

    public Health health; // Add this field

    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>(); // Assign the Health component here

    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        target = attackZone.detectedColliders.Count > 0;


        animator.GetBool("isAlive");
        if(isAlive == true)
        {
            GetComponent<Mushroom>().enabled = false;
            GetComponent<AIController>().enabled = false;

        }

    }

   
}