using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{

    // Use this for initialization
    public GameObject bullet;
    public Transform spawnPoint;
    public float timeBettwenShooting;
    private float lastShoot;
     
    // Update is called once per frame
    void Update()
    {

        bool inputShoot = Input.GetButton("Fire1");
        if (inputShoot && lastShoot <= Time.time)
        {
            lastShoot = Time.time + timeBettwenShooting;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
