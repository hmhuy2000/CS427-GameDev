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
        int mode = PlayerPrefs.GetInt(Constant.prefMode, 1);
        switch (mode)
        {
            case 1:
                Time.timeScale = 0;
                gameObject.SetActive(true);
                gameOverText.enabled = true;
                resumeBtn.SetActive(false);
                cat1.enabled = false;
                cat2.enabled = false;
                break;
            case 2:
                displayWinnerPlayer();
                break;
        }
    }

    void displayWinnerPlayer()
    {
        float y1 = cat1.transform.position.y,
            y2 = cat2.transform.position.y;
        Debug.Log("y1 " + y1);
        Debug.Log("y2 " + y2);
        int id = cat1.getID();
        if (y1 < y2)
            id = cat2.getID();
        else if (y1 == y2)
            id = 0;
        PlayerPrefs.SetInt(Constant.prefWinner, id);
        SceneManager.LoadScene("VictoryMulti");
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

    public void NextLevel() // call when finish a round -> already unlock next level, but in multiplayer not
    {
        int nextLevel = PlayerPrefs.GetInt(Constant.prefLevel, 1) + 1;
        int maxUnlockedLevel = PlayerPrefs.GetInt(Constant.prefMaxUnlockedLevel, 1);
        if (nextLevel <= maxUnlockedLevel)
        {
            PlayerPrefs.SetInt(Constant.prefLevel, nextLevel);
            SceneManager.LoadScene("Level" + nextLevel);
            return;
        }

        int mode = PlayerPrefs.GetInt(Constant.prefMode, 1);
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
