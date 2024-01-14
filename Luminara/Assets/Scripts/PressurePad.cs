using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePad : MonoBehaviour
{
    public GameObject objectToActivate;
    public AudioSource select;
    
    
    

    void Start()
    {
        objectToActivate.SetActive(false);  
        
    }

    
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        select.Play();
        objectToActivate.SetActive(true);   
        transform.localScale -= new Vector3(0, 0.2f, 0);
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
          select.Play();
          transform.localScale += new Vector3(0, 0.2f, 0);
    }
    
   
}
