using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    [SerializeField] public Text goldText;
    private int goldAmount;
    [SerializeField] public GameObject btnPink;

    // Start is called before the first frame update
    void Start()
    {
        goldAmount = PlayerPrefs.GetInt(Constant.prefGold, 0);
        goldText.text = goldAmount.ToString();

        PlayerPrefs.SetInt(Constant.skinBtnName[0], 1);

        string name = btnPink.name;
        if (PlayerPrefs.GetInt(name, 0) == 1) // already bought
        {
            setBought(btnPink);
        }

        //for(int i=1; i<skinBtnName.Length; ++i)
        //{
        //    string name = skinBtnName[i];
        //    if(PlayerPrefs.GetInt(name, 0) == 1) // already bought
        //    {
        //        //GameObject btn = transform.GetComponentInChildFind(name).gameObject;
        //        //setBought(btn);
        //    }
        //}
    }


    public void BuySkin(GameObject btn)
    {
        //int skinPrice = Constant.skinPrice[i];
        //if (skinPrice <= goldAmount)
        //{

        //}
        string name = btn.name;
        GameObject price = btn.transform.Find("price").gameObject;
        TextMeshProUGUI priceText = price.GetComponent<TextMeshProUGUI>();
        int skinPrice = int.Parse(priceText.text);
        if (skinPrice < goldAmount)
        {
            setBought(btn);
            PlayerPrefs.SetInt(name, 1);
            goldAmount -= skinPrice;
            goldText.text = goldAmount.ToString();
            PlayerPrefs.SetInt(Constant.prefGold, goldAmount);
        }
    }

    void setBought(GameObject btn)
    {
        GameObject icon = btn.transform.Find("icon").gameObject;
        icon.SetActive(false);
        GameObject price = btn.transform.Find("price").gameObject;
        price.SetActive(false);
        Image image = btn.GetComponent<Image>();
        image.color = new Color(0f, 0.54f, 0.26f, 1f);
    }
}
