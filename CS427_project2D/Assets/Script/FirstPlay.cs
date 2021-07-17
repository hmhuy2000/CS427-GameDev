using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Application.isEditor == false)
        {
            int firstPlay = PlayerPrefs.GetInt(Constant.prefFirstTimePlay, 0);
            if(firstPlay == 0)
            {
                Debug.Log("first time");
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetInt(Constant.prefFirstTimePlay, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
