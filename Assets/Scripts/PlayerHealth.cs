using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;

     int currentHealth;

     public HealthBar healthBar;
     public GameObject gameOver;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("enemy"))
        {
            TakeDamage(10);
        }
    }
   

}
