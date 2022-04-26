using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider Slider;
    public Color low;
    public Color High;
    public Vector3 Offset;


    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value= health;
        Slider.maxValue= maxHealth;

        //Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, High, Slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        Slider.transform.eulerAngles = new Vector3(0, 0, 0);
        Slider.transform.rotation = Quaternion.Euler(0, 0, 0);

        Slider.transform.position = transform.parent.position + Offset;
    }

}
