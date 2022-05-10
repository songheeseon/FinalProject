using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    int ShellCursor;
    // ½Ì±ÛÅæ 
    public static ObjectManager instance = null;

    public GameObject PigPrefab; //µÅÁö
    public GameObject BatPrefab; //ÇÃ·¹¾î ºÒ²É»ý¼º ÁÂÇ¥
    public GameObject RatPrefab; //·£´ý ÁÂÇ¥ ÇÁ¸®ÆÕ
    public GameObject DuckPrefab;
    public GameObject InsectPrefab;
    public GameObject PigKingPrefab;

    GameObject[] Pig;
    GameObject[] Bat;
    GameObject[] Rat;
    GameObject[] Duck;
    GameObject[] Insect;
    GameObject[] PigKing;


    GameObject[] PoolMaker;


    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


        Pig = new GameObject[5];
        Bat = new GameObject[5];
        Rat = new GameObject[5];
        Duck = new GameObject[5];
        Insect = new GameObject[5];
        PigKing = new GameObject[1];

        Generate();
    }

    void Generate()
    {
        for (int index = 0; index < Pig.Length; index++)
        {
            Pig[index] = Instantiate(PigPrefab);
            Pig[index].SetActive(false);
        }

        for (int index = 0; index < Bat.Length; index++)
        {
            Bat[index] = Instantiate(BatPrefab);
            Bat[index].SetActive(false);
        }

        for (int index = 0; index < Rat.Length; index++)
        {
            Rat[index] = Instantiate(RatPrefab);
            Rat[index].SetActive(false);
        }

        for (int index = 0; index < Duck.Length; index++)
        {
            Duck[index] = Instantiate(DuckPrefab);
            Duck[index].SetActive(false);
        }

        for (int index = 0; index < Insect.Length; index++)
        {
            Insect[index] = Instantiate(InsectPrefab);
            Insect[index].SetActive(false);
        }

        for (int index = 0; index < PigKing.Length; index++)
        {
            PigKing[index] = Instantiate(PigKingPrefab);
            PigKing[index].SetActive(false);
        }

    }

    public GameObject Loader(string type)
    {
        switch (type)
        {
            case "Pig":
                PoolMaker = Pig;
                break;

            case "Bat":
                PoolMaker = Bat;
                break;

            case "Rat":
                PoolMaker = Rat;
                break;

            case "Duck":
                PoolMaker = Duck;
                break;

            case "Insect":
                PoolMaker = Insect;
                break;

            case "PigKing":
                PoolMaker = PigKing;
                break;
        }

        for (int index = 0; index < PoolMaker.Length; index++)
        {
            if (!PoolMaker[index].activeSelf)
            {
                PoolMaker[index].SetActive(true);
                return PoolMaker[index];
            }
        }

        return null;
    }

    //public GameObject Loader_ammo() // ** ÅºÇÇ¸¦ È°¼ºÈ­ ½ÃÄ×´ø ÇÁ¸®ÆÕÀ» Áßº¹ »ç¿ëÇÏÁö ¾Ê°Ô ÇÏ´Â ÄÚµå 
    //{
    //    for (int index = 0; index < KaotiJaios4Ammo.Length; index++)
    //    {
    //        ShellCursor = (ShellCursor + 1) % KaotiJaios4Ammo.Length;

    //        if (!KaotiJaios4Ammo[index + ShellCursor].activeSelf)
    //        {
    //            KaotiJaios4Ammo[index + ShellCursor].SetActive(true);
    //            //ShellDropAni.Acceleration();
    //            return KaotiJaios4Ammo[index + ShellCursor];
    //        }
    //    }

    //    return null;
    //}
}

