using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public float hitPoints;
    float armor;
    float Ricochet;

    public Slider HealthBar; //체력 게이지바
    public HealthBarBehaviour healthBarBehaviour;
    public bool isHp; // 버튼 입력용 bool값
    public int damage;
    public Slider EXPSlider;
    [SerializeField] public int Money = 0;
    [SerializeField] private Text MoneyText;


    public float animTime = 2f;         // Fade 애니메이션 재생 시간 (단위:초).  
    private SpriteRenderer fadeImage;            // UGUI의 Image컴포넌트 참조 변수.  

    private float start = 1f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    public bool isDead; // 버튼 입력용 bool값

    public Text Hp;
    public int Medicine; //물약 개수
    public float MedicineCool;
    public int MedicineTimeAmount; //물약 쿨타임 (1번먹고 난 뒤 그 다음 물약 먹는 텀)

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

    //Hp 회복 함수
    void HP_Full()
    {
        if (isHp && MedicineCool >= MedicineTimeAmount && Medicine > 0)
        {
            if (Medicine <= 0)
            {
                //Debug.Log("물약이 다 떨어졌습니다");
            }
            else
            {
                if (hitPoints == maxHitPoints)
                {
                    //Debug.Log("체력이 가득차 사용 불가합니다.");
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
                    //Debug.Log("물약 쿨이 차지 않았습니다.");
                }
            }
        }
    }

    //Hp회복 쿨타임 함수
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
        // 경과 시간 계산.  
        // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
        time += Time.deltaTime / animTime;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        // 알파 값 계산.  
        color.a = Mathf.Lerp(start, end, time);  //FadeIn과는 달리 start, end가 반대다.
                                                    // 계산한 알파 값 다시 설정.  
        fadeImage.color = color;

        Invoke("KillCharacter", 2f);

        GameOver.gameObject.SetActive(true);
        FadeOut.gameObject.SetActive(true);
    }


    //플레이어가 타격을 받았을 때의 데미지 적용
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
                //Debug.Log("팅!");
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