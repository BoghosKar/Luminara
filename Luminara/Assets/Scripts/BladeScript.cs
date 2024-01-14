using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{
    public PlayerMovement Player;
    public AudioSource sound;

    void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Player")
    {
      sound.Play();
      Player.Death();
    }
  }
}
