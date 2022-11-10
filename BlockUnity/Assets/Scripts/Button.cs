using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [DllImport("__Internal")]

    private static extern void doCode();
    
    private float time;
    //public Button btn;


    void Start()
    {
        time = 5;
    }

    void Update()
    {
        time += Time.deltaTime;
        ButtonOnOff();
    }

    public void Run()
    {
        doCode();
    }
    public void ButtonOnOff()
    {
        /*if(time <= 5){
            btn.Interactable = false;
        }else{
            btn.interactable = true;
        }*/
    }
}
