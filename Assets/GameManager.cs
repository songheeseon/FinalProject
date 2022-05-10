using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject SetupMenu;

    // 카운트다운 변수 선언 
    bool CountDownControl = true;
    public float setTime = 300.0f;
    [SerializeField] Text countdownText;
    int min;
    float sec;

    PlayerAttack PA;
    SkillAttack SA;

    public GameObject LevelUp;

    public Slider EXP_Bar;
    [SerializeField]
    private int Level;

    public bool IsUI;
    public bool IsClear;

    public Image MissionClear;
    public Image FadeIn;
    public Image FadeOut;
    void Start()
    {
        Time.timeScale = 1.0f;

        IsUI = true;

        PA = FindObjectOfType<PlayerAttack>();
        SA = FindObjectOfType<SkillAttack>();
        SetupMenu.SetActive(false);
        FadeIn.gameObject.SetActive(true);
        FadeOut.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(setTime <= 0)
        {
            MissionClear.gameObject.SetActive(true); 
            SaveMoney.instance.youWin();
            IsClear = true;
        }

        Clear();

        UI_Active();
        CountDown();

        if (EXP_Bar.value >= EXP_Bar.maxValue)
        {
            Level++;
            EXP_Bar.value = 0;
        }

        switch (Level)
        {
            case 1:
                EXP_Bar.maxValue = 150;
                LevelUpUI1();
                break;

            case 2:
                EXP_Bar.maxValue = 200;
                LevelUpUI1();
                break;
        }


    }

    public void Clear()
    {
        if (IsClear)
        {
            SaveMoney.instance.youWin();
            IsClear = false;
        }
       
    }


    public void SetupMenuOn()
    {
        SetupMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetupMenuOff()
    {
        SetupMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void AppQuit()
    {
        Application.Quit();
    }

    public void LevelUpUI1()
    {
        if(IsUI)
        LevelUp.gameObject.SetActive(true);
    }

    public void AttackDelayDown()
    {
        IsUI = false;

        PA.NormalAttackCoolTime = 2.0f;
        LevelUp.gameObject.SetActive(false);
        Time.timeScale = 1.0f;

        if (Level == 2)
        {
            PA.NormalAttackCoolTime = 1.8f;
        }
    }

    public void UIfalse()
    {
        IsUI = true;
    }

    public void EnergyBall()
    {
        IsUI = false;
        
        PA.SkillBool = true;
        LevelUp.gameObject.SetActive(false);
        Time.timeScale = 1.0f;

        if(Level == 2)
        {
            SA.damage += 20;
        }
    }

    void UI_Active()
    {
        if (LevelUp.activeSelf == true)
        {
            Time.timeScale = 0.0f;
        }
    }

    void CountDown()
    {
        //setTime -= Time.deltaTime;
        if (CountDownControl)
            setTime -= Time.deltaTime;

        // 전체 시간이 60초 보다 클 때
        if (setTime >= 60f)
        {
            // 60으로 나눠서 생기는 몫을 분단위로 변경
            min = (int)setTime / 60;
            // 60으로 나눠서 생기는 나머지를 초단위로 설정
            sec = setTime % 60;
            // UI를 표현해준다
            countdownText.text = "Mission Time " + min + ":" + (int)sec;
        }

        // 전체시간이 60초 미만일 때
        if (setTime < 60f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + "0:" + (int)setTime + "";
        }

        // 전체시간이 60초 미만일 때
        if (setTime >= 0f && setTime < 10f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + "0:0" + (int)setTime;
        }

        // 전체시간이 60초 미만일 때
        if (setTime >= 60f && setTime < 70f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 전체시간이 120초 미만일 때
        if (setTime >= 120f && setTime < 130f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 전체시간이 180초 미만일 때
        if (setTime >= 180f && setTime < 190f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 전체시간이 240초 미만일 때
        if (setTime >= 240f && setTime < 250f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 전체시간이 300초 미만일 때
        if (setTime >= 300f && setTime < 310f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 전체시간이 360초 미만일 때
        if (setTime >= 360f && setTime < 370f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 전체시간이 420초 미만일 때
        if (setTime >= 420f && setTime < 430f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 전체시간이 480초 미만일 때
        if (setTime >= 480f && setTime < 490f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 전체시간이 540초 미만일 때
        if (setTime >= 540f && setTime < 550f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // 남은 시간이 0보다 작아질 때
        if (setTime <= 0)
        {
            // UI 텍스트를 0초로 고정시킴.
            countdownText.text = "MISSION CLEAR";
        }

    }
}
