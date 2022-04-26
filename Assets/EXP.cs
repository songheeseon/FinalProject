using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour
{
    public Slider EXP_Bar;

    [SerializeField]
    private int Level;

    GameManager gameManager;
    // Update is called once per frame

    void Update()
    {
        if (EXP_Bar.value >= EXP_Bar.maxValue)
        {
            Debug.Log("¾¾¹ß");
            Level++;
            EXP_Bar.value = 0;
        }

        switch (Level)
        {
            case 1:
                EXP_Bar.maxValue = 150;
                gameManager.LevelUpUI1();
                break;
        }
    }




}
