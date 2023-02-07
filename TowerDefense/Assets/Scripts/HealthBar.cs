using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //[ColorUsage(false)]
    public Color lowHealth;
    //[ColorUsage(false)]
    public Color highHealth;
    public Vector3 offset;
    public TMP_Text moneyNumber;

    public float health;
    public float maxHealth;

    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset ); 
        moneyNumber.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position);
    }

    private void OnValidate()
    {
        SetHealth(health,maxHealth);
    }

    public void SetHealth(float health, float maxHealth)
    {
        Debug.Log(health + " : " + maxHealth);
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowHealth, highHealth, slider.normalizedValue);
    }
}
