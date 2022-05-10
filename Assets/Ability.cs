using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ability : MonoBehaviour
{
    // ΩÃ±€≈Ê 
    public static Ability instance = null;
    Player player;
    Movement movement;
    PlayerAttack playerAttack;
    bool IsClear = true;

    public int HpCnt;
    public int AttackDelayCnt;
    public int SpeedCnt;


    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);

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

    public void PlayerHpPlus()
    {
        HpCnt++;
        //player.maxHitPoints += 100;
    }

    public void PlayerSpeedPlus()
    {
        SpeedCnt++;
        //movement.Speed += 0.5f;
    }

    public void PlayerAttackDelayMlnus()
    {
        AttackDelayCnt++;
        //playerAttack.NormalAttackCoolTime -= 0.2f;
    }
}