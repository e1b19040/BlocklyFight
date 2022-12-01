using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int hp = 5;
    public GameObject Player;
    public float moveSpeed = 3;
    private int flag = 0;
    private float time = 0;
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //EnemyIdle();
        //Movement();
        if(flag == 1)
        {
            timeCounter();
        }
        ChangeEnemy();
    }
    
    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
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
    
    void timeCounter()
    {
        time += Time.deltaTime;
    }

    void EnemyIdle()    
    {
        rb.velocity = new Vector2(0,0);
    }


    public void OnDamage()
    {
        hp -= 1;
        animator.SetTrigger("isHurt");
        if(hp <= 0){
            Die();
        }
    }

    void Die()
    {
        hp = 0;
        flag = 1;
        animator.SetTrigger("Die");
    } 

    void ChangeEnemy()
    {
         if(time >= 3){
            this.gameObject.SetActive (false);
            Enemy2ndManager.instance.Appear();
        }
    }

    
}
