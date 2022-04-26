using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject SetupMenu;

    // ī��Ʈ�ٿ� ���� ���� 
    bool CountDownControl = true;
    public float setTime = 300.0f;
    [SerializeField] Text countdownText;
    int min;
    float sec;

    PlayerAttack PA;

    public GameObject LevelUp;

    public Slider EXP_Bar;
    [SerializeField]
    private int Level;

    bool IsUI;
    void Start()
    {
        IsUI = true;

        PA = FindObjectOfType<PlayerAttack>();
        SetupMenu.SetActive(false);
    }

    private void Update()
    {
        UI_Active();
        CountDown();

        if (EXP_Bar.value >= EXP_Bar.maxValue)
        {
            Debug.Log("����");
            Level++;
            EXP_Bar.value = 0;
        }

        switch (Level)
        {
            case 1:
                EXP_Bar.maxValue = 150;
                LevelUpUI1();
                break;
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
    }

    public void EnergyBall()
    {
        IsUI = false;
        
        PA.SkillBool = true;
        LevelUp.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
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

        // ��ü �ð��� 60�� ���� Ŭ ��
        if (setTime >= 60f)
        {
            // 60���� ������ ����� ���� �д����� ����
            min = (int)setTime / 60;
            // 60���� ������ ����� �������� �ʴ����� ����
            sec = setTime % 60;
            // UI�� ǥ�����ش�
            countdownText.text = "Mission Time " + min + ":" + (int)sec;
        }

        // ��ü�ð��� 60�� �̸��� ��
        if (setTime < 60f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + "0:" + (int)setTime + "";
        }

        // ��ü�ð��� 60�� �̸��� ��
        if (setTime >= 0f && setTime < 10f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + "0:0" + (int)setTime;
        }

        // ��ü�ð��� 60�� �̸��� ��
        if (setTime >= 60f && setTime < 70f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ��ü�ð��� 120�� �̸��� ��
        if (setTime >= 120f && setTime < 130f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ��ü�ð��� 180�� �̸��� ��
        if (setTime >= 180f && setTime < 190f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ��ü�ð��� 240�� �̸��� ��
        if (setTime >= 240f && setTime < 250f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ��ü�ð��� 300�� �̸��� ��
        if (setTime >= 300f && setTime < 310f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ��ü�ð��� 360�� �̸��� ��
        if (setTime >= 360f && setTime < 370f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ��ü�ð��� 420�� �̸��� ��
        if (setTime >= 420f && setTime < 430f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ��ü�ð��� 480�� �̸��� ��
        if (setTime >= 480f && setTime < 490f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ��ü�ð��� 540�� �̸��� ��
        if (setTime >= 540f && setTime < 550f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            countdownText.text = "Mission Time " + min + ":0" + (int)sec;
        }

        // ���� �ð��� 0���� �۾��� ��
        if (setTime <= 0)
        {
            // UI �ؽ�Ʈ�� 0�ʷ� ������Ŵ.
            countdownText.text = "Mission Fail";
        }

    }
}
