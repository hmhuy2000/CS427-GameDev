using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployItem : MonoBehaviour
{
    public GameObject  hookPrefab;
    void Start()
    {
        StartCoroutine(itemWave());
    }

    void spawnItem(){
        GameObject  a = Instantiate(hookPrefab) as GameObject ;
        a.transform.position = new Vector2(0, -5f);
    }

    IEnumerator itemWave(){
        while(true){
            
            yield return new WaitForSeconds(Random.Range(5, 60));
            spawnItem();
        }
    }
}
