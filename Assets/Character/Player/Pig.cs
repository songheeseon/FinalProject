using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pig : Character
{
    public float hitPoints;
    float armor;
    float Ricochet;

    public GameObject exp;
    public GameObject money;
    public Transform itemPos;


    public void OnEnable()
    {
        hitPoints = startingHitPoints;
        armor = startingArmor;
        hitPoints += 30;
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
                      
                if (hitPoints <= float.Epsilon)
                {
                    KillCharacter();

                    int ran = Random.Range(0, 10);
                    if (ran < 4)
                    {
                        Instantiate(money, itemPos.transform.position, Quaternion.identity);
                    }

                    if (ran >= 4 && ran < 10)
                    {
                        Instantiate(exp, itemPos.transform.position, Quaternion.identity);
                    }

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

}