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
            Debug.Log("1pass");
        }
        if(flag == 0){
            timeCounter();
            Debug.Log("counting");
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

    
}
