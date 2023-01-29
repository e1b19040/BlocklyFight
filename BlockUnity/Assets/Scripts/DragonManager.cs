using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonManager : MonoBehaviour
{
    public static DragonManager instance;
    private float time = 0;
    private float time2 = 0;
    private int flag = 0;
    private Vector2 DragonPos;

    private int moveFlag = 1;
    


    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        this.gameObject.SetActive (false);
        DragonPos =GameObject.Find("Dragon").transform.position;
        //animator = GetComponent<Animator>();
        moveFlag = 1;
    }
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        
        if(moveFlag == 1){
            timeCounter();
            Movement();
        }
        if(flag == 1){
            time2Counter();
        }
        Debug.Log(time2);
        dethDragon();
    }
    

    private void Movement(){
        if(time < 10){
            transform.localScale = new Vector3(1,1,1);
            this.gameObject.transform.Translate (0.003f, 0,0);
        }else if(10 <= time && time < 20){
            transform.localScale = new Vector2(-1,1);
            this.gameObject.transform.Translate (-0.003f, 0,0);
        }else if(time >= 20){
            time = 0;
        }
    }
    public void MoveEnable(){
        moveFlag = 1;
    }
    public void Moveimp(){
        moveFlag = 0;
    }
    void timeCounter(){
        time += Time.deltaTime;
    }
    void time2Counter(){
        time2 += Time.deltaTime;
    }
    public void Appear(){
        this.gameObject.SetActive(true);
    }
    public void OnDamage(){
        flag = 1;
        animator.SetTrigger("OnDamage");
    }
    void dethDragon(){
        if(time2 >= 0.3){
            this.gameObject.SetActive (false);
            Menu.instance.Pause();
        } 
    }
    
}