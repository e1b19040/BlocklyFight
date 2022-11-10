using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public float moveSpeed = 3;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    private int jumpCount = 0;
    private float jumpForce = 480f;
    Rigidbody2D rb;
    Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && this.jumpCount<1)
        {
            Jump();
        }
    }

    public void Attack()
    {
        animator.SetTrigger("isAttack");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position,attackRadius,enemyLayer);
        foreach(Collider2D hitEnemy in hitEnemys)
        {
            hitEnemy.GetComponent<EnemyManager>().OnDamage();
            hitEnemy.GetComponent<Enemy2ndManager>().OnDamage();

        }
    }

    public void Jump()
    {
        this.rb.AddForce(transform.up * jumpForce);
        jumpCount++;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            jumpCount = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
    }
    void Movement()
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
}
