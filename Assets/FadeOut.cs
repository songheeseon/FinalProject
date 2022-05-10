using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeOut : MonoBehaviour
{
    public float animTime = 2f;         // Fade �ִϸ��̼� ��� �ð� (����:��).  
    private Image fadeImage;            // UGUI�� Image������Ʈ ���� ����.  

    private float start = 1f;           // Mathf.Lerp �޼ҵ��� ù��° ��.  
    private float end = 0f;             // Mathf.Lerp �޼ҵ��� �ι�° ��.  
    private float time = 0f;            // Mathf.Lerp �޼ҵ��� �ð� ��.  


    public bool stopIn = false; //false�϶� ����Ǵ°ǵ�, �ʱⰪ�� false�� �� ������ ���� �����Ҷ� ���̵������� ������...�װ� ������ true�� �ϸ��.
    public bool stopOut = true;

    public GameObject Fade;


    // Start is called before the first frame update
    void Awake()
    {
        fadeImage = GetComponent<Image>();
        //Invoke("fadefalse", 3f);
    }

    void fadefalse()
    {
        Fade.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (stopOut == false && time <= 2)
        {
            PlayFadeOut();
        }

        if (time >= 2 && stopIn == false)
        {
            stopIn = true;
            time = 0;
            Debug.Log("StopIn");
            Invoke("StopInFalse", 1.01f);
        }

        if (time >= 2 && stopOut == false)
        {
            stopIn = false; //�Ͼ�� ��ȯ�ǰ� ���� �� ��ȯ �� �ٽ� Ǯ�Ŷ� �־���. �׳� ���� �����Ÿ� ���� �ʿ� ����.
            stopOut = true;
            time = 0;
            Debug.Log("StopOut");
        }


        // ����->���
        void PlayFadeOut()
        {
            // ��� �ð� ���.  
            // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
            time += Time.deltaTime / animTime;

            // Image ������Ʈ�� ���� �� �о����.  
            Color color = fadeImage.color;
            // ���� �� ���.  
            color.a = Mathf.Lerp(end, start, time);  //FadeIn���� �޸� start, end�� �ݴ��.
                                                     // ����� ���� �� �ٽ� ����.  
            fadeImage.color = color;
        }
        
    }
}
