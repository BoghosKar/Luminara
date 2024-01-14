using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    public float TimeBeforeDestroy;
    
    void Start()
    {
    StartCoroutine(DestroyWait());
    }

    IEnumerator DestroyWait()
    {
     yield return new WaitForSeconds(TimeBeforeDestroy);
        Destroy(this.gameObject); 
    }
}
