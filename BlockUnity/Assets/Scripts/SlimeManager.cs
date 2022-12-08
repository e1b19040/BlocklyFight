using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    
    public static SlimeManager instance;
    private int hp = 1;
    private float time = 0;

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

        this.gameObject.transform.Translate (0.001f, 0,0);
        
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
    }
    void Die(){
        hp = 0;
        this.gameObject.SetActive (false);
    }
}
