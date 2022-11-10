using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int hp = 5;
    public int flag = 0;
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
        EnemyIdle();
        if(flag == 1)
        {
            timeCounter();
        }
        ChangeEnemy();
    }

    public void OnDamage()
    {
        hp -= 1;
        animator.SetTrigger("isHurt");
        if(hp <= 0){
            Die();
        }
    }

    void EnemyIdle()
    {
        rb.velocity = new Vector2(0,0);
    }

    void Die()
    {
        hp = 0;
        flag = 1;
        animator.SetTrigger("Die");
        //Enemy2nd.SetActive (false);
    }

    void timeCounter()
    {
        time += Time.deltaTime;
    }

    void ChangeEnemy()
    {
         if(time >= 3){
            this.gameObject.SetActive (false);
            Enemy2ndManager.instance.Appear();
        }
    }

    /*void Appear()
    {
        second.GetComponent<Enemy2ndManager>().SecondAppear();
    }*/
}
