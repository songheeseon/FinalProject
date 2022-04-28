using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float range;
    public GameObject Target;

    public GameObject NormalAttack;
    public Transform NormalAttackPos;

    public float AttackSpeed;

    public float NormalAttackTime;
    public float NormalAttackCoolTime;
    public int NormalCnt;

    bool AttackBool;

    public bool SkillBool;

    public GameObject SkillBullet;
    public float SkillTime;
    public float SkillCoolTime;
    public int SkillCnt;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        NormalSkillCool();
        SkillCool();

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
}
