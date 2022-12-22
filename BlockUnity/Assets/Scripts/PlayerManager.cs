using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private  SlimeManager slimeManager;
    [DllImport("__Internal")]
    private static extern void PlayerData(float x,float y);
    public static PlayerManager instance;
    public float moveSpeed = 2;
    private int hp = 3;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    private int jumpCount = 0;
    private int moveEnable_flag = 1;
    private float jumpForce = 480f;
    Rigidbody2D rb;
    Animator animator;

    public GameObject slime;
    public GameObject slime2;
    public GameObject slime3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        slimeManager.Appear();
    }

    void Update()
    {
        if(moveEnable_flag == 1){
            Movement();
            if(Input.GetMouseButtonUp(0)){
                Attack();
                Debug.Log("attack");
            }
            if((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && this.jumpCount<1){
                Jump();
            }
        }
        if(hp == 0){
            Die();
        }


    }

    public void Attack()
    {
        animator.SetTrigger("isAttack");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position,attackRadius,enemyLayer);
        foreach(Collider2D hitEnemy in hitEnemys)
        {
            if(hitEnemy.gameObject.name == "Enemy"){
                hitEnemy.GetComponent<EnemyManager>().OnDamage();
            }else if(hitEnemy.gameObject.name == "slime"){
                hitEnemy.GetComponent<SlimeManager>().OnDamage();
            }else if(hitEnemy.gameObject.name == "Enemy2nd"){
                hitEnemy.GetComponent<Enemy2ndManager>().OnDamage();
            }
        }
    }

    public void Jump()
    {
        this.rb.AddForce(transform.up * jumpForce);
        jumpCount++;
    }
    private void OnCollisionEnter2D(Collision2D other) //衝突時
    {
        if (other.gameObject.CompareTag("ground"))
        {
            jumpCount = 0;
        }
        if(other.gameObject.name == "slime"){
            onDamage();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
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
    public void onDamage(){
        animator.SetTrigger("OnDamage");
        hp -= 1;
        if(hp <= 0){
            Die();
        }
    }
    void Die(){
        hp = 0;
        moveEnable_flag = 0;
        animator.SetTrigger("Die");
    } 
}
