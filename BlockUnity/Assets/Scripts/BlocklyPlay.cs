using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class BlocklyPlay : MonoBehaviour
{
    public static BlocklyPlay instance;

    [DllImport("__Internal")]
    private static extern void doCode();
    [DllImport("__Internal")]
    private static extern void testMessage(string flag);
    private int flag = 1;
    private bool DoFlag = false;
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
             Debug.Log(DoFlag);
        }
        /*if(Input.GetKeyDown("space") && DoFlag){
            doCode();
        }*/
        if(Input.GetKeyDown("space")  && DoFlag ){
            //Invoke(nameof(DoCode), 0.5f);
            doCode();
            Debug.Log("BlocklyPlay50");
        }
    }

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void DoCode(){
        if(Input.GetKey("space")){
            Debug.Log("blocklyplay59");
            doCode();
            Debug.Log("blocklyplay61");
            Debug.Log(DoFlag);
        }
    }

    public void CheckBlock(int doFlag){
        if(doFlag == 1){
            DoFlag = true;
        }else{
            DoFlag = false;
            Debug.Log("blocklyplay68");
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
        transform.localScale = new Vector3(1,1,1);
        transform.position -= new Vector3(2,0,0);
    }
    public void MoveRight()
    {
        transform.localScale = new Vector3(-1,1,1);
        transform.position += new Vector3(2,0,0);
    }
    public void turnLeft(){
        transform.localScale = new Vector3(1,1,1);
    }
    public void turnRight(){
        transform.localScale = new Vector3(-1,1,1);
    }
    public void Attack()
    {
        Debug.Log("BlockAttack");
        playerManager.Attack();
    }
}
