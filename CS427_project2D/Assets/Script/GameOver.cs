using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text gameOverText = null;
    [SerializeField] GameObject resumeBtn = null;
    [SerializeField] CatMovement cat1 = null;
    [SerializeField] CatMovement cat2 = null;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void displayGameOver()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        gameOverText.enabled = true;
        resumeBtn.SetActive(false);
        cat1.enabled = false;
        cat2.enabled = false;
    }

    public void RestartBtn()
    {
        Time.timeScale = 1;
        int scene = PlayerPrefs.GetInt("level",1);
        SceneManager.LoadScene("Level"+scene);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeBtn()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        cat1.enabled = true;
        cat2.enabled = true;
    }

    public void displayPausePopup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        gameOverText.enabled = false;
        resumeBtn.SetActive(true);
        cat1.enabled = false;
        cat2.enabled = false;
    }

    public void NextLevel() // call when finish a round -> already unlock next level
    {
        int nextLevel = PlayerPrefs.GetInt("level", 1) + 1;
        int maxUnlockedLevel = PlayerPrefs.GetInt("maxUnlockedLevel", 2);
        if (nextLevel <= maxUnlockedLevel)
        {
            PlayerPrefs.SetInt("level", nextLevel);
            SceneManager.LoadScene("Level" + nextLevel);
            return;
        }

        int mode = PlayerPrefs.GetInt("mode", 1);
        if (mode == 1)
        {
            SceneManager.LoadScene("SingleMode");
        }
        else if (mode == 2)
        {
            SceneManager.LoadScene("MultipleMode");
        }
    }
}
