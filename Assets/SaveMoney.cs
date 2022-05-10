using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveMoney : MonoBehaviour
{
    // ΩÃ±€≈Ê 
    public static SaveMoney instance = null;
    Player player;
    Movement movement;
    PlayerAttack playerAttack;
    bool IsClear = true;

    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        player = FindObjectOfType<Player>();
        movement = FindObjectOfType<Movement>();
        playerAttack = FindObjectOfType<PlayerAttack>();

        //Money = PlayerPrefs.GetInt("Money");
    }

    public void youWin()
    {
        if (IsClear)
        {
            int PlayerCoin = player.Money;
            int SaveCoin = PlayerPrefs.GetInt("Money");
            int TotalCoin = PlayerCoin + SaveCoin;
            PlayerPrefs.SetInt("Money", TotalCoin);

            Invoke("loadMainMenu", 3f);
            IsClear = false;
        }        
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}