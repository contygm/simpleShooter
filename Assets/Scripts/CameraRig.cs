using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    // NOTE: speed at which the camera follows player
    public float moveSpeed;
    public GameObject target;

    private Transform rigTransform;

    void Start()
    {
        // NOTE: referencing the parent Camera object's transform
        rigTransform = this.transform.parent;
    }

    void FixedUpdate()
    {
        if(target == null){
            return;
        }

        // NOTE: camera fo.lows player, eases into it
        rigTransform.position = Vector3.Lerp(
            rigTransform.position, 
            target.transform.position, 
            Time.deltaTime * moveSpeed);
        }
}
