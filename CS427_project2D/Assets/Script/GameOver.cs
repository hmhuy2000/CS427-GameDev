using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text gameOverText;
    [SerializeField] GameObject resumeBtn;
    [SerializeField] CatMovement cat1;
    [SerializeField] CatMovement cat2;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
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
        string scene = PlayerPrefs.GetString("scene");
        SceneManager.LoadScene(scene);
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
}
