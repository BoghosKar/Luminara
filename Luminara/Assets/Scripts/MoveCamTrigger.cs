using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamTrigger : MonoBehaviour
{
    public bool didenter;
    public Vector3 pluspos;
    public Vector3 originalpos;
    public Transform CamTransform;
    void OnTriggerEnter2D(){
        if(didenter){
            didenter = false;
            CamTransform.position = Vector3.Lerp(CamTransform.position, originalpos, 100 * Time.deltaTime);
        }else{
            didenter = true;
            CamTransform.position = Vector3.Lerp(CamTransform.position, pluspos, 100 * Time.deltaTime);
        }
    }
}
