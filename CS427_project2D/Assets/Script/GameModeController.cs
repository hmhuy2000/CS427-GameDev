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
    void Start()
    {
        timerScript = GetComponent<CountDownTimer>();
        timerScript.resetDuration(duration);
        if(PlayerPrefs.GetInt("mode")==1)
            loadSinglePlayerMode();
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
