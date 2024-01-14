using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelEnd : MonoBehaviour
{
    public Animation anim;
    public GameObject winMenu;
    public GameObject Player;
    public GameObject timerDisplay;
    public GameObject pauseMenu;
    

    void Start()
    {   
        anim.Play();
    }

    
    IEnumerator OnTriggerEnter2D(Collider2D other) 
    {
       GameObject.Destroy(pauseMenu);
       timerDisplay.SetActive(false);
       Player.SetActive(false);
       winMenu.SetActive(true);
       yield return new WaitForSeconds(1);
       
    }


}   


 
