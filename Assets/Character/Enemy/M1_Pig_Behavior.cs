using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1_Pig_Behavior : MonoBehaviour
{
    public float speed; //�⺻ �ӵ�, ���� �ӵ�

    private Transform player;
    private Vector2 target;
    Coroutine damageCoroutine;

    public int damage;

    bool IsDamage;


    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Movement();
        LookAtPlayer();

    }


    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), speed * Time.deltaTime); //Ư�� ������ �̵�, 2022.01.12
    }

    void LookAtPlayer()
    {
        if (player.gameObject.activeSelf == true)
        {
            if (player.position.x < transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D && collision.CompareTag("Player"))
        { 
            Player player = collision.gameObject.GetComponent<Player>();

            if(damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damage, 1.0f)); //������ ���� ����
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision is BoxCollider2D && collision.CompareTag("Player"))
        {
            if(damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
}
