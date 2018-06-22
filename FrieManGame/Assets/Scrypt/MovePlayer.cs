using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private float speed;
    public LayerMask mask;

    private Rigidbody rb;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    public void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        MoveAnim(inputX, inputZ);

        Ray rayMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        Rotation(rayMouse);
    }

    private void Move(float inputX, float inputZ)
    {
        Vector3 movement = new Vector3();
        movement.Set(inputX, 0f, inputZ);
        //movement.y = 0;
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

    }

    private void MoveAnim(float inputX, float inputZ)
    {
        //if (inputX != 0)
        anim.SetFloat("SpeedX", inputX * 4.4f, .13f, Time.deltaTime);
        //else
        //    anim.SetFloat("SpeedX", 0);

        //if (inputZ != 0)
        anim.SetFloat("SpeedZ", inputZ * 4.4f, .13f, Time.deltaTime);
        //else
        //    anim.SetFloat("SpeedZ", 0);
    }

    private void Rotation(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, mask))
        {
            Vector3 distatnce = hit.point - rb.position;
            distatnce.y = 0;

            Quaternion rot = Quaternion.LookRotation(distatnce);

            rb.MoveRotation(rot);
        }
    }





}
