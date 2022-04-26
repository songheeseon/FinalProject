using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    public float AmmoVelocity;
    public bool isHit;
    public int damage;
    public int range;
    void Start()
    {
        range = Random.Range(0, 4);
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if(range == 0)
        transform.Translate(transform.up * 1 * AmmoVelocity * Time.deltaTime);

        if (range == 1)
            transform.Translate(transform.right * 1 * AmmoVelocity * Time.deltaTime);

        if (range == 2)
            transform.Translate(transform.right * -1 * AmmoVelocity * Time.deltaTime);

        if (range == 3)
            transform.Translate(transform.up * -1 * AmmoVelocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ĭŸũ��
        if (collision is CircleCollider2D)
        {
            if (collision.CompareTag("Monster"))
            {
                if (isHit)
                    return;

                Pig pig = collision.gameObject.GetComponent<Pig>();
                StartCoroutine(pig.DamageCharacter(damage, 0.0f)); //������ ���� ����
              

                isHit = true;

                Destroy(gameObject);
            }


        }
    }
}
