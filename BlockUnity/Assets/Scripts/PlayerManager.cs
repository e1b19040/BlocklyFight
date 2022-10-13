using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 3;
    Rigidbody2D rb;
    Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Debug.Log(x);
        if(x > 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if(x < 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        animator.SetFloat("Speed",Mathf.Abs(x));
        rb.velocity = new Vector2(x*moveSpeed,rb.velocity.y);
    }
}
