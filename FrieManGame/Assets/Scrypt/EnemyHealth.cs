using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 3, timeBetween = 1;
    public int damage = 1;

    private float lastAttack = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddDamege()
    {
        health--; // health = healt - 1;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (lastAttack <= Time.time)
            {
                lastAttack = Time.time + timeBetween;
                other.GetComponentInParent<PlayerHealth>().AddDamage(damage);
            }
            //Destroy(gameObject);         
        }
    }


}
