using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health = 5;
    public Slider sliderHealth;
    // Use this for initialization
    void Start()
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = sliderHealth.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        sliderHealth.value = Mathf.Lerp(sliderHealth.value, health, Time.deltaTime * 3f);
        if (health <= 0)
        {
            sliderHealth.value = 0;
            Destroy(gameObject);           
        }
    }

    public void AddDamage(int damage)
    {
        health -= damage; //healt = healt - damage       
    }
}
