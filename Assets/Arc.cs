using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : MonoBehaviour
{
    public bool isHit;
    public int damage;

  

    void Start()
    {
        Destroy(gameObject, 5f);
         

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ĭŸũ��
        if (collision is CircleCollider2D)
        {
            if (collision.CompareTag("Monster") && collision.gameObject.layer == 7)
            {
                if (isHit)
                    return;

                Pig pig = collision.gameObject.GetComponent<Pig>();
                StartCoroutine(pig.DamageCharacter(damage, 0.0f)); //������ ���� ����             
                isHit = true;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 8)
            {
                if (isHit)
                    return;

                Rat rat = collision.gameObject.GetComponent<Rat>();
                StartCoroutine(rat.DamageCharacter(damage, 0.0f)); //������ ���� ����             
                isHit = true;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 10)
            {
                if (isHit)
                    return;

                Bat bat = collision.gameObject.GetComponent<Bat>();
                StartCoroutine(bat.DamageCharacter(damage, 0.0f)); //������ ���� ����             
                isHit = true;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 11)
            {
                if (isHit)
                    return;

                Insect insect = collision.gameObject.GetComponent<Insect>();
                StartCoroutine(insect.DamageCharacter(damage, 0.0f)); //������ ���� ����             
                isHit = true;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 9)
            {
                if (isHit)
                    return;

                Duck duck = collision.gameObject.GetComponent<Duck>();
                StartCoroutine(duck.DamageCharacter(damage, 0.0f)); //������ ���� ����             
                isHit = true;
                Destroy(gameObject);
            }
        }

        if (collision is BoxCollider2D)
        {
            if (collision.CompareTag("Monster") && collision.gameObject.layer == 7)
            {
                PigKing pigking = collision.gameObject.GetComponent<PigKing>();
                StartCoroutine(pigking.DamageCharacter(damage, 0.0f)); //������ ���� ����             
                isHit = true;
                Destroy(gameObject);
            }
        }
    }
}
