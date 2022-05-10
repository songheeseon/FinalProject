using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float AmmoVelocity;
    public bool isHit;
    public int damage;
    int range;
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
        //칸타크리
        if (collision is CircleCollider2D)
        {
            if (collision.CompareTag("Monster") && collision.gameObject.layer == 7)
            {
                if (isHit)
                    return;

                Pig pig = collision.gameObject.GetComponent<Pig>();
                StartCoroutine(pig.DamageCharacter(damage, 0.0f)); //데미지 정보 전달             
                isHit = true;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 8)
            {
                if (isHit)
                    return;

                Rat rat = collision.gameObject.GetComponent<Rat>();
                StartCoroutine(rat.DamageCharacter(damage, 0.0f)); //데미지 정보 전달             
                isHit = true;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 10)
            {
                if (isHit)
                    return;

                Bat bat = collision.gameObject.GetComponent<Bat>();
                StartCoroutine(bat.DamageCharacter(damage, 0.0f)); //데미지 정보 전달             
                isHit = true;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 11)
            {
                if (isHit)
                    return;

                Insect insect = collision.gameObject.GetComponent<Insect>();
                StartCoroutine(insect.DamageCharacter(damage, 0.0f)); //데미지 정보 전달             
                isHit = true;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 9)
            {
                if (isHit)
                    return;

                Duck duck = collision.gameObject.GetComponent<Duck>();
                StartCoroutine(duck.DamageCharacter(damage, 0.0f)); //데미지 정보 전달             
                isHit = true;
                Destroy(gameObject);
            }
        }

        if (collision is BoxCollider2D)
        {
            if (collision.CompareTag("Monster") && collision.gameObject.layer == 7)
            {
                PigKing pigking = collision.gameObject.GetComponent<PigKing>();
                StartCoroutine(pigking.DamageCharacter(damage, 0.0f)); //데미지 정보 전달             
                isHit = true;
                Destroy(gameObject);
            }
        }
    }
}
