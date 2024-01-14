using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float health;
    public GameObject deathEffect;
    public AudioSource soundeffect;
    public float maxHealth = 100;

    public HealthBarBehaviour Healthbar;
   

    public void Start()
    {
        health = maxHealth;

        Healthbar.SetHealth(health,maxHealth);
     }


    public void TakeDamage (int damage)
    {
        health -= damage;
        Healthbar.SetHealth(health,maxHealth);
        if (health <= 0)
        {   
            
            Die();
            
        }
    }


   public void Die()
    {
        soundeffect.Play();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);  
    }  


    
}