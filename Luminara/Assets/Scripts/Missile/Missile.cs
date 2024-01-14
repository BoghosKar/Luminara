using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public float angleChangingSpeed;
    public float movementSpeed;
    public PlayerMovement player;
    public AudioSource sound;
    public GameObject explosionPrefab; // Particle effect prefab
    public float chaseRadius = 10f; // Radius within which the missile will start chasing the player

    private bool isChasing = false;
    private float chaseTimer = 0f;

    public GameObject cell;

    void Start()
    {
        rb.gravityScale = 0f; // Set gravity scale to zero to prevent gravity from affecting the missile
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= chaseRadius && !isChasing)
        {
            isChasing = true;
            chaseTimer = 0f; // reset the timer when the missile starts chasing
        }

        if (isChasing)
        {
            chaseTimer += Time.fixedDeltaTime; // increment the timer every frame
            if (chaseTimer >= 5f) // check if the timer has reached 5 seconds
            {
                DestroyMissile();
                return; // exit the method to prevent further updates to the missile
            }

            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -angleChangingSpeed * rotateAmount;
            rb.velocity = transform.up * movementSpeed;
        }
        else
        {
            // Set velocity to zero to make the missile stay still
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cell")
        {
            Destroy(cell);
            DestroyMissile();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PlayerCollided");
            Destroy(gameObject);
            player.Death();
        }
        else if (other.gameObject.tag != "deadly")
        {
            Debug.Log("MissileCollided");
            DestroyMissile();
        }
    }

    public void DestroyMissile()
    {
        sound.Play();

        // Instantiate the explosion prefab at the missile's position
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
