using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    D_HealthBar healthBarData;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    public float currentHealth;

    [SerializeField]
    private HealthBar healthBar;

    private GameManager GM;

    private void Start()
    {
        currentHealth = healthBarData.playerMaxHealth;

        healthBar.SetMaxHealth(currentHealth);
        healthBar.Initialize();

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        GM.Respawn();
        Destroy(gameObject);
    }
}
