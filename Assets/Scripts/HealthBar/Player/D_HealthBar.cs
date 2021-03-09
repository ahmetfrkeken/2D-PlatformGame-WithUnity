using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newHealthBarData", menuName = "Data/State Data/Health Bar Data")]
public class D_HealthBar : ScriptableObject
{
    public float playerMaxHealth = 50f;

    public float enemy1MaxHealth;

}