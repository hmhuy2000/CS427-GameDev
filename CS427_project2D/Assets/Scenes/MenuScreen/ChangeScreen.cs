using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ModeSingleScene(string sceneName)
    {
        PlayerPrefs.SetInt("mode", 1);
        LoadScene(sceneName);
    }

    public void ModeMultiScene(string sceneName)
    {
        PlayerPrefs.SetInt("mode", 2);
        LoadScene(sceneName);
    }

    public void LoadLevel(int level)
    {
        int maxUnlockedLevel = PlayerPrefs.GetInt("maxUnlockedLevel", 1);
        if (level <= maxUnlockedLevel)
        {
            PlayerPrefs.SetInt("level", level);
            LoadScene("Level" + level);
        }
    }

}
