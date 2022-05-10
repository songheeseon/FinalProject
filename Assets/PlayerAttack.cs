using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float range;
    public GameObject Target;

    public GameObject NormalAttack;
    public Transform NormalAttackPos;

    public float NormalAttackTime;
    public float NormalAttackCoolTime;
    public int NormalCnt;

    bool AttackBool;

    public bool SkillBool;
    public GameObject SkillBullet;
    public float SkillTime;
    public float SkillCoolTime;
    public int SkillCnt;

    public bool SkillBool2;
    public GameObject Fireball;
    public float FireballTime;
    public float FireballCoolTime;
    public int FireballCnt;

    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    public bool SkillBool3;
    public GameObject Arcball;
    public float ArcBallTime;
    public float ArcballCoolTime;
    public int ArcballCnt;

    public bool isUpgrade;


    // Start is called before the first frame update
    void Start()
    {
        isUpgrade = true;
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        NormalSkillCool();
        SkillCool();
        FireBallCool();
        ArcBallCool();

        if (NormalCnt > 0)
        {
            NormalAttackTime = 0;
        }

        if (AttackBool && NormalCnt > 0)
        {
            if(Target != null)
            Attack();
        }

        if (SkillBool && SkillCnt > 0)
        {
            EnegyBall();
        }

        if (/*SkillBool2 && */FireballCnt > 0)
        {
            FireBall();
           
        }

        if (/*SkillBool3 && */ArcballCnt > 0)
        {
            ArcBall();
        }

        if (isUpgrade)
        {
            switch (Ability.instance.AttackDelayCnt)
            {
                case 1:
                    NormalAttackCoolTime -= 0.2f;
                    isUpgrade = false;
                    break;

                case 2:
                    NormalAttackCoolTime -= 0.4f;
                    isUpgrade = false;
                    break;

                case 3:
                    NormalAttackCoolTime -= 0.6f;                 
                    isUpgrade = false;
                    break;

                case 4:
                    NormalAttackCoolTime -= 0.8f;             
                    isUpgrade = false;
                    break;

                case 5:
                    NormalAttackCoolTime -= 1.0f;                 
                    isUpgrade = false;
                    break;
            }
        }
    }


    void NormalSkillCool()
    {
        NormalAttackTime += Time.deltaTime;

        if (NormalAttackTime > NormalAttackCoolTime)
        {
            NormalCnt++;
            NormalAttackTime = 0;
        }

        if (NormalCnt > 0)
        {
            NormalAttackTime = 0;
        }
    }

    void SkillCool()
    {
        SkillTime += Time.deltaTime;

        if (SkillTime > SkillCoolTime)
        {
            SkillCnt++;
            SkillTime = 0;
        }

        if (SkillCnt > 0)
        {
            SkillTime = 0;
        }
    }

    void FireBallCool()
    {
        FireballTime += Time.deltaTime;

        if (FireballTime > FireballCoolTime)
        {
            FireballCnt++;
            FireballTime = 0;
        }

        if (FireballCnt > 0)
        {
            FireballTime = 0;
        }
    }

    void ArcBallCool()
    {
        ArcBallTime += Time.deltaTime;

        if (ArcBallTime > ArcballCoolTime)
        {
            ArcballCnt++;
            ArcBallTime = 0;
        }

        if (ArcballCnt > 0)
        {
            ArcBallTime = 0;
        }
    }


    public void Attack()
    {
        Debug.Log("?");
        GameObject NB = Instantiate(NormalAttack, NormalAttackPos.transform.position, Quaternion.identity);

        Vector3 rotVec = Vector3.forward * 360 + Vector3.forward * 90;
        NB.transform.Rotate(rotVec);
        NormalCnt--;
 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {  
        if(Target == null || Target.activeSelf == false)
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
            float shortestDistance = Mathf.Infinity;
            GameObject nearestMonster = null;
            foreach(GameObject Monster in Monsters)
            {
                float DistanceToMonsters = Vector3.Distance(transform.position, Monster.transform.position);

                if(DistanceToMonsters < shortestDistance)
                {
                    shortestDistance = DistanceToMonsters;
                    nearestMonster = Monster;
                }
            }

            if(nearestMonster != null && shortestDistance <= range)
            {
                Target = nearestMonster;
                AttackBool = true;
            }

            else
            {
                Target = null;
            }
        }

    }

    void EnegyBall()
    {
        Instantiate(SkillBullet, NormalAttackPos.transform.position, NormalAttackPos.transform.rotation);
        SkillCnt--;
    }

    void FireBall()
    {
        FireballCnt--;

        GameObject FireBall = Instantiate(Fireball);
        FireBall.transform.position = NormalAttackPos.transform.position;
        FireBall.transform.rotation = Quaternion.identity;
    }

    void ArcBall()
    {
        //GameObject FireBall = Instantiate(Fireball, NormalAttackPos.transform.position, NormalAttackPos.transform.rotation);
        ArcballCnt--;

        //// # Fire Around 부채꼴모양 
        int roundNumA = 50;
        int roundNumB = 40;
        int roundNum = curPatternCount % 2 == 0 ? roundNumA : roundNumB;

        for (int index = 0; index < roundNumA; index++)
        {
            GameObject FireBall = Instantiate(Arcball);
            FireBall.transform.position = NormalAttackPos.transform.position;
            FireBall.transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = FireBall.GetComponent<Rigidbody2D>();

            Vector2 dirvec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundNum),
                                     Mathf.Sin(Mathf.PI * 2 * index / roundNum));

            rigid.AddForce(dirvec.normalized * 3f, ForceMode2D.Impulse);

            Vector3 rotvec = Vector3.forward * 360 * index / roundNum + Vector3.forward * 90;
            FireBall.transform.Rotate(rotvec);
        }
    }
}
