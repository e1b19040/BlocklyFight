using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlocklyPlay : MonoBehaviour
{
    void Start()
    {
    
    }
    
    
    void Update()
    {
    
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
        //PlayerManager.instance.Attack();
    }
}
