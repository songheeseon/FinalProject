using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public bool isHit;
    public int damage;

    private float size = 20f; //원하는 사이즈
    public float speed; //커질 때의 속도

    private float time;
    private Vector2 originScale; //원래 크기

    private CircleCollider2D circle; //원래 크기

    void Start()
    {
        Destroy(gameObject, 5f);
        originScale = transform.localScale;

        StartCoroutine(Up());

        circle = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        
    }

    IEnumerator Up()
    {
        while (transform.localScale.x < size)
        {
            transform.localScale = originScale * (1f + time * speed);
            time += Time.deltaTime;

            //if(circle.radius <= 0.5f)
            //circle.radius += 0.1f;

            if (transform.localScale.x >= size)
            {
                time = 0;
                break;
            }
            yield return null;
        }
    }
    private void OnDisable()
    {
        gameObject.transform.localScale = originScale;
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
