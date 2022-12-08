using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class BlocklyPlay : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void doCode();
    [DllImport("__Internal")]
    private static extern void testMessage(string flag);
    private int flag = 1;
    private int BlockOnOff = 0;
    private int testflag = 1;

    [SerializeField] private PlayerManager playerManager;

    void Start()
    {
    
    }
    
    void Update()
    {
        /*if(Input.GetKeyDown("space"))
        {
            if(BlockOnOff == 0){
                BlockOnOff = 1;
            }else{
                BlockOnOff = 0;
            }
        }
        if(BlockOnOff == 1){
            doCode();
        }*/

        if(Input.GetKeyDown("space")){
            doCode();
        }
        if(Input.GetKey("space")){
            Invoke(nameof(DoCode), 0.5f);
        }
    }

    void DoCode(){
        if(Input.GetKey("space")){
            doCode();
        }
    }

    public void CheckRange3(){
        Vector2 plypos = GameObject.Find("Player").transform.position;
        Vector2 emypos = GameObject.Find("Enemy").transform.position;
        Debug.Log(Mathf.Abs(plypos.x));Debug.Log(emypos.x);

        if(plypos.x > 0 && emypos.x > 0){
            if(Mathf.Abs(Mathf.Abs(plypos.x) - Mathf.Abs(emypos.x)) < 2){
                testMessage("true");
            }
        }else if(plypos.x < 0 && emypos.x < 0){
            if(Mathf.Abs(Mathf.Abs(plypos.x) - Mathf.Abs(emypos.x)) < 2){
                testMessage("true");
            }
        }else{
            testMessage("false");
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
        playerManager.Attack();
    }
}
