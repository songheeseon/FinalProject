using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MonoBehaviour
{
    public float AmmoVelocity;

    public bool isHit;

    public float range;
    public GameObject Target;
    public int damage;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();

        if (Target != null )
        {
            transform.position += transform.up * AmmoVelocity * Time.deltaTime;

            Vector3 dir = (Target.transform.position - transform.position).normalized;
            transform.up = Vector3.Lerp(transform.up, dir, 0.25f);

        }
    }

    void UpdateTarget()
    {
        if (Target == null || Target.activeSelf == false)
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
            float shortestDistance = Mathf.Infinity;
            GameObject nearestMonster = null;
            foreach (GameObject Monster in Monsters)
            {
                float DistanceToMonsters = Vector3.Distance(transform.position, Monster.transform.position);

                if (DistanceToMonsters < shortestDistance)
                {
                    shortestDistance = DistanceToMonsters;
                    nearestMonster = Monster;
                }
            }

            if (nearestMonster != null && shortestDistance <= range)
            {
                Target = nearestMonster;

            }

            else
            {
                Target = null;
            }
        }
    }

    //적과 충돌할 때 데미지 전달
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

            if (collision.CompareTag("Monster") && collision.gameObject.layer == 8 )
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

        if(collision is BoxCollider2D)
        {
            if(collision.CompareTag("Monster") && collision.gameObject.layer == 7)
            {
                PigKing pigking = collision.gameObject.GetComponent<PigKing>();
                StartCoroutine(pigking.DamageCharacter(damage, 0.0f)); //데미지 정보 전달             
                isHit = true;
                Destroy(gameObject);
            }
        }
    }
}
