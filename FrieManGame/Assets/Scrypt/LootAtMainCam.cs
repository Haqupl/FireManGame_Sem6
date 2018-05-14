using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAtMainCam : MonoBehaviour
{
    private Transform target;

    // Use this for initialization
    void Start()
    {
        target = Camera.main.transform;
    }


    void LateUpdate()
    {
        var dist =  target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dist);
    }
}
