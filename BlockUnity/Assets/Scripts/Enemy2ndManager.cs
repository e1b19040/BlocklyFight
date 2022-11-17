using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2ndManager : MonoBehaviour
{
    public static Enemy2ndManager instance;
    public int hp = 5;
    private int flag = 0;
    private float time = 0;
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        this.gameObject.SetActive (false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        EnemyIdle();
    }

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void EnemyIdle()
    {
        rb.velocity = new Vector2(0,0);
    }

    public void Appear()
    {
        gameObject.SetActive(true);
    }

    public void OnDamage()
    {
        hp -= 1;
        animator.SetTrigger("isHurt");
        /*if(hp <= 0){
            Die();
        }*/
    }
}
