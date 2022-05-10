using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    int Pick;
    int Spot;

    public Transform T1;
    public Transform T2;
    public Transform T3;
    public Transform T4;
    public Transform T5;
    public Transform T6;
    public Transform T7;
    public Transform T8;
    public Transform T9;
    public Transform T10;
    public Transform T11;
    public Transform T12;

    bool isSpawn;
    public bool isBossSpawn;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        InvokeRepeating("SpawnSystem", 3f, 3f);
        InvokeRepeating("Spawn", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Pick = Random.Range(0, 6);
        Spot = Random.Range(0, 13);

        if(gameManager.setTime >= 60 && gameManager.setTime <= 60.01f)
        {
            isBossSpawn = true;
        }

        BossSpawn();
    }

    void BossSpawn()
    {
        if (isBossSpawn)
        {
            GameObject PigKing = ObjectManager.instance.Loader("PigKing");
            PigKing.transform.position = T2.transform.position;
            PigKing.transform.rotation = Quaternion.identity;

            Invoke("BossSpawnFalse", 0.5f);
        }
    }

    void BossSpawnFalse()
    {
        isBossSpawn = false;
    }

    void Spawn()
    {
        isSpawn = true;
    }

    void SpawnSystem()
    {
        if (isSpawn)
        {
            if (Pick == 1)
            {
                if (Spot == 1)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T1.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 2)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T2.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 3)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T3.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 4)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T4.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 5)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T5.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 6)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T6.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 7)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T7.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 8)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T8.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 9)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T9.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 10)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T10.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 11)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T11.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 12)
                {
                    GameObject Pig = ObjectManager.instance.Loader("Pig");
                    Pig.transform.position = T12.transform.position;
                    Pig.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }
            }

            if (Pick == 2)
            {
                if (Spot == 1)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T1.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 2)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T2.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 3)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T3.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 4)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T4.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 5)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T5.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 6)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T6.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 7)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T7.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 8)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T8.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 9)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T9.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 10)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T10.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 11)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T11.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }

                if (Spot == 12)
                {
                    GameObject Bat = ObjectManager.instance.Loader("Bat");
                    Bat.transform.position = T12.transform.position;
                    Bat.transform.rotation = Quaternion.identity;

                    isSpawn = false;
                }
            }

            if (Pick == 3)
            {
                if (Spot == 1)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T1.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 2)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T2.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 3)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T3.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 4)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T4.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 5)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T5.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 6)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T6.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 7)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T7.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 8)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T8.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 9)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T9.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 10)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T10.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 11)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T11.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 12)
                {
                    GameObject Rat = ObjectManager.instance.Loader("Rat");
                    Rat.transform.position = T12.transform.position;
                    Rat.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }
            }

            if (Pick == 4)
            {
                if (Spot == 1)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T1.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 2)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T2.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 3)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Bat");
                    Duck.transform.position = T3.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 4)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T4.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 5)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T5.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 6)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T6.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 7)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T7.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 8)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T8.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 9)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T9.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 10)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T10.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 11)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T11.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 12)
                {
                    GameObject Duck = ObjectManager.instance.Loader("Duck");
                    Duck.transform.position = T12.transform.position;
                    Duck.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }
            }

            if (Pick == 5)
            {
                if (Spot == 1)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T1.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 2)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T2.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 3)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T3.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 4)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T4.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 5)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T5.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 6)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T6.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 7)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T7.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 8)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T8.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 9)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T9.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 10)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T10.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 11)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T11.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }

                if (Spot == 12)
                {
                    GameObject Insect = ObjectManager.instance.Loader("Insect");
                    Insect.transform.position = T12.transform.position;
                    Insect.transform.rotation = Quaternion.identity;
                    isSpawn = false;
                }
            }
        }
     

    }
}
