using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour

{
    public Animator animator;
    public DetectionZone attackZone;
    public bool _target = false;
    public bool target { get { return _target; } private set
        {
_target = value;
            animator.SetBool(AnimationStrings.target, _target);
        } }

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
}
