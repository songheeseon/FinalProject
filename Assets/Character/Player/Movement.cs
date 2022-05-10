using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    public float Speed; //플레이어 기본 이동 속도.
    private float XtargetSpeed; //플레이어의 기본 속도에 맞출 목표 속도.
    private float YtargetSpeed;

    //대쉬 선언
    private float activeMoveSpeed;

    public Joystick joyStick;
    Vector2 movement = new Vector2(); //벡터2 생성 선언.

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //이동 방향 바라보기 제어
        if (joyStick.Horizontal < 0 )
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (joyStick.Horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        MoveCharacter();
    }

    //상하좌우 키입력
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
