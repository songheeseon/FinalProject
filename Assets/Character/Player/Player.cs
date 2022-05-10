using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public float hitPoints;
    float armor;
    float Ricochet;

    public Slider HealthBar; //ü�� ��������
    public HealthBarBehaviour healthBarBehaviour;
    public bool isHp; // ��ư �Է¿� bool��
    public int damage;
    public Slider EXPSlider;
    [SerializeField] public int Money = 0;
    [SerializeField] private Text MoneyText;


    public float animTime = 2f;         // Fade �ִϸ��̼� ��� �ð� (����:��).  
    private SpriteRenderer fadeImage;            // UGUI�� Image������Ʈ ���� ����.  

    private float start = 1f;           // Mathf.Lerp �޼ҵ��� ù��° ��.  
    private float end = 0f;             // Mathf.Lerp �޼ҵ��� �ι�° ��.  
    private float time = 0f;            // Mathf.Lerp �޼ҵ��� �ð� ��.  

    public bool isDead; // ��ư �Է¿� bool��

    public Text Hp;
    public int Medicine; //���� ����
    public float MedicineCool;
    public int MedicineTimeAmount; //���� ��Ÿ�� (1���԰� �� �� �� ���� ���� �Դ� ��)

    public Image GameOver;
    public Image FadeOut;

    public GameObject bone1;
    public GameObject bone2;
    public GameObject bone3;

    public bool isUpgrade;
    public void HPUp()
    {
        isHp = false;
    }

    public void HPDown()
    {
        isHp = true;
    }

    private void UpdateBulletText()
    {
        Hp.text = string.Format("{0}", Medicine);
    }

    //Hp ȸ�� �Լ�
    void HP_Full()
    {
        if (isHp && MedicineCool >= MedicineTimeAmount && Medicine > 0)
        {
            if (Medicine <= 0)
            {
                //Debug.Log("������ �� ���������ϴ�");
            }
            else
            {
                if (hitPoints == maxHitPoints)
                {
                    //Debug.Log("ü���� ������ ��� �Ұ��մϴ�.");
                }

                else if (MedicineCool >= MedicineTimeAmount)
                {
                    Medicine--;
                    hitPoints += 300;

                    if (hitPoints >= maxHitPoints)
                    {
                        hitPoints = maxHitPoints;
                    }

                    HealthBar.value = hitPoints;
                    MedicineCool = 0;
                }
                else if (MedicineCool < MedicineTimeAmount)
                {
                    //Debug.Log("���� ���� ���� �ʾҽ��ϴ�.");
                }
            }
        }
    }

    //Hpȸ�� ��Ÿ�� �Լ�
    void HP_Cool()
    {
        if (Medicine > 0)
            MedicineCool += Time.deltaTime;

        if (MedicineCool > MedicineTimeAmount)
            MedicineCool = MedicineTimeAmount;
    }

    public void Start()
    {
        isUpgrade = true;
        //fadeImage = bone1.GetComponent<SpriteRenderer>();
        //fadeImage = bone2.GetComponent<SpriteRenderer>();
        fadeImage = bone3.GetComponent<SpriteRenderer>();

        hitPoints = startingHitPoints;
        armor = startingArmor;
        
        healthBarBehaviour.SetHealth(hitPoints, maxHitPoints);
    }

    private void Update()
    {
        if (isUpgrade)
        {
            switch (Ability.instance.HpCnt)
            {
                case 1:
                    maxHitPoints += 100;
                    hitPoints += 100;
                    isUpgrade = false;
                    break;

                case 2:
                    maxHitPoints += 200;
                    hitPoints += 200;
                    isUpgrade = false;
                    break;

                case 3:
                    maxHitPoints += 300;
                    hitPoints += 300;
                    isUpgrade = false;
                    break;

                case 4:
                    maxHitPoints += 400;
                    hitPoints += 400;
                    isUpgrade = false;
                    break;

                case 5:
                    maxHitPoints += 500;
                    hitPoints += 500;
                    isUpgrade = false;
                    break;
            }
        }


        if(isDead)
        PlayFadeOut();

        MoneyText.text = "x " + Money;

        HP_Cool();
        HP_Full();
        UpdateBulletText();
    }
    void PlayFadeOut()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(start, end, time);  //FadeIn���� �޸� start, end�� �ݴ��.
                                                    // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;

        Invoke("KillCharacter", 2f);

        GameOver.gameObject.SetActive(true);
        FadeOut.gameObject.SetActive(true);
    }


    //�÷��̾ Ÿ���� �޾��� ���� ������ ����
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            Ricochet = Random.Range(0, 5);

            if (Ricochet != 0)
            {
                hitPoints = hitPoints - (damage / armor);
                healthBarBehaviour.SetHealth(hitPoints, maxHitPoints);
            

                if (hitPoints <= float.Epsilon)
                {
                    isDead = true;
                    gameObject.GetComponent<Movement>().enabled = false;

                    this.GetComponent<PlayerAttack>().enabled = false;
                    break;
                }

                if (interval > float.Epsilon)
                {
                    yield return new WaitForSeconds(interval);
                }

                else
                {
                    break;
                }
            }
            else if (Ricochet == 0)
            {
                //Debug.Log("��!");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision is CircleCollider2D)
        {
            if (collision.CompareTag("MONEY"))
            {
                collision.gameObject.SetActive(false);
                Money++;
            }

            if (collision.CompareTag("EXP"))
            {
                collision.gameObject.SetActive(false);
                EXPSlider.value += 90;
            }
        }

        if(collision is BoxCollider2D)
        {
            if (collision.CompareTag("MONEY"))
            {
                collision.gameObject.SetActive(false);
                Money += 10;
            }
        }

    }
}