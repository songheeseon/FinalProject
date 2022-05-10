using System.Collections;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float maxHitPoints;
    public float startingHitPoints;

    public float maxArmor;
    public float startingArmor;

    //캐릭터 삭제
    public virtual void KillCharacter()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public abstract IEnumerator DamageCharacter(int damage, float interval);
}