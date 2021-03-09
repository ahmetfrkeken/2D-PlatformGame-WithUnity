using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public Gradient gradient;


    [SerializeField]
    private Image fill;

    [SerializeField]
    D_Entity entityData;

    private float fillMultiplier;

    public void Initialize(float maxHealth)
    {
        fillMultiplier = 1 / entityData.maxHealth;
        fill.fillAmount = 1f;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float currentHealth)
    {
        fill.fillAmount = currentHealth * fillMultiplier;
        fill.color = gradient.Evaluate(currentHealth * fillMultiplier); 
    }
}
