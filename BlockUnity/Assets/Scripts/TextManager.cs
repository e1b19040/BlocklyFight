using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class TextManager : MonoBehaviour
{
    [SerializeField] Text text;
 
    private int flag = 0;
    /*void Update()
    {
        if(Input.GetKeyDown("space")){
            if(flag == 0){
                flag =1;
            }else{
                flag = 0;
            }
        }

        if(flag == 0){
            text.enabled = false;
        }else if (flag==1){
            text.enabled = true;
        }
    }*/
}