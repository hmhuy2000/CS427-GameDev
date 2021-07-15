using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployItem : MonoBehaviour
{
    public GameObject  hookPrefab;
    public bool useSpring = true;
    void Start()
    {
        StartCoroutine(itemWave());
    }

    void spawnItem(){
        if (useSpring ==true){
            GameObject  a = Instantiate(hookPrefab) as GameObject ;
            a.transform.position = new Vector2(Random.Range(-5f, 5f), -5f);
        }
    }

    IEnumerator itemWave(){
        while(true){
            
            yield return new WaitForSeconds(Random.Range(10, 30));
            spawnItem();
        }
    }
}
