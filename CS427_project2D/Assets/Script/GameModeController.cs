using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    CameraFollow cameraScript;
    private CountDownTimer timerScript;
    public float duration = -1;
    
    GameModeController()
    {
    }
    
    void Start()
    {
        timerScript = GetComponent<CountDownTimer>();
        timerScript.resetDuration(duration);

        int skinIndex1 = PlayerPrefs.GetInt("skin1",0);
        loadSkinPlayer(1, skinIndex1, false);
        if (PlayerPrefs.GetInt("mode") == 1)
        {
            loadSinglePlayerMode();
        }
        else
        {
            int skinIndex2 = PlayerPrefs.GetInt("skin2", 0);
            bool isChangeColor = false;
            if (skinIndex1 == skinIndex2)
                isChangeColor = true;
            loadSkinPlayer(2, skinIndex2, isChangeColor);
        }

    }



    void loadSinglePlayerMode()
    {
        obj2.SetActive(false);

        // set canvas text in center horizon
        Canvas canvas = obj1.GetComponentInChildren<Canvas>();

        Text text = canvas.GetComponentInChildren<Text>();
        RectTransform rectTransform = text.GetComponent<RectTransform>();
        Vector3 newPos = rectTransform.position;
        newPos.x += newPos.x;
        rectTransform.position = newPos;

        // set camera fit resolution
        Camera camera = obj1.GetComponentInChildren<Camera>();
        camera.rect = new Rect(0, 0, 1, 1);
        camera.orthographicSize /= 2;
        float halfHeight = camera.orthographicSize;

        cameraScript = camera.GetComponent<CameraFollow>();
        cameraScript.minY -= halfHeight;
        cameraScript.maxY += halfHeight;
        cameraScript.dif /= 2;

    }

    public void loadSkinPlayer(int playerNo, int skinIndex, bool isChangeColor)
    {
        GameObject obj;
        switch (playerNo)
        {
            case 2:
                obj = obj2;
                break;
            case 1:
            default: 
                obj = obj1;
                break;
        }

        GameObject cat = obj.transform.GetChild(2).gameObject;
        ChangeSkin skinScript = cat.GetComponent<ChangeSkin>();
        switch (skinIndex)
        {
            case 0:
                skinScript.changeSnowSkin();
                break;
            case 1:
                skinScript.changeRoseSkin();
                break;
        }
        if (isChangeColor)
        {
            cat.GetComponent<SpriteRenderer>().color = new Color(0.83f, 0.67f, 0.22f, 1f);
        }
            
    }


}
