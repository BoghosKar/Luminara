using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        Vector2 direction = Player.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
