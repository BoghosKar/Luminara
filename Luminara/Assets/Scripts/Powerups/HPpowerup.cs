using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPpowerup : MonoBehaviour
{
    /*public PlayerMovement playermovement;
    public GameObject PowerUp;
    public HealthBarBehaviour HealthBar;

    public bool hasTaken;

    void Start()
    {
        hasTaken = false;
    }

    void Update() 
    {
        if(hasTaken)
        {

        }    
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        hasTaken = true;
        //HealthBar.SetHealth(playermovement.HP, playermovement.MaxHP);
        HealthBar.Slider.value = playermovement.HP;
        PowerUp.SetActive(false);
        playermovement.HP += 10;
    }*/

    
    public int hpToAdd = 10;
    public AudioSource powerUpSound;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null && player.is_alive)
            {
                player.HP += hpToAdd;
                player.HP = Mathf.Clamp(player.HP, 0, player.MaxHP); // ensure HP doesn't exceed MaxHP
                player.HealthBar.SetHealth(player.HP, player.MaxHP);
                powerUpSound.Play();
                Destroy(gameObject);
            }
        }
    }
}

    

