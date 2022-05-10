using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUi : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("UiText", 3F);
    }

    

    // Update is called once per frame
    void UiText()
    {
        gameObject.SetActive(false);
    }
}
