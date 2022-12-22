using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] GameObject testSlime;
    public GameObject Player;
    private Vector2 PlayerPos;
    public GameObject Tilemap;
    private Vector2 SlimePos;
    
    public static SlimeManager instance;
    private int hp = 1;
    private float time = 0;
    private int dir = 0;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }   
    void Start()
    {
        this.gameObject.SetActive (false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timeCounter();
        if(time >= 1){
            gameObject.SetActive (true);
            time = 0;
        }
        this.gameObject.transform.Translate (dir * 0.005f, 0,0);

    }

    void timeCounter(){
        time += Time.deltaTime;
    }
    public void OnDamage(){
        hp -= 1;
        if(hp <= 0){
            Die();
        }
        Debug.Log("WWW");
    }
    public void Appear(){
        this.gameObject.SetActive(true);
        this.transform.position = new Vector3(-3.5f, 3.15f, 0);
    }
    void Die(){
        hp = 0;
        this.gameObject.SetActive (false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Tilemap"){
            if(dir == 0){
            dir = 1;
            }else if(dir == 1){
                PlayerPos = GameObject.Find("Player").transform.position;
                SlimePos =GameObject.Find("slime").transform.position;
                if(PlayerPos.x < SlimePos.x){
                    dir = -1;
                }else if(SlimePos.x < PlayerPos.x)
                dir = 1;
            }
        }else if(collision.gameObject.name == "Player"){
            this.gameObject.SetActive (false);
        }
    }
}