using UnityEngine;

public class AudioSettingTutorial : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private float backgroundFloat;
    public AudioSource[] backgroundAudio;

    void Awake()
    {
        ContinueSettings();
    }
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref, 0.25f);
        for (int i = 0; i < backgroundAudio.Length; i++)
        {
            backgroundAudio[i].volume = backgroundFloat;
        }
    }    

}
