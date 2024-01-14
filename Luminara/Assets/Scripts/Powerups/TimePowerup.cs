using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePowerup : MonoBehaviour
{
    public Timer timer;
    public float addTime;
    public AudioSource sfx;
    public Text powerupText;
    public Animation pickupAnim;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            float remainingTime = timer.timerDuration - timer.currentTimerValue;
            float addedTime = Mathf.Min(addTime, remainingTime);
            timer.currentTimerValue += addedTime;
            sfx.Play();
            pickupAnim.Play();
            powerupText.text = "+" + addedTime.ToString("0") + "s";
            Destroy(gameObject);
        }    
    }
}
