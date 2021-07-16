using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultplayerResult : MonoBehaviour
{
    [SerializeField] Image cat1;
    [SerializeField] Image cat2;
    [SerializeField] AnimatorOverrideController roseAnim;
    [SerializeField] AnimatorOverrideController snowAnim;
    Sprite rose = null;
    Sprite snow = null;
    int skin1 = 0;
    int skin2 = 0;


    // Start is called before the first frame update
    void Start()
    {
        rose = Resources.Load<Sprite>("CatRose_5");
        snow = Resources.Load<Sprite>("Cat Sprite Sheet_7");
        skin1 = PlayerPrefs.GetInt(Constant.prefSkin1, 0);
        skin2 = PlayerPrefs.GetInt(Constant.prefSkin2, 0);
        int winner = PlayerPrefs.GetInt(Constant.prefWinner, 0);
        Debug.Log("winner is " + winner);
        loadWinner(winner);
    }

    void loadWinner(int player)
    {       
        int skin = player == 1 ? skin1 : skin2;
        Sprite sp = skin == 0 ? snow : rose;
        AnimatorOverrideController anim = skin == 0 ? snowAnim : roseAnim;

        cat1.GetComponent<Image>().sprite = sp;
        cat1.GetComponent<Animator>().runtimeAnimatorController = anim as RuntimeAnimatorController;
        if (player == 2 && skin1 == skin2)
            cat1.color = new Color(0.83f, 0.67f, 0.22f, 1f);
    }

    void loadBoth()
    {
        cat2.gameObject.SetActive(true);
        Vector2 pos1 = new Vector2(-cat2.transform.position.x, cat2.transform.position.y);
        cat1.transform.position = pos1;
        cat1.GetComponent<Image>().sprite = skin1 == 0 ? snow : rose;
        cat2.GetComponent<Image>().sprite = skin2 == 0 ? snow : rose;
        cat1.GetComponent<Animator>().runtimeAnimatorController = skin1 == 0 ? snowAnim : roseAnim as RuntimeAnimatorController;
        cat1.GetComponent<Animator>().runtimeAnimatorController = skin2 == 0 ? snowAnim : roseAnim as RuntimeAnimatorController;
        if (skin1 == skin2)
            cat2.color = new Color(0.83f, 0.67f, 0.22f, 1f);
    }
}
