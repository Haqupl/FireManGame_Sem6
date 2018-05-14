using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    public Slider healtSlider;
    private GameObject player;

    void Start()
    {

        GameObject[] objPlayers = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < objPlayers.Length; i++)
        {
            if (objPlayers[i].name == "Player")
            {
                player = objPlayers[i];
                break;
            }
        }

        //if (player != null)
        //    pHealth = player.GetComponent<PlayerHealth>();
        //healtSlider.maxValue = health;
        healtSlider.value = healtSlider.maxValue;
    }

    void Update () {
        //healtSlider.value = Mathf.Lerp(healtSlider.value, health, Time.deltaTime * 3f);
    }
}
