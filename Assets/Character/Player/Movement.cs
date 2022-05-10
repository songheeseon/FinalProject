using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    public float Speed; //�÷��̾� �⺻ �̵� �ӵ�.
    private float XtargetSpeed; //�÷��̾��� �⺻ �ӵ��� ���� ��ǥ �ӵ�.
    private float YtargetSpeed;

    //�뽬 ����
    private float activeMoveSpeed;

    public Joystick joyStick;
    Vector2 movement = new Vector2(); //����2 ���� ����.
    public bool isUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        isUpgrade = true;
        activeMoveSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //�̵� ���� �ٶ󺸱� ����
        if (joyStick.Horizontal < 0 )
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (joyStick.Horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        MoveCharacter();

        if (isUpgrade)
        {
            switch (Ability.instance.SpeedCnt)
            {
                case 1:
                    activeMoveSpeed += 0.5f;
                    isUpgrade = false;
                    break;

                case 2:
                    activeMoveSpeed += 1.0f;
                    isUpgrade = false;
                    break;

                case 3:
                    activeMoveSpeed += 1.5f;

                    isUpgrade = false;
                    break;

                case 4:
                    activeMoveSpeed += 2.0f;

                    isUpgrade = false;
                    break;

                case 5:
                    activeMoveSpeed += 2.5f;
                    isUpgrade = false;
                    break;
            }
        }
    }

    //�����¿� Ű�Է�
    public void MoveCharacter()
    {
            XtargetSpeed = joyStick.Horizontal * activeMoveSpeed;
            YtargetSpeed = joyStick.Vertical * activeMoveSpeed;

            movement.x = XtargetSpeed;
            movement.y = YtargetSpeed * 0.6f;

            transform.position += Vector3.right * XtargetSpeed * Time.deltaTime;
            transform.position += Vector3.up * YtargetSpeed * 0.6f * Time.deltaTime;
    }
}
