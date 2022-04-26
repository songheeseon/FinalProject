using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public float hitPoints;
    float armor;
    float Ricochet;

    public HealthBarBehaviour healthBarBehaviour;

    public bool isHp; // ��ư �Է¿� bool��

    public int damage;

    public Slider EXPSlider;
    [SerializeField] private int Money;
    public void HPUp()
    {
        isHp = false;
    }

    public void HPDown()
    {
        isHp = true;
    }

    public void Start()
    {
        hitPoints = startingHitPoints;
        armor = startingArmor;
        
        healthBarBehaviour.SetHealth(hitPoints, maxHitPoints);

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
                    KillCharacter();
                    gameObject.GetComponent<Movement>().enabled = false;

                    this.GetComponent<Player>().enabled = false;
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

    }
}