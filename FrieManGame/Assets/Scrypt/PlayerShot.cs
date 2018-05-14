using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{

    // Use this for initialization
    public GameObject bullet;
    public Transform spawnPoint;
    public float timeBettwenShooting;
    public byte AmmoInMagazine = 7;
    public Text AmmoTxt;
    private float lastShoot;

    // Update is called once per frame
    void Update()
    {

        bool inputShoot = Input.GetButton("Fire1");
        if (inputShoot && AmmoInMagazine > 0 && lastShoot <= Time.time)
        {
            lastShoot = Time.time + timeBettwenShooting;
            AmmoInMagazine--;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }

        bool reload = Input.GetButtonDown("ReloadWeapon");
        if ((reload && AmmoInMagazine < 7) || AmmoInMagazine == 0)
        {
            StartCoroutine(ReloadDelay());
        }

        AmmoTxt.text = AmmoInMagazine.ToString();
    }

    IEnumerator ReloadDelay()
    {
        lastShoot = Time.time + 10;
        yield return new WaitForSeconds(0.2f * (7 - AmmoInMagazine));
        lastShoot = Time.time + 0.1f;
        AmmoInMagazine = 7;
    }
}
