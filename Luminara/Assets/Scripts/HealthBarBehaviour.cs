using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarBehaviour : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    
    
    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }


    void LateUpdate()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);

        //Slider.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.8f, 0f);
    }
}
