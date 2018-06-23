using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float health = 3, timeBetween = 1;
    public int damage = 1;
    public byte score = 5;
    public Slider sliderHealth;
    public GameObject healtBonus;
    public bool IsDead;
    private float lastAttack = 0;

    // Use this for initialization
    void Start()
    {
        if (sliderHealth != null)
        {
            sliderHealth.maxValue = health;
            sliderHealth.value = sliderHealth.maxValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderHealth != null)
            sliderHealth.value = Mathf.Lerp(sliderHealth.value, health, Time.deltaTime * 3f);

        if (health <= 0 && !IsDead)
        {
            IsDead = true;
            if (sliderHealth != null)
                sliderHealth.value = 0;
            FindObjectOfType<GameManagment>().AddScore(score);

            if ((Random.value * 100) >= 50)
            {
                Instantiate(healtBonus, transform.position, Quaternion.identity);
            }
            //Destroy(gameObject);
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
