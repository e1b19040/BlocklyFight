using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private PlayerManager playerManager;

    public float moveSpeed = 3; 
    public int hp = 5;
    public int rnd;
    public int a = 0;
    public int xVector =1;
    public int STOP = 0;
    public float gravity;

    public GameObject Player;
    public GameObject Enemy;
    public Transform target;
    private Vector2 PlayerPos;
    private Vector2 EnemyPos;
    private Vector2 position;
    
    private int flag = 0;
    private int time2Flag = 0;
    private int moveFlag = 1;
    int moveEnable_flag = 0;

    private float time = 0;
    private float time2 = 0;
    Animator animator;
    Rigidbody2D rb;



    void Start()
    {
        this.gameObject.SetActive (false);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        PlayerPos = GameObject.Find("Player").transform.position;
        EnemyPos =GameObject.Find("Enemy").transform.position;
    }

    void Update()
    {
        if(flag == 1){
            timeCounter();
        }
        if(time2Flag == 1){
            time2Counter();
        }
        ChangeEnemy();
        moveEnemy();
        
        
    }
    void timeCounter(){
        time += Time.deltaTime;
    }
    void time2Counter(){
        time2 += Time.deltaTime;
    }   
    void moveEnemy(){
        time2Counter();

        if(time2 >= 3 && moveEnable_flag == 0){
            moveEnable_flag = 1;
            time2 = 0;
        }

        if(moveEnable_flag == 1){
            if(flag == 0){
                if(time2 <= 0.2){
                    PlayerPos = GameObject.Find("Player").transform.position;
                    EnemyPos =GameObject.Find("Enemy").transform.position;
                    if(PlayerPos.x < EnemyPos.x){
                        transform.localScale = new Vector3(1,1,1);
                    }
                    if(EnemyPos.x < PlayerPos.x){
                        transform.localScale = new Vector3(-1,1,1);
                    }
                }else if(0.2 < time2 && time2<1){
                    animator.SetBool("RunFlag", true);
                    EnemyPos = transform.position;
                    Vector2 targetPos = PlayerPos;
                    transform.position = Vector2.MoveTowards(EnemyPos, targetPos, 2.0f * Time.deltaTime);
                }else if (1<time2 && time2<2){
                    animator.SetBool("RunFlag", false);
                }else if(2<=time2){
                    time2 = 0;
                }
            }
        }
    
        
    }
    public void OnDamage(){
        hp -= 1;
        animator.SetTrigger("isHurt");
        if(hp <= 0){
            Die();
        }
    }
    void Die(){
        hp = 0;
        flag = 1;
        animator.SetTrigger("Die");
    } 
    void ChangeEnemy(){
         if(time >= 3){
            this.gameObject.SetActive (false);
            Enemy2ndManager.instance.Appear();
        }
    }

    
}
