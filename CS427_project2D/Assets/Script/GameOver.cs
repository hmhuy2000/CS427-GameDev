using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void display()
    {
        gameObject.SetActive(true);
    }

    public void RestartBtn()
    {
        PlayerPrefs.SetInt("mode", 1);
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("mode", 2);
        SceneManager.LoadScene("GamePlay");
    }
}
