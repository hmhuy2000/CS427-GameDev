using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSkin : MonoBehaviour
{
    [SerializeField] public KeyCode up;
    [SerializeField] public KeyCode down;
    [SerializeField] public GameObject topYObject;
    [SerializeField] public float yDif;
    [SerializeField] public int id;
    private int index = 0;
    private int maxIndex = 1;
    private string key;
    private float topY;

    // Start is called before the first frame update
    void Start()
    {
        topY = topYObject.transform.position.y;
        key = id == 1 ? Constant.prefSkin1 : Constant.prefSkin2;
        index = PlayerPrefs.GetInt(key, 0);
        setPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(up))
        {
            checkPossibleMove(-1);
        }
        else if (Input.GetKeyDown(down))
        {
            checkPossibleMove(1);
        }
    }

    void checkPossibleMove(int val)
    {
        int i = val + index;
        if (i < 0 || i > maxIndex)
            return;

        if (PlayerPrefs.GetInt(Constant.skinBtnName[i]) == 1) // bought
        {
            PlayerPrefs.SetInt(key, i);
            index = i;
            setPosition();
        }
    }

    void setPosition()
    {
        Vector2 pos = new Vector2(transform.position.x, topY - yDif * index);
        Debug.Log("pos y"+ pos.y);
        transform.position = pos;
    }
}
