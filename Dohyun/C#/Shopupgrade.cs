using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopupgrade : MonoBehaviour
{

    public int maxHealth, maxAttck, maxArwour;

    int currentHealth, currentAttck, currentArwour;


    int money, currenmoney;

    public Text Skilltext; // 스킬 텍스트
    public Text cashText; //게임 돈
    public Text HText; // 체력 레벨
    public Text AText;
    public Text ArText;


    // Start is called before the first frame update
    void Start()
    {
        SetDefs();
    }

    void SetDefs()
    {

        money = 1000;
        cashText.text = money + "";
        Skilltext.text = "스킬 업그레이드";

        currenmoney = PlayerPrefs.GetInt("money");
        currentHealth = PlayerPrefs.GetInt("health",0);
        currentArwour = PlayerPrefs.GetInt("arwour",0);
        currentAttck = PlayerPrefs.GetInt("attck",0);

        HText.text = currentHealth + "";
        AText.text = currentAttck + "";
        ArText.text = currentArwour + "";

    }

    public void buyhealth(int price)
    {
        if (currentHealth< maxHealth)
        {
            if(money > price)
            {
                money -= price;
                cashText.text = money + "";
                Skilltext.text = currentHealth + "\n체력을 업그레이드 합니다";
                currentHealth += 3;
                PlayerPrefs.SetInt("health", currentHealth);
                PlayerPrefs.SetInt("money", currenmoney);
                HText.text = currentHealth + "";
            }
           
        }
        else
        {
            Debug.Log("체력 업글 끝");
            Skilltext.text = currentHealth + "전부 업그레이드 했습니다.";
        }
    }
    public void buyarwour(int price)
    {
        if (currentArwour < maxArwour)
        {
            if (money > price)
            {
                money -= price;
                cashText.text = money + "";
                currentArwour += 1;
                PlayerPrefs.SetInt("arwour", currentArwour);
                PlayerPrefs.SetInt("money", currenmoney);
                ArText.text = currentArwour + "";
                Skilltext.text = currentArwour + "\n방어력을 업그레이드 합니다";
            }
            

        }
        else
        {
            Debug.Log("방어력 업글 끝");
        }
    }
    public void buyattck(int price)
    {
        if (currentAttck < maxAttck)
        {
            if (money > price)
            {
                money -= price;
                cashText.text = money + "";
                currentAttck += 1;
                PlayerPrefs.SetInt("attck", currentAttck);
                PlayerPrefs.SetInt("money", currenmoney);
                AText.text = currentAttck + "";
                Skilltext.text = currentAttck + "\n공격력을 업그레이드 합니다";
            }

        }
        else
        {
            Debug.Log("공격력 업글 끝");
        }
    }

}