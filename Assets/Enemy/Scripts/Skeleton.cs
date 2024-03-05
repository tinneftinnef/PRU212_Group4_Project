using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : MonoBehaviour

{
    public Animator animator;
    public DetectionZone attackZone;
    public bool _target = false;

    public bool isAlive;
    public bool target { get { return _target; } private set
        {
_target = value;
            animator.SetBool(AnimationStrings.target, _target);
        } }

    public bool dead { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = attackZone.detectedColliders.Count > 0;
    }
    //private void FixedUpdate()
    //{
    //    animator.GetBool("isAlive");
    //    if (isAlive)
    //    {

    //        GetComponent<Skeleton>().enabled = false;
    //        GetComponent<AIController>().enabled = false;
    //    }
    //    dead = true;
    //}
}
