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
        if(Input.GetKey("a")) {
            Debug.Log("A-String");
        }
        if(Input.GetKey(KeyCode.A)) {
            Debug.Log("A-KeyCode-");
        }
    }
}
