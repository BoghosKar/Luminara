using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectoin : MonoBehaviour
{
    public LineRenderer line;    
    public GameObject gameObject1;         
     public GameObject gameObject2;  

    void Update()
    {
        line.SetPosition(0, gameObject1.transform.position);
        line.SetPosition(1, gameObject2.transform.position);
    }
}
