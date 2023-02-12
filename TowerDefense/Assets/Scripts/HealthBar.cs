using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class responsible for health bar of enemies
/// </summary>
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Color lowHealth;
    [SerializeField] private Color highHealth;
    [SerializeField] private TMP_Text moneyNumber;

    private float _health;
    private float _maxHealth;

    private void Update()
    {
        Vector3 position = transform.parent.position;
        slider.transform.position = Camera.main.WorldToScreenPoint(position); 
        moneyNumber.transform.position = Camera.main.WorldToScreenPoint(position);
    }

    /// <summary>
    /// Method responsible of changing enemies' health bars
    /// </summary>
    /// <param name="health"></param>
    /// <param name="maxHealth"></param>
    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowHealth, highHealth, slider.normalizedValue);
    }
}
