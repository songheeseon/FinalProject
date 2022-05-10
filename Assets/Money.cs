using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text MoneyCnt;

    void Update()
    {
        UpdateMoney();
    }

    public void aaaaaaa()
    {
        PlayerPrefs.DeleteKey("Money");
        //MoneyCnt.text = "" + 0;
    }

    private void UpdateMoney()
    {
        if (PlayerPrefs.HasKey("Money"))
            MoneyCnt.text = PlayerPrefs.GetInt("Money").ToString();

        else
            Debug.Log("값이 없다");
    }


}
