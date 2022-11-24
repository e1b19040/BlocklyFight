using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class BlocklyPlay : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void doCode();
    private int flag = 1;
    private float time = 0;

    void Start()
    {
    
    }
    
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Run();
        }
        if(flag == 0){
            timeCounter();
        }
    }

    void timeCounter()
    {
        time += Time.deltaTime;
        if(time > 3){
            time = 0;
            flag = 1;
        }

    }

    public void Run()
    {
        if(flag == 1){
            doCode();
            flag = 0;
        }
    }

    public void MoveLeft()
    {
        Debug.Log("moveleft");
        transform.position -= new Vector3(1,0,0);
    }
    public void MoveRight()
    {
        Debug.Log("moveright");
        transform.position += new Vector3(1,0,0);
    }
    public void Attack()
    {
        Debug.Log("BlockAttack");
        PlayerManager.instance.Attack();
    }
    public void Attackif(){
        Vector2 plypos = GameObject.Find("Player").transform.position;
        Vector2 emypos = GameObject.Find("Enemy").transform.position;
        Debug.Log(plypos);
        Debug.Log(emypos);
        Debug.Log(plypos.x); Debug.Log(emypos.x);Debug.Log(plypos.x + 2);
        

        if(plypos.x < emypos.x){
            Debug.Log("1"); 
            PlayerManager.instance.Attack();
        }else{
            Debug.Log("73失敗");
        }
        if(plypos.x-2 < emypos.x && emypos.x < plypos.x){
            PlayerManager.instance.Attack();
            Debug.Log("2"); 
        }
    }
    public double Enemypos()
    {
        Vector2 tmp = GameObject.Find("Enemy").transform.position;
        Debug.Log(tmp); 
        return tmp.x;
    }

    
}
