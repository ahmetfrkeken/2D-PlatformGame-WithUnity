using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    D_HealthBar healthBarData;

    
    public void Initialize()
    {
        slider.value = slider.maxValue;
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void SetHealth(float currentHealth)
    {
        slider.value = currentHealth;
    }
}
