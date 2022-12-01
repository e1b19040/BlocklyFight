using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float speed;
    public float moveSpeed = 3; 
    public int hp = 5;
    public int rnd;
    public int a = 0;
    public int xVector =1;
    public int STOP = 0;
    public float gravity;

    public GameObject Player;
    public GameObject Enemy;
    private Vector2 PlayerPos;
    private Vector2 EnemyPos;
    private Vector2 position;
    
    private int flag = 0;
    private int time2Flag = 0;
    private int moveFlag = 1;

    private float time = 0;
    private float time2 = 0;
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        //position = Enemy.transform.position;
        //RandomNum();
    }

    void Update()
    {
        PlayerPos = GameObject.Find("Player").transform.position;
        EnemyPos =GameObject.Find("Enemy").transform.position;

        if(flag == 1)
        {
            timeCounter();
        }
        if(time2Flag == 1){
            time2Counter();
        }
        ChangeEnemy();
        Debug.Log(time2);

        //Debug.Log(rnd);
        /*if(1 <= rnd && rnd <= 2){
            while(a < 10){
                Invoke(nameof(ChasePlayer), 0.1f);
                ++a;
                Debug.Log(a);
            }
            a = 0;
            RandomNum();
        }else{
            Debug.Log("乱数攻撃");
            RandomNum();
        }*/
        /*if(rnd == 0 ||rnd == 1 || rnd ==2){
            Debug.Log("１or２");
            moveEnemy();
            time2Counter();
        }else if(rnd == 3 || rnd ==4){

        }else{
            Debug.Log(rnd);
        }*/

        //moveEnemy();
        if(PlayerPos.x == EnemyPos.x){
            moveFlag = 0;
                Debug.Log("MOVEFLAG" + moveFlag);
        }
    }

    void RandomNum(){
        rnd = Random.Range(2, 10);
    }
    void timeCounter(){
        time += Time.deltaTime;
    }
    void time2Counter(){
        time2 += Time.deltaTime;
    }
    void moveEnemy(){
        if((PlayerPos.x < EnemyPos.x) && moveFlag == 1){
            moveFlag=0;
            time2Flag=1;
            while(time2 <= 2){
                rb.velocity = new Vector2(-xVector * speed, -gravity);
            }

            //time2 =0;
            /*while(time2 <= 1){
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }*/
            //time2 =0;
            //time2Flag=0;
            moveFlag = 1;
            Debug.Log("moveEnemy1");
        }else if((PlayerPos.x > EnemyPos.x)&& moveFlag == 1){
            rb.velocity = new Vector2(xVector * speed, -gravity);
            Debug.Log("moveEnemy2");
        }else if(PlayerPos.x == EnemyPos.x){
            time2Counter();
            while(time2 < 3){
                moveFlag = 0;
                Debug.Log("MOVEFLAG" + moveFlag);
            }
            time2 = 0;
            moveFlag = 1;
            Debug.Log("moveEnemy3");
        }
      }
    /*void ChasePlayer(){
        PlayerPos = Player.transform.position;
        EnemyPos = transform.position;
        if (PlayerPos.x > EnemyPos.x)
        {
            EnemyPos.x = EnemyPos.x + 0.1f;
        }
        else if (PlayerPos.x < EnemyPos.x)
        {
            EnemyPos.x = EnemyPos.x - 0.1f;
        }
 
        transform.position = EnemyPos;
    }*/

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
