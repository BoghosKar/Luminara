using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    public Animation anim;
    Rigidbody2D rb;
    public TrailRenderer tr;

    public GameObject slider;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        anim = player.GetComponent<Animation>();
        rb = player.GetComponent<Rigidbody2D>();  
        tr = player.GetComponent<TrailRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                StartCoroutine(PortalIn());
            }
        }    
    }

    IEnumerator PortalIn()
    {
        if(this.enabled == true)
        {
            if(slider)
            {
                slider.SetActive(false);
            }
        
                tr.enabled = false;
                rb.simulated = false;
                anim.Play("Portalin");
                StartCoroutine(MoveInPortal());
                yield return new WaitForSeconds(0.5f);
                player.transform.position = destination.position;
                rb.velocity = Vector2.zero;
                anim.Play("Portalout");
                yield return new WaitForSeconds(0.5f);
                rb.simulated = true;
                yield return new WaitForSeconds(0.5f);
                tr.enabled = true;
           
            

        }
    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while(timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }
}
