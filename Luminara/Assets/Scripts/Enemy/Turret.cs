using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform Player;
    
    public Transform firePoint;
    public int damage = 10;
    public LineRenderer lineRenderer;
    public GameObject impactEffect;
    private float distance;
    public bool isShooting;
    public float minimumdistance;
    
    public AudioSource shootSound;

    void Update()
    {
        Vector2 direction = Player.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        distance = Vector3.Distance(Player.position, transform.position);

       if(minimumdistance > distance && isShooting == false && Player != null)
       {
           
           StartCoroutine(EnemyShoot());
       }
    }


    IEnumerator EnemyShoot() 
    {
        
        isShooting = true;
        yield return new WaitForSeconds(1f); 

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position,firePoint.right);


        if(hitInfo)
        {
            
            shootSound.Play();
            PlayerMovement player = hitInfo.transform.GetComponent<PlayerMovement>();
            
            if(player != null)
            {
            player.TakeDamage(damage);
            }

            if(player = null)
            {
                
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);  
        }else
        {
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }  

        lineRenderer.enabled = true;
      
        yield return new WaitForSeconds(0.02f); 

        lineRenderer.enabled = false;

        
        isShooting = false;

    }
    
     public void OnDrawGizmos() 
     {
        Gizmos.DrawWireSphere(this.transform.position, minimumdistance);
     }

    
}
