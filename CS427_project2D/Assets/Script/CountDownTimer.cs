using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{
    public float duration = 60f;
    float timeLeft = 0f;
    [SerializeField] Text countDownText;
    [SerializeField] Text countDownText2;
    public GameOver gameOverScript;


    void Start()
    {
        timeLeft = duration;
        countDownText.text = timeLeft.ToString("0");
        countDownText2.text = timeLeft.ToString("0");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
        timeLeft -= 1*Time.deltaTime;
        if (timeLeft < 0)
        {
            //Todo trigger another event;
            gameOver();           
            timeLeft = 0;
        }
        countDownText.text = timeLeft.ToString("0");
        countDownText2.text = timeLeft.ToString("0");
    }

    void pauseGame()
    {
        gameOverScript.displayPausePopup();
    }

    public void resetDuration(float dur)
    {
        timeLeft = dur;
        duration = dur;
    }

    void gameOver()
    {
        gameOverScript.displayGameOver();
    }
}
