using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScene : MonoBehaviour
{
    [SerializeField] Text timeLeft;
    [SerializeField] Text gold;
    private float timeRemain = 0;
    private float playerGold = 0;
    private float totalGold = 0;
    private float animationTime = 13f;
    public float startAnimation = 2f;
    // Start is called before the first frame update
    void Start()
    {
        timeRemain = PlayerPrefs.GetInt("timeLeft", 10);
        playerGold = PlayerPrefs.GetInt("gold", 0);
        totalGold = playerGold + timeRemain;
        PlayerPrefs.SetInt("gold", (int)totalGold);

        timeLeft.text = timeRemain.ToString("0");
        gold.text = playerGold.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        if (startAnimation > 0)
        {
            startAnimation -= Time.deltaTime;
            return;
        }
        float dif = animationTime * Time.deltaTime;
        timeRemain -= dif;
        playerGold += dif;
        if (playerGold > totalGold || timeRemain < 0)
        {
            playerGold = totalGold;
            timeRemain = 0;
        }
        timeLeft.text = timeRemain.ToString("0");
        gold.text = playerGold.ToString("0");

    }

}
