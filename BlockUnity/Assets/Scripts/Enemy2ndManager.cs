using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2ndManager : MonoBehaviour
{
    [SerializeField] private DragonManager dragonManager;
    public static Enemy2ndManager instance;
    public int hp = 1;
    private float time = 0;
    private float time2 = 0;
    private int TimeCounterFlag = 0;
    Animator animator;
    Rigidbody2D rb;

    private int flag = 0;
    private int AttackEnable_Flag = 1;
    private int deth_flag = 0;

    void Start()
    {
        this.gameObject.SetActive (false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(TimeCounterFlag == 1){
            timeCounter();
        }
        if(deth_flag == 1){
            time2Counter();
        }
        ChangeEnemy();
    }

    void timeCounter(){
        time += Time.deltaTime;
    }
    void time2Counter(){
        time2 += Time.deltaTime;
    }
    public void Awake(){
        if(instance == null)
        {
            instance = this;
        }
    }
    public void Appear(){
        gameObject.SetActive(true);
    }
    public void OnDamage(){
        hp -= 1;
        animator.SetTrigger("isHurt");
        if(hp <= 0){
            Die();
        }
    }
    public void Attack(){
        if(AttackEnable_Flag == 1){
            animator.SetTrigger("AttackTrigger");
            SlimeManager.instance.Appear();
        }
    }
    public void Die(){
        hp = 0;
        AttackEnable_Flag = 0;
        animator.SetTrigger("DieTrigger");
        deth_flag = 1;
    }
    void ChangeEnemy(){
        if(time2 >= 0.5){
            this.gameObject.SetActive (false);
            DragonManager.instance.Appear();
        }
    }
}
