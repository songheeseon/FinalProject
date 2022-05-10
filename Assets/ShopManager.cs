using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    private int totalCoin;
    private int HpPrice;
    private int AttackDelayPrice;
    private int SpeedPrice;

    public GameObject ShopUI;
    public GameObject UpgradeUI;

    public Text HPcnt;
    public Text AttackDelaycnt;
    public Text Speedcnt;

    public GameObject aaaaaa;

    private void Start()
    {
        totalCoin = PlayerPrefs.GetInt("Money");
        HpPrice = 5;
        AttackDelayPrice = 5;
        SpeedPrice = 5;

        ShopUI.gameObject.SetActive(false);
        UpgradeUI.gameObject.SetActive(false);

        aaaaaa.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateHPcnt();
        UpdateAttackDelaycnt();
        UpdateSpeedcnt();

        if(Ability.instance.HpCnt == 5)
        {
            aaaaaa.gameObject.SetActive(true);
        }

        if (Ability.instance.HpCnt < 5)
        {
            aaaaaa.gameObject.SetActive(false);
        }
    }

    private void UpdateHPcnt()
    {
        HPcnt.text = "" + Ability.instance.HpCnt;
    }

    private void UpdateAttackDelaycnt()
    {
        AttackDelaycnt.text = "" + Ability.instance.AttackDelayCnt;
    }

    private void UpdateSpeedcnt()
    {
        Speedcnt.text = "" + Ability.instance.SpeedCnt;
    }


    public void HpShop()
    {
        if(totalCoin > HpPrice)
        {
            totalCoin = totalCoin - HpPrice;
            PlayerPrefs.SetInt("Money", totalCoin);
            Ability.instance.PlayerHpPlus();
        }

        else if(Ability.instance.HpCnt >= 5)
        {
            Debug.Log("업그레이드 완료");
            UpgradeUI.gameObject.SetActive(true);
            Ability.instance.HpCnt= 5;
            // 업그레이드 완료 
        }

        else
        {
            ShopUI.gameObject.SetActive(true);
        }
    }

    public void AttackDelayShop()
    {
        if (totalCoin > AttackDelayPrice)
        {
            totalCoin = totalCoin - AttackDelayPrice;
            PlayerPrefs.SetInt("Money", totalCoin);
            Ability.instance.PlayerAttackDelayMlnus();
        }

        else if (Ability.instance.AttackDelayCnt >= 5)
        {
            Debug.Log("업그레이드 완료");
            UpgradeUI.gameObject.SetActive(true);
            Ability.instance.AttackDelayCnt = 5;
            // 업그레이드 완료 
        }


        else
        {
            ShopUI.gameObject.SetActive(true);
        }
    }

    public void SpeedPriceShop()
    {
        if (totalCoin > SpeedPrice)
        {
            totalCoin = totalCoin - SpeedPrice;
            PlayerPrefs.SetInt("Money", totalCoin);
            Ability.instance.PlayerSpeedPlus();
        }

        else if (Ability.instance.SpeedCnt >= 5)
        {
            Debug.Log("업그레이드 완료");
            UpgradeUI.gameObject.SetActive(true);
            Ability.instance.SpeedCnt = 5;
            // 업그레이드 완료 
        }

        else
        {
            ShopUI.gameObject.SetActive(true);
        }
    }

    public void BackToGameView()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
