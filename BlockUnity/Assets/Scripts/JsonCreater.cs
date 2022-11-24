using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
/*

[System.Serializable]
public class Data
{
    public List<EnemyData> EnemyData;
}

[System.Serializable]
public class EnemyData
{
    public string name;
    public float x;
    public float y;
    
    public EnemyData(string name, float x, float y)
    {
        this.name = name;
        this.x = x;
        this.y = y;
    }
}

public class JsonCreater : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void setData(string data);
    void Update()
    {
        //test();
    }

    void test(){
        Data data = new Data();
        data.EnemyData = new List<EnemyData>();
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject enemy in enemys){
            if(enemy.activeInHierarchy){
                EnemyData enemypos = new EnemyData(enemy.name, enemy.transform.position.x, enemy.transform.position.y);
                data.EnemyData.Add(enemypos);
            }
        }
        //setData(JsonUtility.ToJson(data));
    }
}*/