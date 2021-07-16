using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    [SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(Constant.prefMaxUnlockedLevel,1)>=level)
            GetComponent<Image>().color = new Color(0f, 0.87f, 0.047f, 1f);
    }


}
