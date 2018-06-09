using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthAndDestroy : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInParent<PlayerHealth>().AddHealth(1);
            Destroy(gameObject);
        }
    }
}
