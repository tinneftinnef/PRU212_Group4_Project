using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken_Information : MonoBehaviour
{
    [SerializeField] private float shurikenSpeed;
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        shurikenSpeed = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * shurikenSpeed;
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
