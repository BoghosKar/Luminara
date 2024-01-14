using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public PlayerMovement Player;
    public ParticleSystem ps;
    public Missile missile;

    void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Player")
    {
      ps.Play();
      Player.Death();
    }

    if(other.tag == "deadly")
    {
      ps.Play();
      missile.DestroyMissile();
    } 
  }



}
