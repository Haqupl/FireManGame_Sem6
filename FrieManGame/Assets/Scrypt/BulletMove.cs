using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    public float speed = 5;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag != "Player")
        {
            Destroy(gameObject);
        }
    }


}
