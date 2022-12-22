using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private PlayerManager playerManager;

    public float moveSpeed = 3; 
    public int hp = 2;
    public int rnd;
    public int a = 0;
    public int xVector =1;
    public int STOP = 0;
    public float gravity;

    public GameObject Player;
    public GameObject Enemy;
    public Transform target;
    public Transform AttackPoint;
    public float attackRadius;
    public LayerMask playerLayer;
    private Vector2 PlayerPos;
    private Vector2 EnemyPos;
    private Vector2 position;
    
    private int flag = 0;
    private int time2Flag = 0;
    private int moveFlag = 1;
    private int AttackFlag = 1;
    private int AttackTimeCounter_flag = 0;
    int moveEnable_flag = 0;

    private float time = 0;
    private float time2 = 0;
    private float attackTime = 0;
    Animator animator;
    Rigidbody2D rb;



    void Start()
    {
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
        if(AttackTimeCounter_flag == 1){
            AttackTimeCounter();
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
    void AttackTimeCounter(){
        attackTime += Time.deltaTime;
    }
    void moveEnemy(){
        time2Counter();
        if(time2 >= 1.5 && moveEnable_flag == 0){
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
                    transform.position = Vector2.MoveTowards(EnemyPos, targetPos, 1.5f * Time.deltaTime);
                }else if (1<time2 && time2<2){
                    animator.SetBool("RunFlag", false);
                    if(AttackFlag == 1){
                        //Attack();
                        AttackFlag = 0;
                    }
                }else if(2<=time2){
                    time2 = 0;
                    AttackFlag = 1;
                }
            }
        }
    
        
    }
    void Attack(){
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(AttackPoint.position,attackRadius,playerLayer);
        foreach(Collider2D hitEnemy in hitEnemys)
        {
            hitEnemy.GetComponent<PlayerManager>().onDamage();
        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position,attackRadius);
    }
    public void OnDamage(){
        hp -= 1;
        animator.SetTrigger("isHurt");
        if(hp <= 0){
            Die();
        }
        
        AttackTimeCounter_flag = 1;
        if(attackTime >= 0.5){
            Attack();  
            AttackTimeCounter_flag = 0;
            attackTime = 0;
            Debug.Log("enemy 136");
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
            Enemy2ndManager.instance.Attack();
        }
    }

    
}
