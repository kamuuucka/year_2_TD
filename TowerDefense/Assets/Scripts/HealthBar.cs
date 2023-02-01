using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Color lowHealth;
    public Color highHealth;
    public Vector3 offset;
    public TMP_Text moneyNumber;

    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset ); 
        moneyNumber.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowHealth, highHealth, slider.normalizedValue);
    }
}
