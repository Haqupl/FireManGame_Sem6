using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerShot : MonoBehaviour
{

    // Use this for initialization
    public GameObject bullet;
    public Transform spawnPoint;
    public float timeBettwenShooting;
    public byte AmmoInMagazine = 7;
    public Text AmmoTxt;
    private float lastShoot;
    private Animator anim;
    private Quaternion defaultPosition;
    private Quaternion shootPosition = new Quaternion(-364.21f, -169.46f, 167.25f, 1f);
    private GameObject gun;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);
        gun = spawnPoint.parent.gameObject;
        defaultPosition = gun.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        bool inputShoot = Input.GetButton("Fire1");
        if (inputShoot && AmmoInMagazine > 0)
        {
            anim.SetBool("Shoot", true);
            gun.transform.localRotation = shootPosition;
        }
        else
        {
            gun.transform.localRotation = defaultPosition;
            anim.SetBool("Shoot", false);
        }
        //anim.SetBool("Shoot", true);

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

    void EventShootAnim()
    {
        lastShoot = Time.time + timeBettwenShooting;
        AmmoInMagazine--;
        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
    }
}
