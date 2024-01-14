using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] Vector3 speed;

    void Update()
    {
        this.transform.Rotate(speed * Time.deltaTime);
    }
}
