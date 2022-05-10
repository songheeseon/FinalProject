using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopupgrade : MonoBehaviour
{

    public int maxHealth, maxAttck, maxArwour;

    int currentHealth, currentAttck, currentArwour;


    int money, currenmoney;

    public Text Skilltext; // ��ų �ؽ�Ʈ
    public Text cashText; //���� ��
    public Text HText; // ü�� ����
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
        Skilltext.text = "��ų ���׷��̵�";

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
                Skilltext.text = currentHealth + "\nü���� ���׷��̵� �մϴ�";
                currentHealth += 3;
                PlayerPrefs.SetInt("health", currentHealth);
                PlayerPrefs.SetInt("money", currenmoney);
                HText.text = currentHealth + "";
            }
           
        }
        else
        {
            Debug.Log("ü�� ���� ��");
            Skilltext.text = currentHealth + "���� ���׷��̵� �߽��ϴ�.";
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
                Skilltext.text = currentArwour + "\n������ ���׷��̵� �մϴ�";
            }
            

        }
        else
        {
            Debug.Log("���� ���� ��");
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
                Skilltext.text = currentAttck + "\n���ݷ��� ���׷��̵� �մϴ�";
            }

        }
        else
        {
            Debug.Log("���ݷ� ���� ��");
        }
    }

}